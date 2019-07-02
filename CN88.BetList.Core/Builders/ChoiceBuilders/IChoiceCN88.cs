namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using System.Collections.Generic;
    using CN88.BetList.Core.Templates;
    using Fanex.BetList.Core.Entities;
    using NPOI.SS.UserModel;

    public interface IChoiceCN88
    {
        ChoiceCN88_Template Template { get; set; }

        ChoiceCN88_Template Render(ITicket ticket, ITicketHelper ticketHelper, List<ITicketData> ticketData);

        List<IRichTextString> RenderRTF(ITicket ticket, ITicketHelper ticketHelper, List<ITicketData> ticketData, RTFHelper rtfHelper);
    }
}
