namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using System.Collections.Generic;
    using Fanex.BetList.Core.App_GlobalResources;
    using Fanex.BetList.Core.Constants;
    using Fanex.BetList.Core.Entities;

    public class ChoiceCN2802 : ChoiceCN2801
    {
        protected override void BuildScore(ITicket ticket)
        {
            Template.Match.LiveScore.Visible = false;
        }

        protected override void BuildBetChoice(ITicket ticket, ITicketHelper ticketHelper, List<ITicketData> ticketData)
        {
            Template.BetChoiceMoreInfo.Hide();
            Template.BetChoice.ChoiceValue.Hide();

            var betTeam = string.Empty;

            switch (ticket.BetTeam.ToLowerInvariant())
            {
                case BetTeamValue.NumberOne:
                    betTeam = Template.Match.homeTeam;
                    break;

                case BetTeamValue.NumberTwo:
                    betTeam = Template.Match.awayTeam;
                    break;

                case BetTeamValue.X:
                    betTeam = CoreBetList.draw;
                    break;

                default:
                    betTeam = string.Empty;
                    break;
            }

            Template.BetChoice.ChoiceName.choiceName = betTeam;
        }

        protected override void BuildBetChoiceRtf(RTFHelper rtfHelper)
        {
            var odds = GetOddsValueFromHtml();
            var choice = Template.BetChoice.ChoiceName.choiceName
                 .Replace("<span class=\"cn88-handicap\">", string.Empty)
                 .Replace("</span>", string.Empty);

            var betChoiceText = $"\n{choice} @ {odds}";

            rtfHelper.RTFRenderer.AddText(betChoiceText);
        }
    }
}
