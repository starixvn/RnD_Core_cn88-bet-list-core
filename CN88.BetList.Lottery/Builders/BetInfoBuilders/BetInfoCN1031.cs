namespace CN88.BetList.Core.Builders.BetInfoBuilders
{
    using System;
    using Fanex.BetList.Core.Entities;

    public class BetInfoCN1031 : BaseBetInfoCN88
    {
        protected override void BuildBetId(ITicket ticket, ITicketHelper ticketHelper)
            => Template.OddsTypeAndBetId.BetId.betId = ticket.RefNo;

        protected override void BuildOdds(ITicket ticket, ITicketHelper ticketHelper, Func<object, string> getOddsTypeName)
        {
            Template.OddsTypeAndBetId.OddsType.oddsType = string.Empty;
        }

        protected override void BuildBetTypeName(ITicket ticket, ITicketHelper ticketHelper)
        {
            var choiceId = CN88LotteryUtils.ParseTransDesc(ticket.TransDesc)["choiceId"];

            ticketHelper.GetLotteryBetChoiceName(choiceId, out string lotteryBetTypeId);

            Template.BetType.BetTypeName.betTypeName = ticketHelper.GetLotteryBetTypeName(lotteryBetTypeId);
        }
    }
}
