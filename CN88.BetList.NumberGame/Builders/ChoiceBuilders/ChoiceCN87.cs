namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using System.Collections.Generic;
    using CN88.BetList.Core.AppResources;
    using Fanex.BetList.Core.Constants;
    using Fanex.BetList.Core.Entities;

    public class ChoiceCN87 : BaseNumberGameChoiceCN88
    {
        protected override void BuildChoiceValue(ITicket ticket, ITicketHelper ticketHelper, List<ITicketData> ticketData)
        {
            var betTeam = ticket.BetTeam?.ToLowerInvariant() == BetTeamValue.H ? CN88NumberGameLang.high : CN88NumberGameLang.low;

            Template.BetChoice.ChoiceName.choiceName = betTeam;
            Template.BetChoice.ChoiceValue = null;
        }
    }
}
