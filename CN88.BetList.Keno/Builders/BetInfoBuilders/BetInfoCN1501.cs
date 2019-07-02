namespace CN88.BetList.Core.Builders.BetInfoBuilders
{
    using System;
    using Fanex.BetList.Core.Entities;

    public class BetInfoCN1501 : BaseBetInfoCN88
    {
        protected override void BuildBetId(ITicket ticket, ITicketHelper ticketHelper)
            => Template.OddsTypeAndBetId.BetId.betId = ticket.RefNo.ToString();

        protected override void BuildOdds(ITicket ticket, ITicketHelper ticketHelper, Func<object, string> getOddsTypeName)
        {
            Template.OddsTypeAndBetId.OddsType.oddsType = string.Empty;
        }

        protected override void BuildBetTypeName(ITicket ticket, ITicketHelper ticketHelper)
        {
            var choiceId = CN88KenoUtils.ParseTransDesc(ticket.TransDesc)["choiceId"];

            ticketHelper.GetKenoBetChoiceName(choiceId, out string kenoBetTypeId);

            Template.BetType.BetTypeName.betTypeName = ticketHelper.GetKenoBetTypeName(kenoBetTypeId);
        }
    }
}
