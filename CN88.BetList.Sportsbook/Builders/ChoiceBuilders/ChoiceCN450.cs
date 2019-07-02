namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using Fanex.BetList.Core.App_GlobalResources;
    using Fanex.BetList.Core.Constants;
    using Fanex.BetList.Core.Entities;

    /// <summary>
    /// PH AIO Phase 3 - Odd/Even &amp; Total Goals.
    /// </summary>
    public class ChoiceCN450 : ChoiceCN3
    {
        private const int ExpectedBetTeamLength = 2;

        protected override void CalculateChoiceName(ITicket ticket, ITicketHelper ticketHelper)
        {
            string betTeam = ticket.BetTeam?.ToLowerInvariant() ?? string.Empty;

            if (betTeam.Length == ExpectedBetTeamLength)
            {
                string oddEvenChoice = MapOddEvenChoice(betTeam[0]);
                string overUnderChoice = MapOverUnderChoice(betTeam[1]);

                if (!string.IsNullOrEmpty(oddEvenChoice) && !string.IsNullOrEmpty(overUnderChoice))
                {
                    betTeam = $"{oddEvenChoice} & {overUnderChoice}";
                }
            }

            Template.BetChoice.ChoiceName.choiceName = betTeam;
        }

        private static string MapOddEvenChoice(char indicator)
        {
            switch (indicator.ToString())
            {
                case BetTeamValue.O:
                    return CoreBetList.odd;

                case BetTeamValue.E:
                    return CoreBetList.even;

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