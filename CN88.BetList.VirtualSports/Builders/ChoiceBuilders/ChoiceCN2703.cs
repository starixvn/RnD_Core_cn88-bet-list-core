namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using System.Collections.Generic;
    using CN88.BetList.Core.Helpers;
    using Fanex.BetList.Core.App_GlobalResources;
    using Fanex.BetList.Core.Constants;
    using Fanex.BetList.Core.Entities;

    public class ChoiceCN2703 : BaseVirtualSportsChoiceCN88
    {
        protected override void BuildBetChoice(ITicket ticket, ITicketHelper ticketHelper, List<ITicketData> ticketData)
        {
            Template.BetChoiceMoreInfo.Hide();
            Template.BetChoice.ChoiceValue.Show();

            Template.BetChoice.ChoiceName.choiceName = BetTeamValue.O == ticket.BetTeam.ToLowerInvariant() ? CoreBetList.over : CoreBetList.under;
            Template.BetChoice.ChoiceValue.choiceValue = CN88TicketHelper.GetHandicap(ticket.Handicap1);
        }

        protected override void BuildKickOffTime(ITicket ticket, ITicketHelper ticketHelper)
        {
            Template.KickOffTime.Show();
            Template.KickOffTime.kickOffTime = CN88VirtualSportsChoiceUtils.ParseMatchInfo(ticket.TransDesc, ticketHelper);
        }

        protected override void BuildBetChoiceRtf(RTFHelper rtfHelper)
        {
            var odds = GetOddsValueFromHtml();

            var betChoiceText = $"\n{Template.BetChoice.ChoiceName.choiceName} {Template.BetChoice.ChoiceValue.choiceValue} @ {odds}";

            rtfHelper.RTFRenderer.AddText(betChoiceText);
        }
    }
}
