namespace CN88.BetList.Core.Builders.BetInfoBuilders
{
    using CN88.BetList.Core.AppResources;
    using Fanex.BetList.Core.App_GlobalResources;
    using Fanex.BetList.Core.Constants;
    using Fanex.BetList.Core.Entities;

    public class BetInfoCN85 : BetInfoCN81
    {
        protected override string GetBetTypeName(ITicket ticket, ITicketHelper ticketHelper)
        {
            var betTypeName = ticketHelper.GetBetTypeNameById(ticket.BetTypeId, ticket.RefNo);
            var result = !ticket.IsLive
                   ? $"{CoreBetList.ft}. {betTypeName}"
                   : $"{CN88NumberGameLang.next}{HtmlCharacters.NoneBreakingSpace}{betTypeName}";

            return result;
        }
    }
}
