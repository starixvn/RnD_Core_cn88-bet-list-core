namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using Fanex.BetList.Core.App_GlobalResources;
    using Fanex.BetList.Core.Constants;
    using Fanex.BetList.Core.Entities;

    public class ChoiceCN397 : BaseChoiceCN88
    {
        protected override void BuildChoiceName(ITicket ticket, ITicketHelper ticketHelper)
        {
            switch (ticket.BetTeam.ToLowerInvariant())
            {
                case BetTeamValue.H1:
                    Template.BetChoice.ChoiceName.choiceName = $"{CoreBetList.Home} {CoreBetList.ToWinByOneGoal}";
                    break;

                case BetTeamValue.H2:
                    Template.BetChoice.ChoiceName.choiceName = $"{CoreBetList.Home} {CoreBetList.ToWinByTwoGoals}";
                    break;

                case BetTeamValue.H3Over:
                    Template.BetChoice.ChoiceName.choiceName = $"{CoreBetList.Home} {CoreBetList.ToWinByThreeUpGoals}";
                    break;

                case BetTeamValue.D:
                    Template.BetChoice.ChoiceName.choiceName = CoreBetList.ScoreDraw;
                    break;

                case BetTeamValue.A1:
                    Template.BetChoice.ChoiceName.choiceName = $"{CoreBetList.Away} {CoreBetList.ToWinByOneGoal}";
                    break;

                case BetTeamValue.A2:
                    Template.BetChoice.ChoiceName.choiceName = $"{CoreBetList.Away} {CoreBetList.ToWinByTwoGoals}";
                    break;

                case BetTeamValue.A3Over:
                    Template.BetChoice.ChoiceName.choiceName = $"{CoreBetList.Away} {CoreBetList.ToWinByThreeUpGoals}";
                    break;

                case BetTeamValue.NG:
                    Template.BetChoice.ChoiceName.choiceName = CoreBetList.NoGoal408;
                    break;

                default:
                    Template.BetChoice.ChoiceName.choiceName = string.Empty;
                    break;
            }
        }
    }
}
