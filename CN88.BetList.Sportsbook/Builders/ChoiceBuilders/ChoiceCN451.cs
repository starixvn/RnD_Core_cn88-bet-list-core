namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using Fanex.BetList.Core.App_GlobalResources;
    using Fanex.BetList.Core.Constants;
    using Fanex.BetList.Core.Entities;

    /// <summary>
    /// PH AIO Phase 3 - Both Teams to Score / Double Chance.
    /// </summary>
    public class ChoiceCN451 : BaseChoiceCN88
    {
        private const int ExpectedBetTeamLength = 3;

        protected override void BuildChoiceName(ITicket ticket, ITicketHelper ticketHelper)
        {
            string betTeam = ticket.BetTeam?.ToLowerInvariant() ?? string.Empty;

            if (betTeam.Length == ExpectedBetTeamLength)
            {
                string yesNoChoice = MapYesNoChoice(betTeam[0]);
                string firstChanceChoice = MapDoubleChanceChoice(betTeam[1]);
                string secondChanceChoice = MapDoubleChanceChoice(betTeam[2]);

                if (!string.IsNullOrEmpty(yesNoChoice)
                    && !string.IsNullOrEmpty(firstChanceChoice)
                    && !string.IsNullOrEmpty(secondChanceChoice))
                {
                    betTeam = $"{yesNoChoice} & {firstChanceChoice}/{secondChanceChoice}";
                }
            }

            Template.BetChoice.ChoiceName.choiceName = betTeam;
        }

        private static string MapYesNoChoice(char indicator)
        {
            switch (indicator.ToString())
            {
                case BetTeamValue.Y:
                    return CoreBetList.lblYes;

                case BetTeamValue.N:
                    return CoreBetList.lblNo;

                default:
                    return string.Empty;
            }
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
    }
}