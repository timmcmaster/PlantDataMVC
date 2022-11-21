using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.AccessControl;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PlantDataMvc.WebApiCore.Tests;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.DTO.Mappers;
using PlantDataMVC.Entities.EntityModels;
using PlantDataMVC.WebApiCore.Classes;
using PlantDataMVC.WebApiCore.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace PlantDataMVC.WebApiCore.Tests.UnitTests
{
    public class HelperTests
    {
        private readonly ITestOutputHelper _output;

        public HelperTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void TestOriginalDataShapedObject()
        {
            // Arrange
            var species = DataHelper.GetSpeciesDtoTest1();

            var fields =
                "commonName,plantStocks,plantStocks.quantityInStock,seedBatches.DateCollected,seedBatches.location";

            var fieldList = fields.Split(',').ToList();

            var expectedJson = LoadJson("expectedDataShapedObject_Test1.json");
            var expected = JToken.Parse(expectedJson);

            // Act

            var dataShapedObject = DataShaping_Original.CreateDataShapedObject(species, fieldList);

            var actualJson = JsonConvert.SerializeObject(dataShapedObject);
            var actual = JToken.Parse(actualJson);

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }


        [Fact]
        public void TestDataShapedObject()
        {
            // Arrange
            var species = DataHelper.GetSpeciesDtoTest1();

            var fields =
                "commonName,plantStocks,plantStocks.quantityInStock,seedBatches.DateCollected,seedBatches.location";

            var fieldList = fields.Split(',').ToList();

            var expectedJson = LoadJson("expectedDataShapedObject_Test1.json");
            var expected = JToken.Parse(expectedJson);

            // Act

            //var dataShapedObject = DataShaping_Original.CreateDataShapedObject(species, fieldList);
            var dataShapedObject = DataShaping.CreateDataShapedObject(species, fieldList);

            var actualJson = JsonConvert.SerializeObject(dataShapedObject);
            var actual = JToken.Parse(actualJson);

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [InlineData("a,a.x,a.y,a.z", "a")]
        [InlineData("a,a.x,a.y,a.z,b", "a,b")]
        [InlineData("a.x,a.y,a.z,b", "a.x,a.y,a.z,b")]
        [InlineData("commonName,plantStocks,plantStocks.quantityInStock,seedBatches.DateCollected,seedBatches.location", "commonName,plantStocks,seedBatches.DateCollected,seedBatches.location")]
        public void GetTrimmedFieldList_ShouldRemoveExtraFields(string fieldList, string expectedFieldList)
        {
            var expectedResult = expectedFieldList.Split(",").ToList();

            // Act
            var splitFieldList = fieldList.Split(",").ToList();
            var methodParams = new object[] { splitFieldList };
            var myMethod = typeof(DataShaping).GetMethod("GetTrimmedFieldList", BindingFlags.Static | BindingFlags.NonPublic);
            var actualResult = myMethod?.Invoke(null, methodParams);

            // Assert
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void TestGetFieldTree()
        {
            // Arrange
            var trimmedFields = "commonName,plantStocks.quantityInStock,seedBatches.DateCollected,seedBatches.location";
            var expectedFieldTree = DataHelper.GetFixedFieldTree(trimmedFields);
            var expectedFlattenedTree = expectedFieldTree.Flatten();

            // Act
            var splitFieldList = trimmedFields.Split(",").ToList();
            var methodParams = new object[] { splitFieldList };
            var myMethod = typeof(DataShaping).GetMethod("GetFieldTree", BindingFlags.Static | BindingFlags.NonPublic);
            var actualFieldTree = myMethod?.Invoke(null, methodParams);


            // Assert
            // HACK: test should really compare structure, not just list of node values
            var actualFlattenedTree = ((TreeNode<string>)actualFieldTree).Flatten();
            actualFlattenedTree.Should().BeEquivalentTo(expectedFlattenedTree);
        }

        [Fact]
        public void TestGetPropertyTree()
        {
            // Arrange
            var trimmedFields = "commonName,plantStocks.quantityInStock,seedBatches.DateCollected,seedBatches.location";

            // Act
            var splitFieldList = trimmedFields.Split(",").ToList();
            var methodParams = new object[] { splitFieldList };
            var myMethod = typeof(DataShaping).GetMethod("GetFieldTree", BindingFlags.Static | BindingFlags.NonPublic);
            var actualFieldTree = myMethod?.Invoke(null, methodParams);
            
            methodParams = new object[] { DataHelper.GetSpeciesDtoTest1(),actualFieldTree };
            myMethod = typeof(DataShaping).GetMethod("GetPropertyTree", BindingFlags.Static | BindingFlags.NonPublic);
            var generic = myMethod.MakeGenericMethod(typeof(SpeciesDto));
            var actualPropertyTree = (TreeNode<PropertyData>)generic.Invoke(null, methodParams);


            // Assert
            // Very basic checks for now
            actualPropertyTree.Should().NotBeNull();
            actualPropertyTree.Children.Count().Should().Be(3);
        }

        [Fact]
        public void TestNodePropertyData()
        {
            // Arrange
            var trimmedFields = "commonName,plantStocks.quantityInStock,seedBatches.DateCollected,seedBatches.location";


            // Act
            var splitFieldList = trimmedFields.Split(",").ToList();
            var methodParams = new object[] { splitFieldList };
            var myMethod = typeof(DataShaping).GetMethod("GetFieldTree", BindingFlags.Static | BindingFlags.NonPublic);
            var actualFieldTree = myMethod?.Invoke(null, methodParams);

            methodParams = new object[] { DataHelper.GetSpeciesDtoTest1(), actualFieldTree };
            myMethod = typeof(DataShaping).GetMethod("GetPropertyTree", BindingFlags.Static | BindingFlags.NonPublic);
            var generic = myMethod.MakeGenericMethod(typeof(SpeciesDto));
            var actualPropertyTree = (TreeNode<PropertyData>)generic.Invoke(null, methodParams);

            methodParams = new object[] { actualPropertyTree.Value };
            myMethod = typeof(DataShaping).GetMethod("GetKVPFromProperty", BindingFlags.Static | BindingFlags.NonPublic);
            var kvp = myMethod?.Invoke(null, methodParams);

            // Assert
            Assert.True(true);

        }

        [Fact]
        public void TestNodeTraversal()
        {
            var originalOutput = Console.Out;
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);
            
            // Arrange
            var trimmedFields = "commonName,plantStocks.quantityInStock,seedBatches.DateCollected,seedBatches.location";


            // Act
            var splitFieldList = trimmedFields.Split(",").ToList();
            var methodParams = new object[] { splitFieldList };
            var myMethod = typeof(DataShaping).GetMethod("GetFieldTree", BindingFlags.Static | BindingFlags.NonPublic);
            var actualFieldTree = myMethod?.Invoke(null, methodParams);

            methodParams = new object[] { DataHelper.GetSpeciesDtoTest1(), actualFieldTree };
            myMethod = typeof(DataShaping).GetMethod("GetPropertyTree", BindingFlags.Static | BindingFlags.NonPublic);
            var generic = myMethod.MakeGenericMethod(typeof(SpeciesDto));
            var actualPropertyTree = (TreeNode<PropertyData>)generic.Invoke(null, methodParams);

            var o = actualPropertyTree.TraverseWithObject(DataShaping.GetKVPFromProperty);

            _output.WriteLine(sw.ToString());
            Console.SetOut(originalOutput);

            // Assert
            Assert.True(true);

        }

        [Fact]
        public void TestGetRelatedObjects()
        {
            //var relatedObjs = DataShaping.GetRelatedDtoProperties<SpeciesDto>();
        }

        
        [Theory]
        [InlineData("", "")]
        [InlineData("commonName", "[commonName]")]
        [InlineData("commonName,plantStocks.quantityInStock,seedBatches.DateCollected,seedBatches.location", "[commonName,plantStocks[quantityInStock],seedBatches[DateCollected,location]]")]
        public void TestStringTraversalVisitor(string trimmedFieldList, string expectedTraversalList)
        {
            // Arrange
            var sourceFieldTree = DataHelper.GetFixedFieldTree(trimmedFieldList);

            // Act
            var visitor = new StringTraversalVisitor(TraversalMode.Preorder);
            sourceFieldTree.Accept(visitor);

            // Assert
            var traversalList = visitor.TraversalString;
            traversalList.Should().Be(expectedTraversalList);
        }

        [Theory]
        [InlineData("")]
        [InlineData("commonName")]
        [InlineData("commonName,plantStocks.quantityInStock,seedBatches.DateCollected,seedBatches.location")]
        public void TestPropertyDataTraversalVisitor(string trimmedFieldList)
        {
            // Arrange
            var sourceFieldTree = DataHelper.GetFixedFieldTree(trimmedFieldList);

            // Act
            var methodParams = new object[] { DataHelper.GetSpeciesDtoTest1(), sourceFieldTree };
            var myMethod = typeof(DataShaping).GetMethod("GetPropertyTree", BindingFlags.Static | BindingFlags.NonPublic);
            var generic = myMethod.MakeGenericMethod(typeof(SpeciesDto));
            var actualPropertyTree = (TreeNode<PropertyData>)generic.Invoke(null, methodParams);

            var visitor = new PropertyDataTraversalVisitor();
            actualPropertyTree.Accept(visitor);

            // Assert
            var dataObject = visitor.RootDictionary;

            var actualJson = JsonConvert.SerializeObject(dataObject);
            var actual = JToken.Parse(actualJson);

            //Assert.True(false);
        }

        [Theory]
        [InlineData("", "")]
        [InlineData("commonName", "[commonName]")]
        [InlineData("commonName,plantStocks.quantityInStock,seedBatches.DateCollected,seedBatches.location", "[commonName,plantStocks[quantityInStock],seedBatches[DateCollected,location]]")]
        public void TestCloneVisitor(string trimmedFieldList, string expectedTraversalList)
        {
            // Arrange
            var sourceFieldTree = DataHelper.GetFixedFieldTree(trimmedFieldList);

            // Act
            var cloneVisitor = new CloneVisitor<string>();
            sourceFieldTree.Accept(cloneVisitor);
            var clonedTree = cloneVisitor.CloneRoot;

            // Assert
            clonedTree.Should().NotBeNull();

            var stv = new StringTraversalVisitor(TraversalMode.Preorder);
            clonedTree.Accept(stv);

            var traversalList = stv.TraversalString;
            traversalList.Should().Be(expectedTraversalList);
        }

        [Theory]
        [InlineData("", "")]
        [InlineData("commonName", "emaNnommoc")]
        [InlineData("commonName,plantStocks.quantityInStock,seedBatches.DateCollected,seedBatches.location", "emaNnommoc,skcotStnalp.kcotSnIytitnauq,sehctaBdees.detcelloCetaD,sehctaBdees.noitacol")]
        public void TestCloneAndTransformVisitor(string trimmedFieldList, string reversedFieldList)
        {
            // Arrange
            var sourceFieldTree = DataHelper.GetFixedFieldTree(trimmedFieldList);
            var expectedFieldTree = DataHelper.GetFixedFieldTree(reversedFieldList);
            var expectedFlattenedTree = expectedFieldTree.Flatten();

            // Act
            var transformVisitor = new CloneAndTransformVisitor<string,string>(ReverseFieldName);
            sourceFieldTree.Accept(transformVisitor);
            var transformedTree = transformVisitor.CloneRoot;

            // Assert
            // HACK: test should really compare structure, not just list of node values
            var actualFlattenedTree = ((TreeNode<string>)transformedTree).Flatten();
            actualFlattenedTree.Should().BeEquivalentTo(expectedFlattenedTree);
        }


        private string LoadJson(string filename)
        {
            var path = Path.Combine(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                "Data",
                filename);

            return File.ReadAllText(path);
        }

        private string ReverseFieldName(TreeNode<string> fieldNode, TreeNode<string> targetParent)
        {
            var charArray = fieldNode.Value.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

    }
}