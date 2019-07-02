namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using System.Collections.Generic;
    using Fanex.BetList.Core.App_GlobalResources;
    using Fanex.BetList.Core.Constants;
    using Fanex.BetList.Core.Entities;

    public class ChoiceCN85 : ChoiceCN81
    {
        protected override void BuildChoiceValue(ITicket ticket, ITicketHelper ticketHelper, List<ITicketData> ticketData)
        {
            Template.BetChoice.ChoiceValue.Hide();

            Template.BetChoice.ChoiceName.choiceName = ticket.BetTeam.ToLowerInvariant() == BetTeamValue.H ? CoreBetList.over : CoreBetList.under;
            Template.BetChoice.ChoiceName.choiceName += NumberGameValue;
        }
    }
}
