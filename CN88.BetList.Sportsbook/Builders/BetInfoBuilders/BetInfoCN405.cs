namespace CN88.BetList.Core.Builders.BetInfoBuilders
{
    using Fanex.BetList.Core.Entities;

    public class BetInfoCN405 : BaseBetInfoCN88
    {
        protected override string GetBetTypeName(ITicket ticket, ITicketHelper ticketHelper)
            => ticketHelper.GetBetTypeNameById(ticket.BetTypeId, ticket.RefNo);
    }
}