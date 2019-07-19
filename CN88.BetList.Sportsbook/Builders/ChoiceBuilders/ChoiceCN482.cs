namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using CN88.BetList.Core.Helpers;
    using Fanex.BetList.Core.App_GlobalResources;
    using Fanex.BetList.Core.Constants;
    using Fanex.BetList.Core.Entities;

    public class ChoiceCN482 : BaseChoiceCN88
    {
        protected override void BuildChoiceName(ITicket ticket, ITicketHelper ticketHelper)
        {
            var choiceName = ticket.BetTeam.ToLowerInvariant() == BetTeamValue.O ? CoreBetList.over : CoreBetList.under;
            Template.BetChoice.ChoiceName.choiceName = $"{choiceName} {CN88TicketHelper.GetHandicap(ticket.Handicap1)}";
        }
    }
}
