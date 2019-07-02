namespace CN88.BetList.Core.Builders.BetInfoBuilders
{
    using Fanex.BetList.Core.Entities;

    public class BetInfoCN9001 : BaseBetInfoCN88
    {
        protected override string GetBetTypeName(ITicket ticket, ITicketHelper ticketHelper)
        {
            return ticketHelper.GetBetTypeNameById(ticket.BetTypeId, ticket.RefNo, ticket.BetId, ticket.BetCheck);
        }
    }
}