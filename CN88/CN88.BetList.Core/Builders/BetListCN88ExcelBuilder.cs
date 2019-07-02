namespace CN88.BetList.Core.Builders
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using CN88.BetList.Core.Builders.BetInfoBuilders;
    using CN88.BetList.Core.Builders.ChoiceBuilders;
    using CN88.BetList.Core.Constants;
    using Fanex.BetList.Core.Entities;
    using Fanex.BetList.Core.Utils;
    using Fanex.BetList.Core.Utils.NPOIExt;
    using Fanex.BetList.Core.Utils.StringExt;
    using NPOI.HSSF.UserModel;
    using NPOI.SS.UserModel;
    using NPOI.SS.Util;

    public class BetListCN88ExcelBuilder : BetListCN88BaseBuilder, IBetListCN88ExcelBuilder, IDisposable
    {
        #region Attributes

        private IWorkbook workbook;

        private short reportColumnsNum;

        private ISheet worksheet;

        private bool isDisposed;

        private int nextCellIndex;

        #endregion Attributes

        #region Constructors

        public BetListCN88ExcelBuilder()
        {
            workbook = new HSSFWorkbook();

            isDisposed = false;

            OddCellStyle = workbook.CreateCellStyle();
            EvenCellStyle = workbook.CreateCellStyle();
            OddCellStyleCenterAligned = workbook.CreateCellStyle();
            EvenCellStyleCenterAligned = workbook.CreateCellStyle();

            nextCellIndex = -1;

            RTFHelper = new RTFHelper
            {
                NegFont = workbook.CreateFont(),
                NormalFont = workbook.CreateFont(),
                PosFont = workbook.CreateFont(),
                NegFontCrossed = workbook.CreateFont(),
                NormalFontCrossed = workbook.CreateFont(),
                PosFontCrossed = workbook.CreateFont(),
                RTFRenderer = new RtfTextRender()
            };

            InitDefaultRTFHelper();
            InitDefaultCellStyles();
        }

        #endregion Constructors

        #region Properties

        public ICellStyle OddCellStyle { get; set; }

        public ICellStyle EvenCellStyle { get; set; }

        public ICellStyle OddCellStyleCenterAligned { get; set; }

        public ICellStyle EvenCellStyleCenterAligned { get; set; }

        public RTFHelper RTFHelper { get; set; }

        public int LastContentRow => worksheet.LastRowNum;

        #endregion Properties

        #region IDisposable's Implementation

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable's Implementation

        public ICellStyle CreateCellStyle()
            => workbook.CreateCellStyle();

        public IFont CreateFont()
            => workbook.CreateFont();

        public IBetListCN88ExcelBuilder SetColumnWidth(int columnIndex, short columnWith)
        {
            worksheet.SetColumnWidth(columnIndex, columnWith);
            return this;
        }

        public IBetListCN88ExcelBuilder BuildWorksheet(string sheetName, short numberOfColumns, short singleRowHeight = 13, bool displayGridlines = false)
        {
            worksheet = workbook.CreateSheet(sheetName);
            worksheet.DisplayGridlines = displayGridlines;
            worksheet.DefaultRowHeight = singleRowHeight;
            reportColumnsNum = numberOfColumns;
            return this;
        }

        public IWorkbook GetBetList()
        {
            AdaptRowHeight();
            return workbook;
        }

        public CellAddress AddCell(IRichTextString rtfString)
        {
            nextCellIndex++;
            IRow lastRow = GetLastRow();

            if (nextCellIndex >= reportColumnsNum)
            {
                nextCellIndex = 0;
            }

            ICell lastCell;

            lastCell = lastRow.RowNum % 2 == 0
                ? lastRow.CreateCell(nextCellIndex, EvenCellStyle)
                : lastRow.CreateCell(nextCellIndex, OddCellStyle);

            lastCell.SetCellValue(rtfString);

            return new CellAddress(lastCell.RowIndex, nextCellIndex);
        }

        public CellAddress AddCell(IRichTextString rtfString, ICellStyle cellStyle)
        {
            nextCellIndex++;
            IRow lastRow = GetLastRow();

            if (nextCellIndex >= reportColumnsNum)
            {
                nextCellIndex = 0;
            }

            ICell lastCell = lastRow.CreateCell(nextCellIndex, cellStyle);

            lastCell.SetCellValue(rtfString);

            return new CellAddress(lastCell.RowIndex, nextCellIndex);
        }

        public CellAddress AddMergedCell(IRichTextString rtfString, CellRangeAddress mergedRange, ICellStyle cellStyle)
        {
            nextCellIndex++;

            if (nextCellIndex >= reportColumnsNum)
            {
                nextCellIndex = 0;
            }

            MergeCell(mergedRange);

            IRow firstRow = worksheet.GetRow(mergedRange.FirstRow);
            ICell lastCell = firstRow.GetCell(mergedRange.FirstColumn);
            lastCell.CellStyle = cellStyle;
            lastCell.SetCellValue(rtfString);

            return new CellAddress(lastCell.RowIndex, nextCellIndex);
        }

        public void MergeCell(CellRangeAddress mergeRange)
        {
            worksheet.AddMergedRegion(mergeRange);
            nextCellIndex += mergeRange.LastColumn - mergeRange.FirstColumn;
        }

        public void MergeCell(CellRangeAddress mergeRange, ICellStyle cellStyle)
        {
            worksheet.AddMergedRegion(mergeRange);

            for (int i = mergeRange.FirstRow; i <= mergeRange.LastRow; i++)
            {
                IRow mergedRow = worksheet.GetRow(i);
                if (mergedRow != null)
                {
                    mergedRow.CreateCell(mergeRange.LastColumn, cellStyle);
                }
            }

            nextCellIndex += mergeRange.LastColumn - mergeRange.FirstColumn;
        }

        public IBetListCN88ExcelBuilder AddChoice(ITicket ticket, ITicketHelper ticketHelper, List<ITicketData> ticketData)
        {
            IChoiceCN88 choiceBuilder = CreateChoiceBuilder(ticket.BetTypeId);
            List<IRichTextString> rtfChoiceList = choiceBuilder.RenderRTF(ticket, ticketHelper, ticketData, RTFHelper);

            foreach (IRichTextString rtfString in rtfChoiceList)
            {
                AddCell(rtfString);
            }

            return this;
        }

        public IBetListCN88ExcelBuilder AddBetInfo(ITicket ticket, ITicketHelper ticketHelper, Func<object, string> getOddsTypeName)
        {
            IBetInfoCN88 betInfoBuilder = CreateBetInfoBuilder(ticket.BetTypeId);
            var rtfBetInfo = betInfoBuilder.RenderRTF(ticket, ticketHelper, getOddsTypeName, RTFHelper);
            AddCell(rtfBetInfo);

            return this;
        }

        private IRow GetLastRow()
        {
            IRow lastRow = worksheet.GetRow(worksheet.LastRowNum);
            if (lastRow == null || lastRow.Cells.Count == reportColumnsNum || nextCellIndex >= reportColumnsNum)
            {
                lastRow = AddNewRow();
            }

            return lastRow;
        }

        private IRow AddNewRow()
        {
            int newRowIndex = worksheet.LastRowNum;

            if (IsSheetHasRows())
            {
                newRowIndex += 1;
            }

            IRow newRow = worksheet.CreateRow(newRowIndex);
            return newRow;
        }

        private bool IsSheetHasRows()
        {
            return worksheet.GetRow(worksheet.LastRowNum) != null;
        }

        /// <summary>
        /// Adapts the height of the row.
        /// </summary>
        private void AdaptRowHeight()
        {
            IEnumerator rowEnum = worksheet.GetRowEnumerator();

            while (rowEnum.MoveNext())
            {
                IRow currentRow = rowEnum.Current as HSSFRow;
                int totalLineBreaks = 0;
                foreach (ICell cell in currentRow.Cells)
                {
                    totalLineBreaks = Math.Max(totalLineBreaks, cell.StringCellValue.GetLineBreakTotal());
                }

                currentRow.HeightInPoints = totalLineBreaks * worksheet.DefaultRowHeight;
            }
        }

        private void InitDefaultRTFHelper()
        {
            RTFHelper.PosFont.Boldweight = (short)FontBoldWeight.Bold;
            RTFHelper.PosFontCrossed.Boldweight = (short)FontBoldWeight.Bold;

            RTFHelper.NegFont.Boldweight = (short)FontBoldWeight.Bold;
            RTFHelper.NegFontCrossed.Boldweight = (short)FontBoldWeight.Bold;

            RTFHelper.NormalFont.Boldweight = (short)FontBoldWeight.Normal;
            RTFHelper.NormalFontCrossed.Boldweight = (short)FontBoldWeight.Normal;

            RTFHelper.NegFont.FontName = ExcelStyleConstant.FontName;
            RTFHelper.NegFontCrossed.FontName = ExcelStyleConstant.FontName;
            RTFHelper.NormalFont.FontName = ExcelStyleConstant.FontName;
            RTFHelper.NormalFontCrossed.FontName = ExcelStyleConstant.FontName;
            RTFHelper.PosFont.FontName = ExcelStyleConstant.FontName;
            RTFHelper.PosFontCrossed.FontName = ExcelStyleConstant.FontName;

            RTFHelper.NegFont.FontHeightInPoints = ExcelStyleConstant.FontHeight;
            RTFHelper.NegFontCrossed.FontHeightInPoints = ExcelStyleConstant.FontHeight;
            RTFHelper.NormalFont.FontHeightInPoints = ExcelStyleConstant.FontHeight;
            RTFHelper.NormalFontCrossed.FontHeightInPoints = ExcelStyleConstant.FontHeight;
            RTFHelper.PosFont.FontHeightInPoints = ExcelStyleConstant.FontHeight;
            RTFHelper.PosFontCrossed.FontHeightInPoints = ExcelStyleConstant.FontHeight;

            RTFHelper.NormalFontCrossed.IsStrikeout = true;
            RTFHelper.PosFontCrossed.IsStrikeout = true;
            RTFHelper.NegFontCrossed.IsStrikeout = true;

            RTFHelper.NegFont.Color = (short)FontColor.Red;
            RTFHelper.NegFontCrossed.Color = (short)FontColor.Red;
        }

        /// <summary>
        /// Initialize the default cell styles.
        /// </summary>
        private void InitDefaultCellStyles()
        {
            OddCellStyle.Alignment = HorizontalAlignment.Left;
            EvenCellStyle.Alignment = HorizontalAlignment.Left;

            // There's probably a bug in the VerticalAlignment enum of NPOI 2.0.6.0,
            // where VerticalAlignment.Top is actually resulting in middle alignment,
            // and VerticalAlignment.Bottom is in fact top alignment.
            OddCellStyle.VerticalAlignment = VerticalAlignment.Bottom;
            EvenCellStyle.VerticalAlignment = VerticalAlignment.Bottom;
            OddCellStyle.FillPattern = FillPattern.SolidForeground;
            EvenCellStyle.FillPattern = FillPattern.SolidForeground;

            OddCellStyle.BorderTop = BorderStyle.Thin;
            OddCellStyle.BorderRight = BorderStyle.Thin;
            OddCellStyle.BorderBottom = BorderStyle.Thin;
            OddCellStyle.BorderLeft = BorderStyle.Thin;

            EvenCellStyle.BorderTop = BorderStyle.Thin;
            EvenCellStyle.BorderRight = BorderStyle.Thin;
            EvenCellStyle.BorderBottom = BorderStyle.Thin;
            EvenCellStyle.BorderLeft = BorderStyle.Thin;

            OddCellStyle.TopBorderColor = ExcelStyleConstant.BorderColor;
            OddCellStyle.RightBorderColor = ExcelStyleConstant.BorderColor;
            OddCellStyle.BottomBorderColor = ExcelStyleConstant.BorderColor;
            OddCellStyle.LeftBorderColor = ExcelStyleConstant.BorderColor;
            EvenCellStyle.TopBorderColor = ExcelStyleConstant.BorderColor;
            EvenCellStyle.RightBorderColor = ExcelStyleConstant.BorderColor;
            EvenCellStyle.BottomBorderColor = ExcelStyleConstant.BorderColor;
            EvenCellStyle.LeftBorderColor = ExcelStyleConstant.BorderColor;

            OddCellStyle.FillForegroundColor = ExcelStyleConstant.OddForegroundColor;
            OddCellStyle.FillBackgroundColor = ExcelStyleConstant.OddBackgroundColor;

            EvenCellStyle.FillForegroundColor = ExcelStyleConstant.EvenForegroundColor;
            EvenCellStyle.FillBackgroundColor = ExcelStyleConstant.EvenBackgroundColor;

            OddCellStyle.SetFont(RTFHelper.NormalFont);
            EvenCellStyle.SetFont(RTFHelper.NormalFont);

            OddCellStyleCenterAligned.CloneStyleFrom(OddCellStyle);
            OddCellStyleCenterAligned.Alignment = HorizontalAlignment.Center;
            OddCellStyleCenterAligned.SetFont(RTFHelper.NormalFont);

            EvenCellStyleCenterAligned.CloneStyleFrom(EvenCellStyle);
            EvenCellStyleCenterAligned.Alignment = HorizontalAlignment.Center;
            EvenCellStyleCenterAligned.SetFont(RTFHelper.NormalFont);

            // For line-breaks in MS Office
            OddCellStyle.WrapText = true;
            EvenCellStyle.WrapText = true;
            EvenCellStyleCenterAligned.WrapText = true;
            OddCellStyleCenterAligned.WrapText = true;
        }

        #region IDisposable's Implementation

        protected virtual void Dispose(bool disposing)
        {
            if (!isDisposed)
            {
                if (!disposing && workbook != null)
                {
                    workbook = null;
                }

                isDisposed = true;
            }
        }

        ~BetListCN88ExcelBuilder()
        {
            Dispose(false);
        }

        #endregion IDisposable's Implementation
    }
}
