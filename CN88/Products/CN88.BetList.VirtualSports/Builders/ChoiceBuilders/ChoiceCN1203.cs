namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using System.Collections.Generic;
    using Fanex.BetList.Core.App_GlobalResources;
    using Fanex.BetList.Core.Constants;
    using Fanex.BetList.Core.Entities;
    using Fanex.BetList.Core.Utils;

    public class ChoiceCN1203 : BaseVirtualSportsChoiceCN88
    {
        protected override void BuildBetChoice(ITicket ticket, ITicketHelper ticketHelper, List<ITicketData> ticketData)
        {
            Template.BetChoiceMoreInfo.Hide();

            Template.BetChoice.ChoiceName.choiceName = BetTeamValue.H == ticket.BetTeam.ToLowerInvariant() ? CoreBetList.over : CoreBetList.under;
            Template.BetChoice.ChoiceValue.choiceValue = ConvertByBetType.Hdp(ticket.Handicap1);
        }

        protected override void BuildBetChoiceRtf(RTFHelper rtfHelper)
        {
            var odds = GetOddsValueFromHtml();

            var betChoiceText = $"\n{Template.BetChoice.ChoiceName.choiceName} {Template.BetChoice.ChoiceValue.choiceValue} @ {odds}";

            rtfHelper.RTFRenderer.AddText(betChoiceText);
        }
    }
}
