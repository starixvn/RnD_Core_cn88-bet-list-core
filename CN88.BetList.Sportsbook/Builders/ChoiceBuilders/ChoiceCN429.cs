namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using CN88.BetList.Core.AppResources;
    using Fanex.BetList.Core.App_GlobalResources;
    using Fanex.BetList.Core.Constants;
    using Fanex.BetList.Core.Entities;

    /// <summary>
    /// Bet type name: Exact 2nd Half Goal
    /// </summary>
    public class ChoiceCN429 : BaseChoiceCN88
    {
        protected override void BuildChoiceName(ITicket ticket, ITicketHelper ticketHelper)
        {
            var betTeam = string.Empty;

            switch (ticket.BetTeam.ToLowerInvariant())
            {
                case BetTeamValue.NumberZero:
                    betTeam = CoreBetList.nogoal;
                    break;

                case BetTeamValue.NumberOne:
                    betTeam = CoreBetList.OneGoal;
                    break;

                case BetTeamValue.NumberTwo:
                    betTeam = CoreBetList.TwoGoals;
                    break;

                case BetTeamValue.ThreeOver:
                    betTeam = CN88SportsbookResources.ThreeOver;
                    break;

                default:
                    betTeam = string.Empty;
                    break;
            }

            Template.BetChoice.ChoiceName.choiceName = betTeam;
        }
    }
}
