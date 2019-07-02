namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using System.Collections.Generic;
    using Fanex.BetList.Core.App_GlobalResources;
    using Fanex.BetList.Core.Constants;
    using Fanex.BetList.Core.Entities;

    public class ChoiceCN81 : BaseNumberGameChoiceCN88
    {
        protected const string NumberGameValue = " <span style='color:#555555;font-weight: bold;'>37.5</span>";

        protected override void BuildChoiceValue(ITicket ticket, ITicketHelper ticketHelper, List<ITicketData> ticketData)
        {
            Template.BetChoice.ChoiceValue.Hide();
            Template.BetChoice.ChoiceName.choiceName = ticket.BetTeam.ToLowerInvariant() == BetTeamValue.H ? CoreBetList.over : CoreBetList.under;
            Template.BetChoice.ChoiceName.choiceName += NumberGameValue;
        }

        protected override void BuildBetChoiceRtf(RTFHelper rtfHelper)
        {
            var odds = GetOddsValueFromHtml();
            var choice = Template.BetChoice.ChoiceName.choiceName
                .Replace("<span style='color:#555555;font-weight: bold;'>", string.Empty)
                .Replace("</span>", string.Empty);

            var betChoiceText = $"\n{choice} @ {odds}";

            rtfHelper.RTFRenderer.AddText(betChoiceText);
        }
    }
}
