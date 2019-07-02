namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using Fanex.BetList.Core.App_GlobalResources;
    using Fanex.BetList.Core.Constants;
    using Fanex.BetList.Core.Entities;

    /// <summary>
    /// Bet Type: First Home Team Odd/Even - 136.
    /// </summary>
    public class ChoiceCN136 : BaseChoiceCN88
    {
        protected override void BuildChoiceName(ITicket ticket, ITicketHelper ticketHelper)
        {
            Template.BetChoice.ChoiceName.choiceName =
                (ticket.BetTeam.ToLowerInvariant() == BetTeamValue.O)
                ? CoreBetList.odd
                : CoreBetList.even;
        }
    }
}