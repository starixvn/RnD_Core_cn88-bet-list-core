namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using System;
    using Fanex.BetList.Core.App_GlobalResources;
    using Fanex.BetList.Core.Constants;
    using Fanex.BetList.Core.Entities;

    public class ChoiceCN391 : BaseChoiceCN88
    {
        private const string GoalIndicator = "g";

        protected override void BuildChoiceName(ITicket ticket, ITicketHelper ticketHelper)
        {
            var betTeam = ticket.BetTeam.Trim().ToLowerInvariant();

            var betChoice = string.Empty;
            switch (betTeam)
            {
                case BetTeamValue.G4:
                    betChoice = CoreBetList.ZeroToFour;
                    break;
                case BetTeamValue.G9Over:
                    betChoice = CoreBetList.NineAndOver;
                    break;
                default:
                    betChoice = IsValidBetTeam(betTeam) ? betTeam.Substring(GoalIndicator.Length) : string.Empty;
                    break;
            }

            Template.BetChoice.ChoiceName.choiceName = betChoice;
        }

        private static bool IsValidBetTeam(string betTeam)
        {
            const int minLengthRequired = 2;

            return betTeam.Length >= minLengthRequired && betTeam.StartsWith(GoalIndicator, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
