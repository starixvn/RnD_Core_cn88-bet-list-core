namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using Fanex.BetList.Core.App_GlobalResources;
    using Fanex.BetList.Core.Constants;
    using Fanex.BetList.Core.Entities;

    /// <summary>
    /// Pool House All In One: Home Team Over/Under.
    /// </summary>
    public class ChoiceCN401 : ChoiceCN3
    {
        protected override void CalculateChoiceName(ITicket ticket, ITicketHelper ticketHelper)
        {
            Template.BetChoice.ChoiceName.choiceName =
                BetTeamValue.O == ticket.BetTeam.ToLowerInvariant()
                ? CoreBetList.over
                : CoreBetList.under;
        }
    }
}