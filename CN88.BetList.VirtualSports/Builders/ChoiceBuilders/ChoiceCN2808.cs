namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using System;
    using System.Collections.Generic;
    using Fanex.BetList.Core.Constants;
    using Fanex.BetList.Core.Entities;

    public class ChoiceCN2808 : ChoiceCN2807
    {
        protected override void BuildScore(ITicket ticket)
        {
            Template.Match.LiveScore.Visible = false;
        }

        protected override void BuildBetChoice(ITicket ticket, ITicketHelper ticketHelper, List<ITicketData> ticketData)
        {
            Template.BetChoiceMoreInfo.Hide();
            Template.BetChoice.ChoiceValue.Hide();

            if (ticket.BetTeam.Equals(BetTeamValue.D, StringComparison.CurrentCultureIgnoreCase))
            {
                Template.BetChoice.ChoiceName.choiceName = ticketHelper.GetResourceData(BasketballRefId, "D");
                return;
            }

            base.BuildBetChoice(ticket, ticketHelper, ticketData);
        }
    }
}
