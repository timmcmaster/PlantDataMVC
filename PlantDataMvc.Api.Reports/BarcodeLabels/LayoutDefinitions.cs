namespace PlantDataMvc.Api.Reports.BarcodeLabels.Models
{
    public static class LayoutDefinitions
    {
        public static BarcodeLabelLayoutDefinition AveryL7651
        {
            get
            {
                var layout = new BarcodeLabelLayoutDefinition()
                {
                    LayoutName = "Avery L7651",
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
        }

        public static BarcodeLabelLayoutDefinition AveryL7158
        {
            get
            {
                var layout = new BarcodeLabelLayoutDefinition()
                {
                    LayoutName = "Avery L7158",
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
        }
    }
}
