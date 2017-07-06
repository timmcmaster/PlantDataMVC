// <auto-generated>
// ReSharper disable ConvertPropertyToExpressionBody
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable InconsistentNaming
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable RedundantNameQualifier
// ReSharper disable RedundantOverridenMember
// ReSharper disable UseNameofExpression
// TargetFrameworkVersion = 4.5
#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning


namespace PlantDataMVC.Entities.Models
{

    // PriceListType
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.31.1.0")]
    public partial class PriceListType
    {
        public int Id { get; set; } // Id (Primary key)
        public string Name { get; set; } // Name (length: 50)
        public string Kind { get; set; } // Kind (length: 1)

        // Reverse navigation

        /// <summary>
        /// Child ProductPrices where [ProductPrice].[PriceListTypeId] point to this entity (FK_ProductPrices_PriceListType)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<ProductPrice> ProductPrices { get; set; } // ProductPrice.FK_ProductPrices_PriceListType

        public PriceListType()
        {
            ProductPrices = new System.Collections.Generic.List<ProductPrice>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>
