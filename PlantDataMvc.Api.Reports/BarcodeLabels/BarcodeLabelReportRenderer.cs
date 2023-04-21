using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using PlantDataMvc.Api.Reports.BarcodeLabels.Models;

namespace PlantDataMvc.Api.Reports.BarcodeLabels
{
    public class BarcodeLabelReportRenderer
    {
        private Document _report = new();

        private readonly string _reportFont = "Arial";
        private readonly string _barcodeFont = "Free 3 of 9";

        // Page Setup
        private readonly double _pageTopMargin = 10.9;
        private readonly double _pageBottomMargin = 0;
        private readonly double _pageLeftMargin = 4.7;
        private readonly double _pageRightMargin = 4.7;

        // Column setup
        private readonly int _labelsPerRow = 5;
        private readonly int _columnsPerRow = 9;
        private readonly int _cellsPerLabel = 1;
        private readonly double _labelWidthMM = 38.1;
        private readonly double _labelColumnGapWidthMM = 2.5;

        // Row setup
        private readonly int _rowsPerPage = 13;
        private readonly double _labelRowHeightMM = 21.2;




        private readonly BarcodeLabelReportModel _reportModel;

        private readonly int _textFontSize = 11;
        private readonly int _priceFontSize = 14;
        private readonly int _barcodeFontSize = 24;

        public BarcodeLabelReportRenderer(BarcodeLabelReportModel reportModel)
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
                string filePath = "..\\logs\\BarcodeLabelReport.pdf";
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

            section.PageSetup.Orientation = Orientation.Portrait;

            section.PageSetup.LeftMargin = Unit.FromMillimeter(_pageLeftMargin);
            section.PageSetup.RightMargin = Unit.FromMillimeter(_pageRightMargin);
            section.PageSetup.TopMargin = Unit.FromMillimeter(_pageTopMargin);
            section.PageSetup.BottomMargin = Unit.FromMillimeter(_pageBottomMargin);

            Table table = CreateLabelItemTable();

            foreach (var labelGroup in _reportModel.LabelItems)
            {
                // Create a full page for each group
                Row currentRow;

                for (int rowIndex = 0; rowIndex < _rowsPerPage; rowIndex++)
                {
                    currentRow = table.AddRow();

                    int colIndex = 0;
                    while (colIndex < _columnsPerRow)
                    {
                        AddLabelItem(currentRow.Cells[colIndex++], labelGroup);
                        colIndex++; // Skip gap column
                    }
                }
            }
        }


        private Table CreateLabelItemTable()
        {
            // Total width = 210
            var section = _report.LastSection;

            Table table = _report.LastSection.AddTable();

            // table default format
            table.Format.LineSpacingRule = LineSpacingRule.Single;
            table.Format.Font.Name = _reportFont;
            table.Format.Font.Size = _textFontSize;
            table.Rows.Height = Unit.FromMillimeter(_labelRowHeightMM);
            table.Rows.HeightRule = RowHeightRule.Exactly;
            table.Borders.Visible = true;

            // Create columns
            // Label column 1
            Column column = table.AddColumn();
            column.Width = Unit.FromMillimeter(_labelWidthMM);
            column.Format.Alignment = ParagraphAlignment.Center;

            // Gap column
            column = table.AddColumn();
            column.Width = Unit.FromMillimeter(_labelColumnGapWidthMM);

            // Label column 2
            column = table.AddColumn();
            column.Width = Unit.FromMillimeter(_labelWidthMM);
            column.Format.Alignment = ParagraphAlignment.Center;

            // Gap column
            column = table.AddColumn();
            column.Width = Unit.FromMillimeter(_labelColumnGapWidthMM);

            // Label column 3
            column = table.AddColumn();
            column.Width = Unit.FromMillimeter(_labelWidthMM);
            column.Format.Alignment = ParagraphAlignment.Center;

            // Gap column
            column = table.AddColumn();
            column.Width = Unit.FromMillimeter(_labelColumnGapWidthMM);

            // Label column 4
            column = table.AddColumn();
            column.Width = Unit.FromMillimeter(_labelWidthMM);
            column.Format.Alignment = ParagraphAlignment.Center;

            // Gap column
            column = table.AddColumn();
            column.Width = Unit.FromMillimeter(_labelColumnGapWidthMM);

            // Label column 5
            column = table.AddColumn();
            column.Width = Unit.FromMillimeter(_labelWidthMM);
            column.Format.Alignment = ParagraphAlignment.Center;

            return table;
        }

        private void AddLabelItem(Cell cell, BarcodeLabelItemModel labelItem)
        {
            var para = cell.AddParagraph(labelItem.LabelText ?? "");
            para.Format.Font.Size = _textFontSize;
            para.Format.SpaceBefore = Unit.FromMillimeter(0);
            para.Format.SpaceAfter = Unit.FromMillimeter(0);

            para = cell.AddParagraph(labelItem.Price ?? "");
            para.Format.Font.Size = _priceFontSize;
            para.Format.SpaceBefore = Unit.FromMillimeter(0);
            para.Format.SpaceAfter = Unit.FromMillimeter(0);

            para = cell.AddParagraph($"*{labelItem.BarcodeText}*");
            para.Format.Font.Name = _barcodeFont;
            para.Format.Font.Size = _barcodeFontSize;
            para.Format.SpaceBefore = Unit.FromMillimeter(0);
            para.Format.SpaceAfter = Unit.FromMillimeter(0);

        }
    }
}
