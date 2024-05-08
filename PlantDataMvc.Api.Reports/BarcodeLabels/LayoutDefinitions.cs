using PlantDataMVC.Api.Models.DataModels;

namespace PlantDataMVC.Api.Reports.BarcodeLabels.Models
{
    public static class LayoutDefinitions
    {
        public static BarcodeLabelLayoutDataModel GetAveryL7651(bool setAsDefault = false)
        {
            var layout = new BarcodeLabelLayoutDataModel()
            {
                LayoutName = "Avery L7651",
                IsDefault = setAsDefault,
                PageSize = "A4",
                LabelsPerPage = 65,
                PageTopMargin = 10.7,
                PageBottomMargin = 0,
                PageLeftMargin = 4.7,
                PageRightMargin = 4.7,
                ColumnsPerRow = 9,
                LabelWidthMM = 38.1,
                LabelColumnGapWidthMM = 2.5,
                RowsPerPage = 13,
                LabelRowHeightMM = 21.2
            };

            return layout;
        }

        public static BarcodeLabelLayoutDataModel GetAveryL7158(bool setAsDefault = false)
        {
            var layout = new BarcodeLabelLayoutDataModel()
            {
                LayoutName = "Avery L7158",
                IsDefault = setAsDefault,
                PageSize = "A4",
                LabelsPerPage = 30,
                PageTopMargin = 10.7,
                PageBottomMargin = 0,
                PageLeftMargin = 4.7,
                PageRightMargin = 4.7,
                ColumnsPerRow = 5,
                LabelWidthMM = 64.0,
                LabelColumnGapWidthMM = 2.5,
                RowsPerPage = 10,
                LabelRowHeightMM = 26.7
            };

            return layout;
        }

        public static List<BarcodeLabelLayoutDataModel> GetAllLayouts()
        {
            var list = new List<BarcodeLabelLayoutDataModel>()
            {
                GetAveryL7651(setAsDefault: true),
                GetAveryL7158()
            };

            return list;
        }
    }
}
