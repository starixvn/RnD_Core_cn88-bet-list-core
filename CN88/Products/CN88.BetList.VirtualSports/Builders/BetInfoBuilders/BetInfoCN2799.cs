namespace CN88.BetList.Core.Builders.BetInfoBuilders
{
    using System;
    using Fanex.BetList.Core.Entities;

    public class BetInfoCN2799 : BaseVirtualSportsBetInfoCN88
    {
        protected override void BuildOdds(ITicket ticket, ITicketHelper ticketHelper, Func<object, string> getOddsTypeName)
        {
            Template.OddsTypeAndBetId.OddsType.oddsType = string.Empty;
        }
    }
}
