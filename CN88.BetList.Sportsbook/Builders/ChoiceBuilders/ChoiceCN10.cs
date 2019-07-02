namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using System.Collections.Generic;
    using Fanex.BetList.Core.Entities;

    public class ChoiceCN10 : BaseChoiceCN88
    {
        protected override void BuildChoice(ITicket ticket, ITicketHelper ticketHelper, List<ITicketData> ticketData)
        {
            base.BuildChoice(ticket, ticketHelper, ticketData);

            Template.Match.Hide();
            Template.MatchByTeamId.Hide();
        }

        protected override void BuildBetChoice(ITicket ticket, ITicketHelper ticketHelper, List<ITicketData> ticketData)
        {
            base.BuildBetChoice(ticket, ticketHelper, ticketData);

            var teamId = ticket.HomeId == 0 ? ticket.AwayId : ticket.HomeId;

            Template.BetChoice.ChoiceName.choiceName = ticketHelper.GetTeamNameById(teamId);
        }
    }
}