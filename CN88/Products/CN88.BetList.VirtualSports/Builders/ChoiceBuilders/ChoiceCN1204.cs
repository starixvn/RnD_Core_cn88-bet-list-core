namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using System.Collections.Generic;
    using Fanex.BetList.Core.App_GlobalResources;
    using Fanex.BetList.Core.Constants;
    using Fanex.BetList.Core.Entities;

    public class ChoiceCN1204 : BaseVirtualSportsChoiceCN88
    {
        protected override void BuildBetChoice(ITicket ticket, ITicketHelper ticketHelper, List<ITicketData> ticketData)
        {
            Template.BetChoiceMoreInfo.Hide();

            string choice = ticket.BetTeam;

            if (BetTeamValue.FiveZero == choice || BetTeamValue.ZeroFive == choice)
            {
                choice += " " + CoreBetList.Up;
            }

            Template.BetChoice.ChoiceName.choiceName = choice;
            Template.BetChoice.ChoiceValue.Hide();
        }
    }
}
