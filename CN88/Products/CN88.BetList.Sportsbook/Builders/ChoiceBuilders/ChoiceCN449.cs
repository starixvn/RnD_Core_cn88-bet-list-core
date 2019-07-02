namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using Fanex.BetList.Core.App_GlobalResources;
    using Fanex.BetList.Core.Constants;
    using Fanex.BetList.Core.Entities;

    /// <summary>
    /// PH AIO Phase 3 - Double Chance &amp; Total Goals.
    /// </summary>
    public class ChoiceCN449 : ChoiceCN3
    {
        private const int ExpectedBetTeamLength = 3;

        protected override void CalculateChoiceName(ITicket ticket, ITicketHelper ticketHelper)
        {
            string betTeam = ticket.BetTeam?.ToLowerInvariant() ?? string.Empty;

            if (betTeam.Length == ExpectedBetTeamLength)
            {
                string firstChanceChoice = MapDoubleChanceChoice(betTeam[0]);
                string secondChanceChoice = MapDoubleChanceChoice(betTeam[1]);
                string overUnderChoice = MapOverUnderChoice(betTeam[2]);

                if (!string.IsNullOrEmpty(firstChanceChoice)
                    && !string.IsNullOrEmpty(secondChanceChoice)
                    && !string.IsNullOrEmpty(overUnderChoice))
                {
                    betTeam = $"{firstChanceChoice}/{secondChanceChoice} & {overUnderChoice}";
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

        private static string MapOverUnderChoice(char indicator)
        {
            switch (indicator.ToString())
            {
                case BetTeamValue.O:
                    return CoreBetList.over;

                case BetTeamValue.U:
                    return CoreBetList.under;

                default:
                    return string.Empty;
            }
        }
    }
}