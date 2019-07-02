namespace CN88.BetList.Core.Builders.BetInfoBuilders
{
    using Fanex.BetList.Core.Entities;

    public class BaseVirtualSportsBetInfoCN88 : BaseBetInfoCN88
    {
        public override string RenderBetTypeName(ITicket ticket, ITicketHelper ticketHelper)
        {
            return GetBetTypeName(ticket, ticketHelper);
        }

        protected override void BuildBetTypeName(ITicket ticket, ITicketHelper ticketHelper)
        {
            Template.BetType.BetTypeName.betTypeName = GetBetTypeName(ticket, ticketHelper);
        }
    }
}
