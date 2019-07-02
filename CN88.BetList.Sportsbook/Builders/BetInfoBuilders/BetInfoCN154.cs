namespace CN88.BetList.Core.Builders.BetInfoBuilders
{
    using Fanex.BetList.Core.Entities;

    public class BetInfoCN154 : BaseBetInfoCN88
    {
        protected override string GetBetTypeName(ITicket ticket, ITicketHelper ticketHelper)
            => ticketHelper.GetBetTypeNameById(ticket.BetTypeId, ticket.RefNo, ticket.BetId, ticket.BetCheck);
    }
}