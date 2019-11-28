namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using Fanex.BetList.Core.App_GlobalResources;
    using Fanex.BetList.Core.Constants;
    using Fanex.BetList.Core.Entities;

    public class ChoiceCN408 : BaseChoiceCN88
    {
        protected override void BuildChoiceName(ITicket ticket, ITicketHelper ticketHelper)
        {
            var betTeam = string.Empty;
            const string betTeamFormat = "{0} {1}";

            switch (ticket.BetTeam.ToLowerInvariant())
            {
                case BetTeamValue.H1:
                    betTeam = string.Format(betTeamFormat, CoreBetList.Home, CoreBetList.ToWinByOneGoal);
                    break;

                case BetTeamValue.H2:
                    betTeam = string.Format(betTeamFormat, CoreBetList.Home, CoreBetList.ToWinByTwoGoals);
                    break;

                case BetTeamValue.H3:
                    betTeam = string.Format(betTeamFormat, CoreBetList.Home, CoreBetList.ToWinByThreeUpGoals);
                    break;

                case BetTeamValue.D:
                    betTeam = CoreBetList.ScoreDraw;
                    break;

                case BetTeamValue.A1:
                    betTeam = string.Format(betTeamFormat, CoreBetList.Away, CoreBetList.ToWinByOneGoal);
                    break;

                case BetTeamValue.A2:
                    betTeam = string.Format(betTeamFormat, CoreBetList.Away, CoreBetList.ToWinByTwoGoals);
                    break;

                case BetTeamValue.A3:
                    betTeam = string.Format(betTeamFormat, CoreBetList.Away, CoreBetList.ToWinByThreeUpGoals);
                    break;

                case BetTeamValue.NG:
                    betTeam = CoreBetList.NoGoal408;
                    break;

                default:
                    betTeam = string.Empty;
                    break;
            }

            Template.BetChoice.ChoiceName.choiceName = betTeam;
        }
    }
}
