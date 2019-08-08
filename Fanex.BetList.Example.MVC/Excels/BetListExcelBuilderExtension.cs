namespace Fanex.BetList.Example.MVC.Excels
{
    using System.Collections.Generic;
    using CN88.BetList.Core.Builders;
    using Fanex.BetList.Core.Builder;
    using Fanex.BetList.Core.Entities;
    using Fanex.BetList.Example.MVC.Helpers;
    using NPOI.HSSF.UserModel;

    public static class BetListExcelBuilderExtension
    {
        public static BetListCN88ExcelBuilder AddStatus(
            BetListCN88ExcelBuilder builder,
            ITicket ticket,
            ITicketHelper ticketHelper,
            List<ITicketData> ticketData)
        {
            var b = new BetListExcelBuilder();
            var cellValue = b.CreateStatusBuilder(ticket.BetTypeId)
                    .RenderRTF(ticket, ticketHelper, null, false, builder.RTFHelper);
            var rtfStatus = new HSSFRichTextString(cellValue.String);
            rtfStatus.ApplyFont(BetListHelpers.IsInvalidTicket(ticket) ? builder.RTFHelper.NegFont : builder.RTFHelper.NormalFont);

            builder.AddCell(rtfStatus);

            return builder;
        }
    }
}
