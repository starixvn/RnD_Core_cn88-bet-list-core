namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using Fanex.BetList.Core.App_GlobalResources;
    using Fanex.BetList.Core.Constants;
    using Fanex.BetList.Core.Entities;

    /// <summary>
    /// Bet type name: Both Team Score/ Result
    /// </summary>
    public class ChoiceCN417 : BaseChoiceCN88
    {
        protected override void BuildChoiceName(ITicket ticket, ITicketHelper ticketHelper)
        {
            var betTeam = string.Empty;
            const string betTeamFormat = "{0}/{1}";

            switch (ticket.BetTeam.ToLowerInvariant())
            {
                case BetTeamValue.YH:
                    betTeam = string.Format(betTeamFormat, CoreBetList.lblYes, CoreBetList.Home);
                    break;

                case BetTeamValue.YD:
                    betTeam = string.Format(betTeamFormat, CoreBetList.lblYes, CoreBetList.draw);
                    break;

                case BetTeamValue.YA:
                    betTeam = string.Format(betTeamFormat, CoreBetList.lblYes, CoreBetList.Away);
                    break;

                case BetTeamValue.NH:
                    betTeam = string.Format(betTeamFormat, CoreBetList.lblNo, CoreBetList.Home);
                    break;

                case BetTeamValue.ND:
                    betTeam = string.Format(betTeamFormat, CoreBetList.lblNo, CoreBetList.draw);
                    break;

                case BetTeamValue.NA:
                    betTeam = string.Format(betTeamFormat, CoreBetList.lblNo, CoreBetList.Away);
                    break;

                default:
                    betTeam = string.Empty;
                    break;
            }

            Template.BetChoice.ChoiceName.choiceName = betTeam;
        }
    }
}
