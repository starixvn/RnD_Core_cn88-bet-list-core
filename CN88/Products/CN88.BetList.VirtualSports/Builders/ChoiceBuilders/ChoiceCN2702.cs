namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using System.Collections.Generic;
    using Fanex.BetList.Core.App_GlobalResources;
    using Fanex.BetList.Core.Entities;

    public class ChoiceCN2702 : BaseVirtualSportsChoiceCN88
    {
        protected override void BuildBetChoice(ITicket ticket, ITicketHelper ticketHelper, List<ITicketData> ticketData)
        {
            Template.BetChoiceMoreInfo.Hide();
            Template.BetChoice.ChoiceValue.Hide();

            Template.BetChoice.ChoiceName.choiceName = $"{CoreBetList.ht}.{ticket.BetTeam.ToUpperInvariant()}";
        }

        protected override void BuildKickOffTime(ITicket ticket, ITicketHelper ticketHelper)
        {
            Template.KickOffTime.Show();
            Template.KickOffTime.kickOffTime = CN88VirtualSportsChoiceUtils.ParseMatchInfo(ticket.TransDesc, ticketHelper);
        }
    }
}
