namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using Fanex.BetList.Core.App_GlobalResources;
    using Fanex.BetList.Core.Constants;
    using Fanex.BetList.Core.Entities;

    public class ChoiceCN9088 : BaseChoiceCN88
    {
        protected override void BuildBetChoice(ITicket ticket, ITicketHelper ticketHelper, List<ITicketData> ticketData)
        {
            base.BuildBetChoice(ticket, ticketHelper, ticketData);

            var choice = ticket.BetTeam;
            Template.BetChoice.ChoiceName.choiceName = string.IsNullOrEmpty(choice) ? choice : choice.Replace(":", "-");
        }
    }
}
