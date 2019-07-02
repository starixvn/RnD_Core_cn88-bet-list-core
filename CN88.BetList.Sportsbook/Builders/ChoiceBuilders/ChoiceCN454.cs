namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using Fanex.BetList.Core.App_GlobalResources;
    using Fanex.BetList.Core.Constants;
    using Fanex.BetList.Core.Entities;

    /// <summary>
    /// PH AIO Phase 3 - Double Chance &amp; First Team To Score.
    /// </summary>
    public class ChoiceCN454 : BaseChoiceCN88
    {
        private const int ExpectedBetTeamMaxLength = 3;

        protected override void BuildChoiceName(ITicket ticket, ITicketHelper ticketHelper)
        {
            string betTeam = ticket.BetTeam?.ToLowerInvariant() ?? string.Empty;

            if (betTeam == BetTeamValue.NG)
            {
                betTeam = CoreBetList.NoGoal14;
            }

            if (betTeam.Length == ExpectedBetTeamMaxLength)
            {
                string firstChanceChoice = MapDoubleChanceChoice(betTeam[0]);
                string secondChanceChoice = MapDoubleChanceChoice(betTeam[1]);
                string firstTeamToScoreChoice = MapFirstTeamToGoalChoice(betTeam[2]);

                if (!string.IsNullOrEmpty(firstChanceChoice)
                    && !string.IsNullOrEmpty(secondChanceChoice)
                    && !string.IsNullOrEmpty(firstTeamToScoreChoice))
                {
                    betTeam = $"{firstChanceChoice}/{secondChanceChoice} & {firstTeamToScoreChoice}";
                }
            }

            Template.BetChoice.ChoiceName.choiceName = betTeam;
        }

        private static string MapDoubleChanceChoice(char indicator)
        {
            switch (indicator.ToString())
            {
                case BetTeamValue.NumberOne:
                    return CoreBetList.Home;

                case BetTeamValue.NumberTwo:
                    return CoreBetList.Away;

                case BetTeamValue.X:
                    return CoreBetList.draw;

                default:
                    return string.Empty;
            }
        }

        private static string MapFirstTeamToGoalChoice(char indicator)
        {
            switch (indicator.ToString())
            {
                case BetTeamValue.H:
                    return CoreBetList.Home;

                case BetTeamValue.A:
                    return CoreBetList.Away;

                default:
                    return string.Empty;
            }
        }
    }
}