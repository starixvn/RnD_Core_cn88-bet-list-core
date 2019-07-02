namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using Fanex.BetList.Core.App_GlobalResources;
    using Fanex.BetList.Core.Constants;
    using Fanex.BetList.Core.Entities;

    /// <summary>
    /// Bet type name: Both Team To Score in 1H/ 2H
    /// </summary>
    public class ChoiceCN445 : BaseChoiceCN88
    {
        protected override void BuildChoiceName(ITicket ticket, ITicketHelper ticketHelper)
        {
            var betTeam = string.Empty;
            const string betTeamFormat = "{0}/{1}";

            switch (ticket.BetTeam.ToLowerInvariant())
            {
                case BetTeamValue.YY:
                    betTeam = string.Format(betTeamFormat, CoreBetList.lblYes, CoreBetList.lblYes);
                    break;

                case BetTeamValue.YN:
                    betTeam = string.Format(betTeamFormat, CoreBetList.lblYes, CoreBetList.lblNo);
                    break;

                case BetTeamValue.NY:
                    betTeam = string.Format(betTeamFormat, CoreBetList.lblNo, CoreBetList.lblYes);
                    break;

                case BetTeamValue.NN:
                    betTeam = string.Format(betTeamFormat, CoreBetList.lblNo, CoreBetList.lblNo);
                    break;

                default:
                    betTeam = string.Empty;
                    break;
            }

            Template.BetChoice.ChoiceName.choiceName = betTeam;
        }
    }
}
