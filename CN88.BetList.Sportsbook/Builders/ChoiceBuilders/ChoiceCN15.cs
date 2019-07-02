namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using Fanex.BetList.Core.App_GlobalResources;
    using Fanex.BetList.Core.Entities;

    /// <summary>
    /// Bet Type: 1st 1X2.
    /// </summary>
    public class ChoiceCN15 : BaseChoiceCN88
    {
        protected override void BuildChoiceName(ITicket ticket, ITicketHelper ticketHelper)
        {
            Template.BetChoice.ChoiceName.choiceName = string.Join(
                null,
                new[] {
                    CoreBetList.ht,
                    ".",
                    ticket.BetTeam.ToUpperInvariant()
                });
        }
    }
}