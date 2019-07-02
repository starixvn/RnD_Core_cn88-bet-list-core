namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using CN88.BetList.Core.AppResources;
    using Fanex.BetList.Core.Entities;

    /// <summary>
    ///  Choice for bet type 131 Home Team Total Goal.
    /// </summary>
    public class ChoiceCN131 : BaseChoiceCN88
    {
        protected override void BuildChoiceName(ITicket ticket, ITicketHelper ticketHelper)
        {
            var betTeam = ticket.BetTeam.Equals("4&over", System.StringComparison.OrdinalIgnoreCase)
                ? CN88SportsbookResources.FourAndOver
                : ticket.BetTeam;

            Template.BetChoice.ChoiceName.choiceName = betTeam;
        }
    }
}
