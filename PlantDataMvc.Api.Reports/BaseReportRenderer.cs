using MigraDoc.DocumentObjectModel;

namespace PlantDataMvc.Api.Reports
{
    public class BaseReportRenderer
    {
        private protected Document _report = new();

        private protected readonly string _reportFont = "Arial";

        //// Image
        //public const int HeaderImageHeight = 27;
        //public const int HeaderImageWidth = 130;

        // Page Setup
        private protected readonly int _pageTopMargin = 5;
        private protected readonly int _pageBottomMargin = 5;
        private protected readonly int _pageLeftMargin = 5;
        private protected readonly int _pageRightMargin = 5;
        //private protected readonly int _pageHeaderDistance = 10;
        //private protected readonly int _pageFooterDistance = 5;

        //// Header
        //private protected readonly int _headerRowHeight = 4;
        //private protected readonly int _headerFontSize = 10;
        //private protected readonly int _headerCompanyNameFontSize = 12;
        //private protected readonly int _headerOrderIdFontSize = 16;
        //private protected readonly int _headerHorizontallLineWidth = 3;
        //private protected readonly int _headerPortraitSubTitleLengthLimit = 23;
        //private protected readonly int _headerLandscapeSubTitleLengthLimit = 45;

        //// Order Info
        //private protected readonly int _baseOrderInfoRowHeight = 4;
        //private protected readonly int _baseOrderInfoFontSize = 8;

        //// Footer
        //private protected readonly int _footerFontSize = 6;

        //private protected readonly int _footerLeftColumn;
        //private protected readonly int _footerCenterColumn = 1;
        //private protected readonly int _footerPageTextColumn = 2;
        //private protected readonly int _footerPageNoColumn = 3;

        //private protected readonly int _sectionPrintWidth = 190;
        //private protected readonly int _sectionLandscapePrintWidth = 277;

    }
}
