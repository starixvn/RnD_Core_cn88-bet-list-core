namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using System.Collections.Generic;
    using Fanex.BetList.Core.App_GlobalResources;
    using Fanex.BetList.Core.Entities;

    public class ChoiceCN1205 : BaseVirtualSportsChoiceCN88
    {
        protected override void BuildBetChoice(ITicket ticket, ITicketHelper ticketHelper, List<ITicketData> ticketData)
        {
            Template.BetChoiceMoreInfo.Hide();

            Template.BetChoice.ChoiceName.choiceName = string.Join(null, new[] { CoreBetList.ft, ".", ticket.BetTeam.ToUpperInvariant() });
            Template.BetChoice.ChoiceValue.Hide();
        }
    }
}
