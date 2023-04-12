using PlantDataMVC.Api.Reports.InfoLabels.Models;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using PlantDataMvc.Api.Reports;

namespace PlantDataMVC.Api.Reports.InfoLabels
{
    public class InfoLabelReportRenderer : BaseReportRenderer
    {
        private readonly InfoLabelReportModel _reportModel;

        private readonly int _orderLineRowHeight = 4;
        private readonly int _orderLineFontSize = 11;

        public InfoLabelReportRenderer(InfoLabelReportModel reportModel)
        {
            _reportModel = reportModel;
        }

        public string? BuildReport()
        {
            string? reportData = null;

            try
            {
                // Create the PDF Document
                _report = new Document();

                CreateDocument();

                using MemoryStream s = new MemoryStream();

                var pdfRenderer = new PdfDocumentRenderer() { Document = _report };
                pdfRenderer.RenderDocument();
                pdfRenderer.PdfDocument.Save(s);

                reportData = Convert.ToBase64String(s.ToArray());
            }
            catch
            {
                throw;
            }

            return reportData;
        }

        private void CreateDocument()
        {
            // Add a section to the document
            Section section = _report.AddSection();

            section.PageSetup.Orientation = Orientation.Portrait; //_reportModel.HeaderInfo.ReportOrientation;

            section.PageSetup.LeftMargin = Unit.FromMillimeter(_pageLeftMargin);
            section.PageSetup.RightMargin = Unit.FromMillimeter(_pageRightMargin);
            section.PageSetup.TopMargin = Unit.FromMillimeter(68);
            section.PageSetup.BottomMargin = Unit.FromMillimeter(32);

            section.PageSetup.HeaderDistance = Unit.FromMillimeter(_pageHeaderDistance);
            section.PageSetup.FooterDistance = Unit.FromMillimeter(_pageFooterDistance);

            Table labelItemsTable = CreateLabelItemTable();

            foreach (var labelGroup in _reportModel.LabelItems)
            {
                for (int i=0; i < labelGroup.LabelQuantity; i++)
                {
                    AddLabelItemLine(labelItemsTable, labelGroup);
                }
            }
        }

        private Table CreateLabelItemTable()
        {
            // Total width = 276
            int col0Width = 138;
            int col1Width = 138;

            Table table = _report.LastSection.AddTable();

            // table default format
            table.Format.LineSpacingRule = LineSpacingRule.OnePtFive;
            table.Format.Font.Name = _reportFont;
            table.Format.Font.Size = _orderLineFontSize;
            table.Rows.Height = Unit.FromMillimeter(_orderLineRowHeight);

            // Create columns
            // Left column
            Column column = table.AddColumn();
            column.Width = Unit.FromMillimeter(col0Width);
            column.Format.Alignment = ParagraphAlignment.Left;

            // Right column
            column = table.AddColumn();
            column.Width = Unit.FromMillimeter(col1Width);
            column.Format.Alignment = ParagraphAlignment.Left;

            return table;
        }


        private void AddLabelItemLine(Table table, InfoLabelItemModel labelItem)
        {
            Row row = table.AddRow();

            var para = row.Cells[0].AddParagraph(labelItem.SpeciesBinomial);
            para = row.Cells[0].AddParagraph(labelItem.CommonName);
            para = row.Cells[0].AddParagraph(labelItem.Description);
        }
    }
}
