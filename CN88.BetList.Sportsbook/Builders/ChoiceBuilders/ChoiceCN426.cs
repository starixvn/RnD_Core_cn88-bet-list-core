namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using Fanex.BetList.Core.App_GlobalResources;
    using Fanex.BetList.Core.Constants;
    using Fanex.BetList.Core.Entities;

    /// <summary>
    /// Bet type name: 1H Winning Margin
    /// </summary>
    public class ChoiceCN426 : BaseChoiceCN88
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

                case BetTeamValue.H2Over:
                    betTeam = string.Format(betTeamFormat, CoreBetList.Home, CoreBetList.ToWinByTwoUpGoals);
                    break;

                case BetTeamValue.D:
                    betTeam = CoreBetList.ScoreDraw;
                    break;

                case BetTeamValue.A1:
                    betTeam = string.Format(betTeamFormat, CoreBetList.Away, CoreBetList.ToWinByOneGoal);
                    break;

                case BetTeamValue.A2Over:
                    betTeam = string.Format(betTeamFormat, CoreBetList.Away, CoreBetList.ToWinByTwoUpGoals);
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
