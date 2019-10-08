namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using Fanex.BetList.Core.App_GlobalResources;
    using Fanex.BetList.Core.Constants;
    using Fanex.BetList.Core.Entities;

    public class ChoiceCN711 : BaseChoiceCN88
    {
        public const string BadmintonWinningMarginRefId = "WMBadminton";

        protected override void BuildChoiceName(ITicket ticket, ITicketHelper ticketHelper)
        {
            const int minimumBetTeamLengthRequired = 3;
            var standardizedBetTeam = ticket.BetTeam.Trim().ToLowerInvariant();

            Template.BetChoice.ChoiceName.choiceName = string.Empty;
            if (standardizedBetTeam.Length < minimumBetTeamLengthRequired)
            {
                return;
            }

            var winningMargin = standardizedBetTeam.Substring(1);
            var betTeamPattern = ticketHelper.GetResourceData(BadmintonWinningMarginRefId, winningMargin);
            if (string.IsNullOrEmpty(betTeamPattern))
            {
                return;
            }

            string selection;
            switch (standardizedBetTeam[0].ToString())
            {
                case BetTeamValue.A:
                    selection = CoreBetList.Away;
                    break;

                case BetTeamValue.H:
                    selection = CoreBetList.Home;
                    break;

                default:
                    selection = string.Empty;
                    break;
            }

            if (string.IsNullOrEmpty(selection))
            {
                return;
            }

            Template.BetChoice.ChoiceName.choiceName = string.Format(betTeamPattern, selection);
        }
    }
}
