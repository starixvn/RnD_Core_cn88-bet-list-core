namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using Fanex.BetList.Core.App_GlobalResources;
    using Fanex.BetList.Core.Constants;
    using Fanex.BetList.Core.Entities;

    /// <summary>
    /// BAIO - Quarter X Odd Even
    /// </summary>
    public class ChoiceCN611 : ChoiceCN603
    {
        protected override void BuildChoiceName(ITicket ticket, ITicketHelper ticketHelper)
        {
            Template.BetChoice.ChoiceName.choiceName =
                BetTeamValue.O == ticket.BetTeam.ToLowerInvariant()
                ? CoreBetList.odd
                : CoreBetList.even;
        }
    }
}