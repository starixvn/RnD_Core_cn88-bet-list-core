namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using Fanex.BetList.Core.App_GlobalResources;
    using Fanex.BetList.Core.Constants;
    using Fanex.BetList.Core.Entities;

    /// <summary>
    /// Pool House All In One: Exact Home Team Goals.
    /// Its parent bet type is Exact Home Team Goals - bet type ID 161 of Bet Radar.
    /// </summary>
    public class ChoiceCN407 : BaseChoiceCN88
    {
        protected override void BuildChoiceName(ITicket ticket, ITicketHelper ticketHelper)
        {
            var betTeam = string.Empty;

            switch (ticket.BetTeam.ToLowerInvariant())
            {
                case BetTeamValue.G0:
                    betTeam = CoreBetList.ZeroGoals;
                    break;

                case BetTeamValue.G1:
                    betTeam = CoreBetList.OneGoal;
                    break;

                case BetTeamValue.G2:
                    betTeam = CoreBetList.TwoGoals;
                    break;

                case BetTeamValue.G3:
                    betTeam = CoreBetList.ThreeGoalsAndOver;
                    break;

                default:
                    betTeam = string.Empty;
                    break;
            }

            Template.BetChoice.ChoiceName.choiceName = betTeam;
        }
    }
}