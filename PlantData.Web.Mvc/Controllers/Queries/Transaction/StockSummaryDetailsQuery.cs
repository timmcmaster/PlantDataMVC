using Framework.Web.Views;
using PlantData.Web.Mvc.Models.ViewModels.Transaction;

namespace PlantData.Web.Mvc.Controllers.Queries.Transaction
{
    public class StockSummaryDetailsQuery : IQuery<TransactionStockSummaryDetailsViewModel>
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