namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using System.Collections.Generic;
    using CN88.BetList.Core.AppResources;
    using Fanex.BetList.Core.Constants;
    using Fanex.BetList.Core.Entities;

    public class ChoiceCN88 : BaseNumberGameChoiceCN88
    {
        protected override void BuildChoiceValue(ITicket ticket, ITicketHelper ticketHelper, List<ITicketData> ticketData)
        {
            Template.BetChoice.ChoiceName.choiceName = ticket.BetTeam == BetTeamValue.H ? CN88NumberGameLang.warrior2ndBall : CN88NumberGameLang.warrior3rdBall;

            Template.BetChoice.ChoiceValue = null;
        }
    }
}
