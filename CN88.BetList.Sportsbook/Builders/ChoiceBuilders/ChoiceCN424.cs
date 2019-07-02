namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using Fanex.BetList.Core.App_GlobalResources;
    using Fanex.BetList.Core.Constants;
    using Fanex.BetList.Core.Entities;

    /// <summary>
    /// Bet type name: First Goal Method
    /// </summary>
    public class ChoiceCN424 : BaseChoiceCN88
    {
        protected override void BuildChoiceName(ITicket ticket, ITicketHelper ticketHelper)
        {
            var betTeam = string.Empty;

            switch (ticket.BetTeam.ToLowerInvariant())
            {
                case BetTeamValue.S:
                    betTeam = CoreBetList.Shot;
                    break;

                case BetTeamValue.H:
                    betTeam = CoreBetList.Header;
                    break;

                case BetTeamValue.P:
                    betTeam = CoreBetList.Penalty;
                    break;

                case BetTeamValue.FK:
                    betTeam = CoreBetList.FreeKick;
                    break;

                case BetTeamValue.OG:
                    betTeam = CoreBetList.OwnGoal;
                    break;

                case BetTeamValue.NG:
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