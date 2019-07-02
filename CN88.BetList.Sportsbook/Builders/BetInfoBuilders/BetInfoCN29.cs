namespace CN88.BetList.Core.Builders.BetInfoBuilders
{
    using Fanex.BetList.Core.Entities;

    public class BetInfoCN29 : BaseBetInfoCN88
    {
        private const string RefId = "ComboParlay";
        private const string ResourceId = "LuckyBet";
        private const int MixParlayBetTypeId = 9;

        protected override string GetBetTypeName(ITicket ticket, ITicketHelper ticketHelper)
        {
            if (ticket.BetTeam == "1")
            {
                return ticketHelper.GetBetTypeNameById(MixParlayBetTypeId);
            }

            var bettypeName = ticketHelper.GetBetTypeNameById(ticket.BetTypeId);

            if (ticket.BetCheck == ticket.BetTeam && ticket.Handicap1 == 0)
            {
                bettypeName += " " + ticketHelper.GetResourceData(RefId, ResourceId);
            }

            return bettypeName;
        }
    }
}