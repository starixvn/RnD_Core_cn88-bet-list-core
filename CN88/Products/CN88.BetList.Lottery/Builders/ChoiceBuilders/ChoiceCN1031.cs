namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using System.Collections.Generic;
    using Fanex.BetList.Core.Entities;

    public class ChoiceCN1031 : BaseChoiceCN88
    {
        protected override void BuildLeague(ITicket ticket, ITicketHelper ticketHelper)
        {
            string gameTypeName = ticketHelper.GetBetTypeNameById(ticket.BetTypeId);
            var gameId = CN88LotteryUtils.ParseTransDesc(ticket.TransDesc)["gameId"];

            Template.League.LeagueName.leagueName = $"{gameTypeName} [{gameId}]";
        }

        protected override void BuildMatch(ITicket ticket, ITicketHelper ticketHelper)
        {
            Template.MatchByTeamId.Hide();
            Template.Match.Hide();
        }

        protected override void BuildBetChoice(ITicket ticket, ITicketHelper ticketHelper, List<ITicketData> ticketData)
        {
            Template.BetChoiceMoreInfo.Hide();
            Template.BetChoice.ChoiceValue.Hide();

            var choiceId = CN88LotteryUtils.ParseTransDesc(ticket.TransDesc)["choiceId"];

            Template.BetChoice.ChoiceName.choiceName = ticketHelper.GetLotteryBetChoiceName(choiceId, out string lotteryBetTypeId);
        }
    }
}
