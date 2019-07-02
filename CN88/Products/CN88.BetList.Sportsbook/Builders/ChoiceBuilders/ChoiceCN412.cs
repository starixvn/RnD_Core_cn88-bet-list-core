namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using CN88.BetList.Core.AppResources;
    using Fanex.BetList.Core.App_GlobalResources;
    using Fanex.BetList.Core.Entities;

    public class ChoiceCN412 : BaseChoiceCN88
    {
        protected override void BuildChoiceName(ITicket ticket, ITicketHelper ticketHelper)
        {
            var betTeam = string.Empty;

            switch (ticket.BetTeam.ToLowerInvariant())
            {
                case "0":
                    betTeam = CoreBetList.nogoal;
                    break;

                case "1":
                    betTeam = CoreBetList.OneGoal;
                    break;

                case "2":
                    betTeam = CoreBetList.TwoGoals;
                    break;

                case "3-over":
                    betTeam = CN88SportsbookResources.ThreeAndOver;
                    break;

                default:
                    betTeam = string.Empty;
                    break;
            }

            Template.BetChoice.ChoiceName.choiceName = betTeam;
        }
    }
}
