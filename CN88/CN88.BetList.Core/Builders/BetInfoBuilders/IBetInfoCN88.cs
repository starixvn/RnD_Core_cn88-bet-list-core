namespace CN88.BetList.Core.Builders.BetInfoBuilders
{
    using System;
    using CN88.BetList.Core.Templates;
    using Fanex.BetList.Core.Entities;
    using NPOI.SS.UserModel;

    public interface IBetInfoCN88
    {
        BetInfoCN88_Template Template { get; }

        BetInfoCN88_Template Render(ITicket ticket, ITicketHelper ticketHelper, Func<object, string> getOddsTypeName);

        IRichTextString RenderRTF(ITicket ticket, ITicketHelper ticketHelper, Func<object, string> getOddsTypeName, RTFHelper rtfHelper);

        string RenderBetTypeName(ITicket ticket, ITicketHelper ticketHelper);
    }
}
