using PlantDataMVC.Api.Reports.InfoLabels.Models;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using PlantDataMvc.Api.Reports;

namespace PlantDataMVC.Api.Reports.InfoLabels
{
    public class InfoLabelReportRenderer
    {
        private Document _report = new();

        private readonly string _reportFont = "Arial";

        // Page Setup
        private readonly int _pageTopMargin = 5;
        private readonly int _pageBottomMargin = 5;
        private readonly int _pageLeftMargin = 5;
        private readonly int _pageRightMargin = 5;



        private readonly InfoLabelReportModel _reportModel;

        private readonly int _labelsPerRow = 2;
        private readonly int _cellsPerLabel = 2; // Text cell and buffer cell

        private readonly int _labelRowHeightMM = 15;
        private readonly int _speciesNameFontSize = 11;

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
                _report.DefaultPageSetup.PageFormat = PageFormat.A4;

                CreateDocument();

                using MemoryStream s = new MemoryStream();

                var pdfRenderer = new PdfDocumentRenderer() { Document = _report };
                pdfRenderer.RenderDocument();
                pdfRenderer.PdfDocument.Save(s);

                // HACK: Save to file as well, for testing
                string filePath = "..\\logs\\InfoLabelReport.pdf";
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }   
                pdfRenderer.PdfDocument.Save(filePath);

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

            section.PageSetup = _report.DefaultPageSetup.Clone();

            section.PageSetup.PageFormat = PageFormat.A4;

            section.PageSetup.Orientation = Orientation.Portrait; //_reportModel.HeaderInfo.ReportOrientation;

            section.PageSetup.LeftMargin = Unit.FromMillimeter(_pageLeftMargin);
            section.PageSetup.RightMargin = Unit.FromMillimeter(_pageRightMargin);
            section.PageSetup.TopMargin = Unit.FromMillimeter(_pageTopMargin);
            section.PageSetup.BottomMargin = Unit.FromMillimeter(_pageBottomMargin);


            Table table = CreateLabelItemTable();

            const int cols = 2;

            foreach (var labelGroup in _reportModel.LabelItems)
            {
                if (labelGroup.LabelQuantity > 0)
                {
                    Row currentRow = table.AddRow();

                    for (int i = 0; i < labelGroup.LabelQuantity; i++)
                    {
                        if ((i > 0) && i % _labelsPerRow == 0)
                        {
                            currentRow = table.AddRow();
                        }

                        int cellIndex = (i % _labelsPerRow) * _cellsPerLabel;
                        AddLabelItem(currentRow.Cells[cellIndex], labelGroup);
                    }
                }
            }
        }

        private Table CreateLabelItemTable()
        {
            // Total width = 210
            var section = _report.LastSection;
            var pageWidth = section.PageSetup.Orientation == Orientation.Landscape ? section.PageSetup.PageHeight : section.PageSetup.PageWidth;
            var printableWidthMM = pageWidth.Millimeter - section.PageSetup.LeftMargin.Millimeter - section.PageSetup.RightMargin.Millimeter;
            var labelBottomBufferWidth = Unit.FromMillimeter(25);
            var textColWidth = printableWidthMM / _labelsPerRow - labelBottomBufferWidth.Millimeter;
            
            Table table = _report.LastSection.AddTable();

            // table default format
            table.Format.LineSpacingRule = LineSpacingRule.Single;
            table.Format.Font.Name = _reportFont;
            table.Format.Font.Size = _speciesNameFontSize;
            table.Rows.Height = Unit.FromMillimeter(_labelRowHeightMM);
            table.Rows.HeightRule = RowHeightRule.AtLeast;
            table.Borders.Visible = true;

            // Create columns
            // Left text column
            Column column = table.AddColumn();
            column.Width = Unit.FromMillimeter(textColWidth);
            column.Format.Alignment = ParagraphAlignment.Left;
            column.Borders.Right.Visible = false;

            // Left buffer column
            column = table.AddColumn();
            column.Width = labelBottomBufferWidth;
            column.Format.Alignment = ParagraphAlignment.Left;
            column.Borders.Left.Visible = false;

            // Right text column
            column = table.AddColumn();
            column.Width = Unit.FromMillimeter(textColWidth);
            column.Format.Alignment = ParagraphAlignment.Left;
            column.Borders.Right.Visible = false;

            // Right buffer column
            column = table.AddColumn();
            column.Width = labelBottomBufferWidth;
            column.Format.Alignment = ParagraphAlignment.Left;
            column.Borders.Left.Visible = false;

            return table;
        }

        private void AddLabelItem(Cell cell, InfoLabelItemModel labelItem)
        {
            var para = cell.AddParagraph(labelItem.SpeciesBinomial ?? "");
            para.Format.Font.Bold = true;
            para.Format.Font.Italic = true;
            para.Format.Font.Size = 11;
            para.Format.SpaceBefore = Unit.FromMillimeter(0);
            para.Format.SpaceAfter = Unit.FromMillimeter(0);

            var commonNameFont = para.Format.Font.Clone();
            commonNameFont.Bold = false;
            commonNameFont.Italic = false;
            commonNameFont.Size = 10;
            para.AddFormattedText($" - {labelItem.CommonName ?? ""}", commonNameFont);

            para = cell.AddParagraph(labelItem.Description ?? "");
            para.Format.Font.Bold = false;
            para.Format.Font.Italic = false;
            para.Format.Font.Size = 9;
        }
    }
}
