namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using Fanex.BetList.Core.Constants;
    using Fanex.BetList.Core.Entities;

    /// <summary>
    /// BAIO - 1H Winning Margin 12 Way
    /// </summary>
    public class ChoiceCN608 : ChoiceCN602
    {
        protected override void BuildChoiceName(ITicket ticket, ITicketHelper ticketHelper)
        {
            base.BuildChoiceName(ticket, ticketHelper);

            if (ticket.BetTeam.ToLowerInvariant() == BetTeamValue.D)
            {
                Template.BetChoice.ChoiceName.choiceName = ticketHelper.GetResourceData(BasketballRefId, "D");
            }
        }
    }
}