// <auto-generated>
// ReSharper disable ConvertPropertyToExpressionBody
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable EmptyNamespace
// ReSharper disable InconsistentNaming
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable RedundantNameQualifier
// ReSharper disable RedundantOverridenMember
// ReSharper disable UseNameofExpression
// TargetFrameworkVersion = 4.7
#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning


namespace PlantDataMVC.Entities.Models
{

    // ProductType
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.2.0")]
    public partial class ProductType
    {
        public override int Id { get; set; } // Id (Primary key)
        public string Name { get; set; } // Name (length: 50)

        // Reverse navigation

        /// <summary>
        /// Child PlantStocks where [PlantStock].[ProductTypeId] point to this entity (FK_PlantStock_ProductType)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<PlantStock> PlantStocks { get; set; } // PlantStock.FK_PlantStock_ProductType
        /// <summary>
        /// Child ProductPrices where [ProductPrice].[ProductTypeId] point to this entity (FK_ProductPrices_ProductType)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<ProductPrice> ProductPrices { get; set; } // ProductPrice.FK_ProductPrices_ProductType

        public ProductType()
        {
            PlantStocks = new System.Collections.Generic.List<PlantStock>();
            ProductPrices = new System.Collections.Generic.List<ProductPrice>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>
