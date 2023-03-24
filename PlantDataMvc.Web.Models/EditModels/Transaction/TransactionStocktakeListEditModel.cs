namespace PlantDataMVC.Web.Models.EditModels.Transaction
{
    public class TransactionStocktakeListEditModel
    {
        public int SpeciesId { get; set; }

        public int ProductTypeId { get; set; }

        public int QuantityInStock { get; set; }

        public int CountedQuantity { get; set; }

        public int Discrepancy { get; set; } 

        public string? Reason { get; set; }

        public bool IsStock { get; set; }

        public TransactionStocktakeListEditModel()
        {
        }
    }
}
