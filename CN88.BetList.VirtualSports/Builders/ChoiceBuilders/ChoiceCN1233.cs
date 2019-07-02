namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using System.Collections.Generic;
    using Fanex.BetList.Core.App_GlobalResources;
    using Fanex.BetList.Core.Entities;
    using Fanex.BetList.Core.Utils;

    public class ChoiceCN1233 : ChoiceCN1231
    {
        private const int WinBetId = 1231;
        private const int PlaceBetId = 1232;

        protected override void BuildOdds(ITicket ticket, List<ITicketData> ticketData)
        {
            if (ticketData == null || ticketData.Count == 0)
            {
                Template.BetChoice.Odds.odds = "-";
                return;
            }

            List<ITicketData> foundTicketData = GetReferenceData(ticket, ticketData);

            if (foundTicketData == null || foundTicketData.Count <= 1)
            {
                Template.BetChoice.Odds.odds = "-";
                return;
            }

            ITicketData winTicket = foundTicketData.Find(item => item.BetTypeId == WinBetId);
            ITicketData placeTicket = foundTicketData.Find(item => item.BetTypeId == PlaceBetId);

            string oddsWin = Formatter.FormatNumber3(winTicket.Odds);
            string oddsPlace = Formatter.FormatNumber3(placeTicket.Odds);

            var choiceName = Template.BetChoice.ChoiceName.choiceName;

            Template.BetChoice.Clear();
            Template.BetChoice.Append($"<span class=\"cn88-choice-name\">{choiceName}</span><span> @ </span><span class=\"cn88-odds\">{oddsWin}</span><span> ({CoreBetList.win})</span>");
            Template.BetChoice.Append($"<br />");
            Template.BetChoice.Append($"<span class=\"cn88-choice-name\">{choiceName}</span><span> @ </span><span class=\"cn88-odds\">{oddsPlace}</span><span> ({CoreBetList.place})</span>");
        }

        protected static List<ITicketData> GetReferenceData(ITicket ticket, List<ITicketData> ticketData)
        {
            return ticketData.FindAll(item => item.RefNo.Equals(ticket.RefNo));
        }

        protected override void BuildBetChoiceRtf(RTFHelper rtfHelper)
        {
            if (Template.BetChoice == null || !Template.BetChoice.Visible)
            {
                return;
            }

            var betChoice = Template.BetChoice.Odds.odds == "-"
                ? $"{Template.BetChoice.ChoiceName.choiceName} @ {Template.BetChoice.Odds.odds}"
                : Template.BetChoice.ToString();
            betChoice = betChoice.Replace($"<span class=\"cn88-choice-name\">", string.Empty)
                .Replace($"</span>", string.Empty)
                .Replace($"<span>", string.Empty)
                .Replace($"<span class=\"cn88-odds\">", string.Empty)
                .Replace("<br />", "\n");

            rtfHelper.RTFRenderer.AddText(betChoice);
        }
    }
}
