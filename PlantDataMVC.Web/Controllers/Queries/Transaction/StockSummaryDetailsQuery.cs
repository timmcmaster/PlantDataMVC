using Framework.Web.Views;
using PlantDataMVC.Web.Models.ViewModels.Transaction;

namespace PlantDataMVC.Web.Controllers.Queries.Transaction
{
    public class StockSummaryDetailsQuery: IQuery<TransactionStockSummaryDetailsViewModel>
    {
        public int SpeciesId { get; set; }
        public int ProductTypeId { get; set; }

        public StockSummaryDetailsQuery(int speciesId, int productTypeId)
        {
            SpeciesId = speciesId;
            ProductTypeId = productTypeId;
        }
    }
}