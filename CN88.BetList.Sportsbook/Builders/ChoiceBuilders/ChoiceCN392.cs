namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using System.Collections.Generic;
    using Fanex.BetList.Core.App_GlobalResources;
    using Fanex.BetList.Core.Constants;
    using Fanex.BetList.Core.Entities;

    public class ChoiceCN392 : ChoiceCN4
    {
        protected override void BuildBetChoice(ITicket ticket, ITicketHelper ticketHelper, List<ITicketData> ticketData)
        {
            base.BuildBetChoice(ticket, ticketHelper, ticketData);

            var choice = ticket.BetTeam;
            var choiceName = string.Empty;

            switch (choice.ToLowerInvariant())
            {
                case BetTeamValue.HAOS:
                    choiceName = CoreBetList.HomeToWinAnyOtherScore;
                    break;
                case BetTeamValue.AAOS:
                    choiceName = CoreBetList.AwayToWinAnyOtherScore;
                    break;

                default:
                    choiceName = choice;
                    break;
            }

            Template.BetChoice.ChoiceName.choiceName = choiceName;
        }

        protected override bool IsAOS(ITicket ticket)
        {
            var betTeam = ticket.BetTeam.Trim().ToLowerInvariant();

            return !string.IsNullOrEmpty(ticket.TransDesc) && (betTeam == BetTeamValue.HAOS || betTeam == BetTeamValue.AAOS);
        }
    }
}
