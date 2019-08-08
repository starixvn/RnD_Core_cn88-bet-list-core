namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using System.Collections.Generic;
    using CN88.BetList.Core.Helpers;
    using Fanex.BetList.Core.Entities;

    public class ChoiceCN1205 : BaseVirtualSportsChoiceCN88
    {
        protected override void BuildBetChoice(ITicket ticket, ITicketHelper ticketHelper, List<ITicketData> ticketData)
        {
            Template.BetChoiceMoreInfo.Hide();
            Template.BetChoice.ChoiceName.choiceName = CN88TicketHelper.Get1x2ChoiceValue(ticket, ticketHelper);
            Template.BetChoice.ChoiceValue.Hide();
        }
    }
}
