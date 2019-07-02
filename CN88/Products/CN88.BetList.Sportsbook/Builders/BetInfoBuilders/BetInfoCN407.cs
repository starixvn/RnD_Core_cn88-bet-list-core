namespace CN88.BetList.Core.Builders.BetInfoBuilders
{
    using Fanex.BetList.Core.Entities;

    public class BetInfoCN407 : BaseBetInfoCN88
    {
        protected override string GetBetTypeName(ITicket ticket, ITicketHelper ticketHelper)
        {
            var parentBetTypeId = ticketHelper.GetParentIdByBetTypeId(ticket.BetTypeId);

            return ticketHelper.GetBetTypeNameById(parentBetTypeId, ticket.RefNo);
        }
    }
}