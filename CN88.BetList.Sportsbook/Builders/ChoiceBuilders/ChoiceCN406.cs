namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Fanex.BetList.Core.App_GlobalResources;
    using Fanex.BetList.Core.Constants;
    using Fanex.BetList.Core.Entities;

    /// <summary>
    /// Bet type name: Exact Total Goals.
    /// </summary>
    public class ChoiceCN406 : BaseChoiceCN88
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
                    betTeam = CoreBetList.ThreeGoals;
                    break;

                case BetTeamValue.G4:
                    betTeam = CoreBetList.FourGoals;
                    break;

                case BetTeamValue.G5:
                    betTeam = CoreBetList.FiveGoals;
                    break;

                case BetTeamValue.G6:
                    betTeam = CoreBetList.SixAndOver;
                    break;

                default:
                    betTeam = string.Empty;
                    break;
            }

            Template.BetChoice.ChoiceName.choiceName = betTeam;
        }
    }
}
