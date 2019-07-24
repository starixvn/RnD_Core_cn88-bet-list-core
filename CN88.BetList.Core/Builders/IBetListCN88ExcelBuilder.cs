namespace CN88.BetList.Core.Builders
{
    using System;
    using System.Collections.Generic;
    using Fanex.BetList.Core.Entities;
    using NPOI.SS.UserModel;
    using NPOI.SS.Util;

    public interface IBetListCN88ExcelBuilder : IBetListCN88BaseBuilder
    {
        ICellStyle OddCellStyle { get; set; }

        ICellStyle EvenCellStyle { get; set; }

        ICellStyle OddCellStyleCenterAligned { get; set; }

        ICellStyle EvenCellStyleCenterAligned { get; set; }

        RTFHelper RTFHelper { get; set; }

        int LastContentRow { get; }

        ICellStyle CreateCellStyle();

        IFont CreateFont();

        IBetListCN88ExcelBuilder SetColumnWidth(int columnIndex, short columnWith);

        IBetListCN88ExcelBuilder BuildWorksheet(string sheetName, short numberOfColumns, short singleRowHeight = 13, bool displayGridlines = false);

        IWorkbook GetBetList();

        CellAddress AddCell(IRichTextString rtfString);

        CellAddress AddCell(IRichTextString rtfString, ICellStyle cellStyle);

        CellAddress AddMergedCell(IRichTextString rtfString, CellRangeAddress mergedRange, ICellStyle cellStyle);

        void MergeCell(CellRangeAddress mergeRange);

        void MergeCell(CellRangeAddress mergeRange, ICellStyle cellStyle);

        IBetListCN88ExcelBuilder AddChoice(ITicket ticket, ITicketHelper ticketHelper, List<ITicketData> ticketData);

        IBetListCN88ExcelBuilder AddBetInfo(ITicket ticket, ITicketHelper ticketHelper, Func<object, string> getOddsTypeName);

        IBetListCN88ExcelBuilder AddStatus(ITicket ticket, ITicketHelper ticketHelper, List<ITicketData> ticketData);
    }
}
