namespace Fanex.BetList.Example.Extension.BetListExcelBuilderExt
{
    using CN88.BetList.Core.Builders;
    using Fanex.BetList.Core.Entities;
    using NPOI.HSSF.UserModel;
    using NPOI.SS.UserModel;

    public static class BetListCN88ExcelBuilderExt
    {
        /// <summary>
        /// Adds the no.
        /// </summary>
        /// <param name="factory">The factory.</param>
        /// <param name="index">The index.</param>
        /// <returns>BetListExcelBuilder object.</returns>
        public static BetListCN88ExcelBuilder AddNo(this BetListCN88ExcelBuilder factory, int index)
        {
            IRichTextString rtfNo = new HSSFRichTextString(index.ToString());
            factory.AddCell(rtfNo);
            return factory;
        }

        /// <summary>
        /// Adds the member.
        /// </summary>
        /// <param name="factory">The factory.</param>
        /// <param name="ticket">The ticket.</param>
        /// <param name="ticketHelper">The ticket helper.</param>
        /// <returns>BetListExcelBuilder object.</returns>
        public static BetListCN88ExcelBuilder AddUsername(this BetListCN88ExcelBuilder factory, ITicket ticket, ITicketHelper ticketHelper)
        {
            IRichTextString rtfMember = new HSSFRichTextString(ticket.UserName);
            factory.AddCell(rtfMember, ticketHelper.Index % 2 == 0 ? factory.OddCellStyleCenterAligned : factory.EvenCellStyleCenterAligned);

            return factory;
        }
    }
}