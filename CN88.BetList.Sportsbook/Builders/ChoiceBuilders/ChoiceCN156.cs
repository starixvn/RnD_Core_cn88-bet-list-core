namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using Fanex.BetList.Core.App_GlobalResources;
    using Fanex.BetList.Core.Constants;
    using Fanex.BetList.Core.Entities;

    /// <summary>
    /// Bet type name: Set x Total Games.
    /// </summary>
    public class ChoiceCN156 : ChoiceCN3
    {
        protected override void CalculateChoiceName(ITicket ticket, ITicketHelper ticketHelper)
        {
            Template.BetChoice.ChoiceName.choiceName =
                ticket.BetTeam == BetTeamValue.O
                ? CoreBetList.over
                : CoreBetList.under;
        }
    }
}