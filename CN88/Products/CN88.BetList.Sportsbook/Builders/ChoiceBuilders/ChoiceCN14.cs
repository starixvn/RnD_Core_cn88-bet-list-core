namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using Fanex.BetList.Core.App_GlobalResources;
    using Fanex.BetList.Core.Entities;

    /// <summary>
    /// First Goal/Last Goal.
    /// </summary>
    public class ChoiceCN14 : BaseChoiceCN88
    {
        protected override void BuildChoiceName(ITicket ticket, ITicketHelper ticketHelper)
        {
            var betTeam = string.Empty;

            switch (ticket.BetTeam)
            {
                case "0:0":
                    betTeam = CoreBetList.NoGoal14;
                    break;

                case "1:1":
                    betTeam = CoreBetList.HomeFG;
                    break;

                case "1:2":
                    betTeam = CoreBetList.HomeLG;
                    break;

                case "2:1":
                    betTeam = CoreBetList.AwayFG;
                    break;

                case "2:2":
                    betTeam = CoreBetList.AwayLG;
                    break;

                default:
                    betTeam = string.Empty;
                    break;
            }

            Template.BetChoice.ChoiceName.choiceName = betTeam;
        }
    }
}