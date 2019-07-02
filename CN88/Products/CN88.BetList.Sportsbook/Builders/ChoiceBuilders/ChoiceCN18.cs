namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using Fanex.BetList.Core.App_GlobalResources;
    using Fanex.BetList.Core.Constants;
    using Fanex.BetList.Core.Entities;

    /// <summary>
    /// Bet type name: 2ND Over/Under.
    /// </summary>
    public class ChoiceCN18 : ChoiceCN3
    {
        protected override void CalculateChoiceName(ITicket ticket, ITicketHelper ticketHelper)
        {
            Template.BetChoice.ChoiceName.choiceName = IsOver(ticket)
                ? CoreBetList.over
                : CoreBetList.under;
        }

        private static bool IsOver(ITicket ticket)
            => ticket.BetTeam.ToLowerInvariant() == BetTeamValue.O;
    }
}