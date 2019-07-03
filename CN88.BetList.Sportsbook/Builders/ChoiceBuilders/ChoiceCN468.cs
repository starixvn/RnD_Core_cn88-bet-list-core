namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using System.Collections.Generic;
    using System.Linq;
    using Fanex.BetList.Core.Entities;
    using Fanex.BetList.Core.Utils.TicketExt;
    using Fanex.BetList.Core.Utils.TicketHelperExt;

    public class ChoiceCN468 : BaseChoiceCN88
    {
        public const string ScoreBoxDescriptionHtmlFormat = "<div class='bettype-description'>{0}</div>";

        protected override void BuildOdds(ITicket ticket, List<ITicketData> ticketData)
        {
            base.BuildOdds(ticket, ticketData);

            if (Template.BetChoice.Odds.odds == "-")
            {
                Template.BetChoice.Odds.odds = "0";
            }
        }

        protected override void BuildBetChoice(ITicket ticket, ITicketHelper ticketHelper, List<ITicketData> ticketData)
        {
            base.BuildBetChoice(ticket, ticketHelper, ticketData);
            if (!ticket.IsSettled())
            {
                Template.BetChoice.BetChoiceSplitChar.Hide();
                Template.BetChoice.Odds.Hide();
            }

            if (string.IsNullOrEmpty(ticket.BetTeam) || string.IsNullOrEmpty(ticket.BetCheck))
            {
                return;
            }

            Template.BetChoiceMoreInfo.Show();
            var scoreBoxOddsDescriptions = ticketHelper.GetScoreBoxOdds(ticket.BetTeam, ticket.BetCheck)
                .Select(s => string.Format(ScoreBoxDescriptionHtmlFormat, s));
            Template.BetChoiceMoreInfo.betChoiceMoreInfo = string.Join(string.Empty, scoreBoxOddsDescriptions);
        }

        protected override void BuildBetChoiceRtf(RTFHelper rtfHelper)
        {
            base.BuildBetChoiceRtf(rtfHelper);

            if (Template.BetChoiceMoreInfo != null && Template.BetChoiceMoreInfo.Visible)
            {
                var infoText = Template.BetChoiceMoreInfo.betChoiceMoreInfo.Replace("<div class='bettype-description'>", string.Empty)
                    .Replace("</div>", "\r\n");

                rtfHelper.RTFRenderer.AddText($"\r\n{infoText}");
            }
        }
    }
}
