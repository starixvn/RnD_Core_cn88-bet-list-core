namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using System.Collections.Generic;
    using Fanex.BetList.Core.App_GlobalResources;
    using Fanex.BetList.Core.Constants;
    using Fanex.BetList.Core.Entities;

    public class ChoiceCN86 : BaseNumberGameChoiceCN88
    {
        protected override void BuildChoiceValue(ITicket ticket, ITicketHelper ticketHelper, List<ITicketData> ticketData)
        {
            Template.BetChoice.ChoiceName.choiceName = ticket.BetTeam.ToLowerInvariant() == BetTeamValue.H ? CoreBetList.odd : CoreBetList.even;
            Template.BetChoice.ChoiceValue = null;
        }
    }
}
