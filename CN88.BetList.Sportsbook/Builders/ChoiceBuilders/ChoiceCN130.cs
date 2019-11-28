namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using CN88.BetList.Core.AppResources;
    using Fanex.BetList.Core.App_GlobalResources;
    using Fanex.BetList.Core.Entities;

    /// <summary>
    ///  Choice for bet type 130 Exact Goal.
    /// </summary>
    public class ChoiceCN130 : BaseChoiceCN88
    {
#pragma warning disable S1541 // Methods and properties should not be too complex

        protected override void BuildChoiceName(ITicket ticket, ITicketHelper ticketHelper)
#pragma warning restore S1541 // Methods and properties should not be too complex
        {
            var betteam = string.Empty;

            switch (ticket.BetTeam?.ToLowerInvariant())
            {
                case "0":
                    betteam = CoreBetList.NoGoals;
                    break;

                case "1":
                    betteam = CoreBetList.OneGoal;
                    break;

                case "2":
                    betteam = CoreBetList.TwoGoals;
                    break;

                case "3":
                    betteam = CoreBetList.ThreeGoals;
                    break;

                case "4":
                    betteam = CoreBetList.FourGoals;
                    break;

                case "4&over":
                    betteam = CN88SportsbookResources.FourAndOver;
                    break;

                case "5":
                    betteam = CoreBetList.FiveGoals;
                    break;

                case "5&over":
                    betteam = CN88SportsbookResources.FiveAndOver;
                    break;

                case "6":
                    betteam = CoreBetList.SixGoals;
                    break;

                case "7&over":
                    betteam = CN88SportsbookResources.SevenAndOver;
                    break;

                default:
                    betteam = string.Empty;
                    break;
            }

            Template.BetChoice.ChoiceName.choiceName = betteam;
        }
    }
}
