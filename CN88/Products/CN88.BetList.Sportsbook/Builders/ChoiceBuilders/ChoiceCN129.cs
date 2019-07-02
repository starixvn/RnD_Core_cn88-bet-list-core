namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using CN88.BetList.Core.AppResources;
    using Fanex.BetList.Core.App_GlobalResources;
    using Fanex.BetList.Core.Entities;

    /// <summary>
    ///  Choice for bet type 129 First Half Exact Goal.
    /// </summary>
    public class ChoiceCN129 : BaseChoiceCN88
    {
#pragma warning disable S1541 // Methods and properties should not be too complex
        protected override void BuildChoiceName(ITicket ticket, ITicketHelper ticketHelper)
#pragma warning restore S1541 // Methods and properties should not be too complex
        {
            var betTeam = string.Empty;

            switch (ticket.BetTeam)
            {
                case "0":
                    betTeam = CoreBetList.NoGoals;
                    break;

                case "1":
                    betTeam = CoreBetList.OneGoal;
                    break;

                case "2":
                    betTeam = CoreBetList.TwoGoals;
                    break;

                case "3":
                    betTeam = CoreBetList.ThreeGoals;
                    break;

                case "4":
                    betTeam = CoreBetList.FourGoals;
                    break;

                case "4&over":
                    betTeam = CN88SportsbookResources.FourAndOver;
                    break;

                case "5":
                    betTeam = CoreBetList.FiveGoals;
                    break;

                case "5&over":
                    betTeam = CoreBetList.FiveAndOver;
                    break;

                case "6":
                    betTeam = CoreBetList.SixGoals;
                    break;

                case "7&over":
                    betTeam = CN88SportsbookResources.SevenAndOver;
                    break;

                default:
                    betTeam = string.Empty;
                    break;
            }

            Template.BetChoice.ChoiceName.choiceName = betTeam;
        }
    }
}
