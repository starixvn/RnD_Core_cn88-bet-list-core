namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using CN88.BetList.Core.AppResources;
    using Fanex.BetList.Core.Constants;
    using Fanex.BetList.Core.Entities;

    /// <summary>
    /// Total Goal.
    /// </summary>
    public class ChoiceCN6 : BaseChoiceCN88
    {
        protected override void BuildChoiceName(ITicket ticket, ITicketHelper ticketHelper)
        {
            // &nbsp; because export format
            var betTeam = string.Empty;

            switch (ticket.BetTeam.ToLowerInvariant())
            {
                case "4-over":
                case "4&over":
                    betTeam = CN88SportsbookResources.FourAndOver;
                    break;

                case "7-over":
                case "7&over":
                    betTeam = CN88SportsbookResources.SevenAndOver;
                    break;

                default:
                    betTeam = ticket.BetTeam.ToLowerInvariant();
                    break;
            }

            Template.BetChoice.ChoiceName.choiceName = string.Join(null, new[] { HtmlCharacters.NoneBreakingSpace, betTeam });
        }
    }
}
