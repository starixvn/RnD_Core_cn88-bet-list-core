namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using Fanex.BetList.Core.App_GlobalResources;
    using Fanex.BetList.Core.Constants;
    using Fanex.BetList.Core.Entities;

    /// <summary>
    /// Both/One/Neither team to score.
    /// </summary>
    public class ChoiceCN26 : BaseChoiceCN88
    {
        protected override void BuildChoiceName(ITicket ticket, ITicketHelper ticketHelper)
        {
            var betTeam = string.Empty;

            switch (ticket.BetTeam?.ToLowerInvariant().ToLowerInvariant())
            {
                case BetTeamValue.B:
                    betTeam = CoreBetList.lblBoth;
                    break;

                case BetTeamValue.O:
                    betTeam = CoreBetList.lblOne;
                    break;

                case BetTeamValue.N:
                    betTeam = CoreBetList.nogoal;
                    break;

                default:
                    betTeam = string.Empty;
                    break;
            }

            Template.BetChoice.ChoiceName.choiceName = betTeam;
        }
    }
}
