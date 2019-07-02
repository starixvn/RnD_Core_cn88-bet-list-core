namespace CN88.BetList.Core.Builders
{
    using System;
    using System.Collections.Generic;
    using CN88.BetList.Core.Templates;
    using Fanex.BetList.Core.Entities;

    public interface IBetListCN88HtmlBuilder : IBetListCN88BaseBuilder
    {
        IBetListCN88HtmlBuilder Append(string content);

        IBetListCN88HtmlBuilder AddChoice(
                        ITicket ticket,
                        ITicketHelper ticketHelper,
                        List<ITicketData> ticketData,
                        string openTag,
                        string closeTag,
                        bool isShowScoreMap);

        string BuildChoice(ITicket ticket, ITicketHelper ticketHelper, List<ITicketData> ticketData);

        ChoiceCN88_Template BuildChoiceBlock(ITicket ticket, ITicketHelper ticketHelper, List<ITicketData> ticketData);

        IBetListCN88HtmlBuilder AddBetInfo(
            ITicket ticket,
            ITicketHelper ticketHelper,
            Func<object, string> getOddsTypeName,
            string openTag,
            string closeTag);

        string BuildBetInfo(ITicket ticket, ITicketHelper ticketHelper, Func<object, string> getOddsTypeName);

        BetInfoCN88_Template BuildBetInfoBlock(ITicket ticket, ITicketHelper ticketHelper, Func<object, string> getOddsTypeName);
    }
}