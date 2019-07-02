namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using Fanex.BetList.Core.App_GlobalResources;
    using Fanex.BetList.Core.Constants;
    using Fanex.BetList.Core.Entities;

    /// <summary>
    /// Bet Type: First Half Result/Total Goal - 143.
    /// </summary>
    public class ChoiceCN143 : ChoiceCN3
    {
        protected override void CalculateChoiceName(ITicket ticket, ITicketHelper ticketHelper)
        {
            var betTeam = ticket.BetTeam.ToLowerInvariant();

            // Bet team pattern length is always 2
            if (betTeam.Length == 2)
            {
                var totalGoal =
                    betTeam[1].ToString() == BetTeamValue.O
                    ? CoreBetList.over
                    : CoreBetList.under;
                var teamName = string.Empty;

                switch (betTeam[0])
                {
                    case 'h':
                        teamName = CoreBetList.Home;
                        break;

                    case 'a':
                        teamName = CoreBetList.Away;
                        break;

                    case 'd':
                        teamName = CoreBetList.draw;
                        break;

                    default:
                        teamName = string.Empty;
                        break;
                }

                Template.BetChoice.ChoiceName.choiceName = $"{teamName}/{totalGoal}";
            }
        }
    }
}