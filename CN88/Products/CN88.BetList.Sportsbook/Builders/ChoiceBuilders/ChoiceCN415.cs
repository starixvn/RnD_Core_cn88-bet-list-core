namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using CN88.BetList.Core.AppResources;
    using Fanex.BetList.Core.App_GlobalResources;
    using Fanex.BetList.Core.Constants;
    using Fanex.BetList.Core.Entities;

    public class ChoiceCN415 : BaseChoiceCN88
    {
        protected override void BuildChoiceName(ITicket ticket, ITicketHelper ticketHelper)
        {
            var betTeam = string.Empty;
            const string betTeamFormat = "{0}/{1}";

            switch (ticket.BetTeam.ToLowerInvariant())
            {
                case BetTeamValue.HH:
                    betTeam = string.Format(betTeamFormat, CoreBetList.Home, CoreBetList.Home);
                    break;

                case BetTeamValue.DH:
                    betTeam = string.Format(betTeamFormat, CoreBetList.draw, CoreBetList.Home);
                    break;

                case BetTeamValue.HA:
                    betTeam = string.Format(betTeamFormat, CoreBetList.Home, CoreBetList.Away);
                    break;

                case BetTeamValue.AH:
                    betTeam = string.Format(betTeamFormat, CoreBetList.Away, CoreBetList.Home);
                    break;

                case BetTeamValue.DA:
                    betTeam = string.Format(betTeamFormat, CoreBetList.draw, CoreBetList.Away);
                    break;

                case BetTeamValue.AA:
                    betTeam = string.Format(betTeamFormat, CoreBetList.Away, CoreBetList.Away);
                    break;

                case BetTeamValue.NO:
                    betTeam = CN88Resources.none;
                    break;

                default:
                    betTeam = string.Empty;
                    break;
            }

            Template.BetChoice.ChoiceName.choiceName = betTeam;
        }
    }
}
