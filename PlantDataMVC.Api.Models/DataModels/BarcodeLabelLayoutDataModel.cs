namespace PlantDataMVC.Api.Models.DataModels
{
    public class BarcodeLabelLayoutDataModel
    {
        public string LayoutName { get; set; } = string.Empty;
        public bool IsDefault { get; set; }

        // Page Setup
        public string PageSize { get; set; } = string.Empty;

        public int LabelsPerPage { get; set; }

        public double PageTopMargin { get; set; }
        public double PageBottomMargin { get; set; }
        public double PageLeftMargin { get; set; }
        public double PageRightMargin { get; set; }

        // Column setup
        public int ColumnsPerRow { get; set; }
        public double LabelWidthMM { get; set; }
        public double LabelColumnGapWidthMM { get; set; }

        // Row setup
        public int RowsPerPage { get; set; }
        public double LabelRowHeightMM { get; set; }
    }
}
