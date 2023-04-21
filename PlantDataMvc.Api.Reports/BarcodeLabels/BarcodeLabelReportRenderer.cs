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

        // Page Setup
        private readonly double _pageTopMargin = 10.7;
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

        private readonly List<FontInfo> _barcodeFontInfos;
        private readonly FontInfo _selectedBarcodeFontInfo;


        private readonly BarcodeLabelReportModel _reportModel;

        private readonly int _textFontSize = 11;
        private readonly int _priceFontSize = 14;
        private readonly int _barcodeFontSize = 20;

        public BarcodeLabelReportRenderer(BarcodeLabelReportModel reportModel)
        {
            _reportModel = reportModel;
            _barcodeFontInfos = new List<FontInfo>() {
                    new FontInfo("3 of 9 Barcode", 20, (char)33),           // '!'
                    new FontInfo("Free 3 of 9", 24, (char)95),              // '_'
                    new FontInfo("Libre Barcode 39", 24, (char)194),        // 'Â'
                    new FontInfo("Libre Barcode 39 Text", 24, (char)194)    // 'Â'
                };

            _selectedBarcodeFontInfo = _barcodeFontInfos.First(i => i.Name == "Libre Barcode 39");
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

            //CreateFontTestPages();

            //// Barcode test page
            //Table testTable = CreateBarcodeTestTable();
            //AddBarcodeHeaderRow(testTable);
            //AddBarcodeTestRows(testTable);


            // Create labels
            Table table = CreateLabelItemTable();

            foreach (var labelGroup in _reportModel.LabelItems)
            {
                // Create a full page for each group
                Row currentRow;

                for (int rowIndex = 0; rowIndex < _rowsPerPage; rowIndex++)
                {
                    currentRow = table.AddRow();
                    currentRow.VerticalAlignment = VerticalAlignment.Center;

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
            table.Borders.Visible = false;

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

            para = cell.AddParagraph(labelItem.Price ?? "");
            para.Format.Font.Size = _priceFontSize;
            para.Format.Font.Bold = true;

            para = cell.AddParagraph(_selectedBarcodeFontInfo.EncodedText(labelItem.BarcodeText));
            para.Format.Font.Name = _selectedBarcodeFontInfo.Name;
            para.Format.Font.Size = _selectedBarcodeFontInfo.Size;
        }

        private Table CreateBarcodeTestTable()
        {
            // Total width = 210
            var section = _report.LastSection;

            Table table = _report.LastSection.AddTable();

            // table default format
            table.Format.LineSpacingRule = LineSpacingRule.Single;
            table.Format.Font.Name = _reportFont;
            table.Format.Font.Size = _textFontSize;
            table.Rows.Height = Unit.FromMillimeter(_labelRowHeightMM);
            table.Rows.HeightRule = RowHeightRule.AtLeast;
            table.Borders.Visible = true;

            // Create columns
            // Font name column
            Column column = table.AddColumn();
            column.Width = Unit.FromMillimeter(30);
            column.Format.Alignment = ParagraphAlignment.Left;

            // Font size column
            column = table.AddColumn();
            column.Width = Unit.FromMillimeter(20);
            column.Format.Alignment = ParagraphAlignment.Left;

            // Unencoded data column
            column = table.AddColumn();
            column.Width = Unit.FromMillimeter(20);
            column.Format.Alignment = ParagraphAlignment.Left;

            // Barcode column 1
            column = table.AddColumn();
            column.Width = Unit.FromMillimeter(65);
            column.Format.Alignment = ParagraphAlignment.Left;

            // Barcode column 2
            column = table.AddColumn();
            column.Width = Unit.FromMillimeter(65);
            column.Format.Alignment = ParagraphAlignment.Left;

            return table;
        }

        private void CreateFontTestPages()
        {
            foreach (var font in _barcodeFontInfos)
            {
                CreateFontTestPage(font);
            }
        }

        private void CreateFontTestPage(FontInfo fontInfo)
        {
            var section = _report.LastSection;

            var para = section.AddParagraph(fontInfo.Name);
            para.Format.Font.Bold = true;
            para.Format.Font.Size = 20;

            para = section.AddParagraph("");
            para.Format.Font.Name = _reportFont;
            para.Format.Font.Size = _textFontSize;

            var baseFont = para.Format.Font.Clone();

            var barcodeFont = para.Format.Font.Clone();
            barcodeFont.Size = fontInfo.Size;
            barcodeFont.Name = fontInfo.Name;

            for (int i = 0; i <= 256; i++)
            {
                char c = (char)i;
                string s = $"Value: {i}, Char: {c}, Barcode: ";

                para.AddFormattedText(s, baseFont);
                para.AddFormattedText($"{c}", barcodeFont);
                para.AddFormattedText("|\t", baseFont);
            }
            section.AddPageBreak();
        }

        private void AddBarcodeHeaderRow(Table table)
        {
            var row = table.AddRow();
            row.Format.Font.Bold = true;

            var para = row.Cells[0].AddParagraph("Font Name");
            para = row.Cells[1].AddParagraph("Font Size");
            para = row.Cells[2].AddParagraph("Barcode Text");
            para = row.Cells[3].AddParagraph($"Barcode");
            para = row.Cells[4].AddParagraph($"Barcode (space subst.)");
        }

        
        private void AddBarcodeTestRows(Table table)
        {
            BarcodeLabelItemModel labelItem = new BarcodeLabelItemModel()
            {               
                BarcodeText = "38 2.5",
                LabelText = "label text",
                Price = "$2.50"
            };

            foreach (var font in _barcodeFontInfos)
            {
                AddBarcodeTestRow(table, labelItem, font);
            }
        
            _report.LastSection.AddPageBreak();
        }


        private void AddBarcodeTestRow(Table table, BarcodeLabelItemModel labelItem, FontInfo barcodeFontInfo)
        {
            var row = table.AddRow();

            var para = row.Cells[0].AddParagraph(barcodeFontInfo.Name);

            para = row.Cells[1].AddParagraph(barcodeFontInfo.Size.ToString());

            para = row.Cells[2].AddParagraph(labelItem.BarcodeText);

            para = row.Cells[3].AddParagraph($"*{labelItem.BarcodeText}*");
            para.Format.Font.Name = barcodeFontInfo.Name;
            para.Format.Font.Size = barcodeFontInfo.Size;

            var encodedText = $"*{labelItem.BarcodeText.Replace(' ', barcodeFontInfo.SpaceSubstitute)}*";
            para = row.Cells[4].AddParagraph(encodedText);
            para.Format.Font.Name = barcodeFontInfo.Name;
            para.Format.Font.Size = barcodeFontInfo.Size;
        }
    }

    internal class FontInfo
    {
        public FontInfo(string name, int size, char spaceSubstitute = ' ')
        {
            Name = name;
            Size = size;
            SpaceSubstitute = spaceSubstitute;
        }

        public string Name { get; set; }
        public int Size { get; set; }
        public char SpaceSubstitute { get; set; }

        public string EncodedText(string originalText) => $"*{originalText.Replace(' ', this.SpaceSubstitute)}*";
    }
}
