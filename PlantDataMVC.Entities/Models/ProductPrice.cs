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

    // ProductPrice
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.2.0")]
    public partial class ProductPrice
    {
        public int PriceListTypeId { get; set; } // PriceListTypeId (Primary key)
        public int ProductTypeId { get; set; } // ProductTypeId (Primary key)
        public decimal Price { get; set; } // Price
        public System.DateTime DateEffective { get; set; } // DateEffective (Primary key)

        // Foreign keys

        /// <summary>
        /// Parent PriceListType pointed by [ProductPrice].([PriceListTypeId]) (FK_ProductPrices_PriceListType)
        /// </summary>
        public virtual PriceListType PriceListType { get; set; } // FK_ProductPrices_PriceListType

        /// <summary>
        /// Parent ProductType pointed by [ProductPrice].([ProductTypeId]) (FK_ProductPrices_ProductType)
        /// </summary>
        public virtual ProductType ProductType { get; set; } // FK_ProductPrices_ProductType

        public ProductPrice()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>
