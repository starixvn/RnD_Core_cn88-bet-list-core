namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using System.Collections.Generic;
    using CN88.BetList.Core.AppResources;
    using Fanex.BetList.Core.Constants;
    using Fanex.BetList.Core.Entities;

    public class ChoiceCN8101 : BaseNumberGameChoiceCN88
    {
        public const string BetChoiceRefId = "H5_BetChoice";

        protected override void BuildChoiceValue(ITicket ticket, ITicketHelper ticketHelper, List<ITicketData> ticketData)
        {
            if (!string.IsNullOrEmpty(ticket.BetTeam))
            {
                var resourceId = ticket.BetTeam.ToLowerInvariant();

                Template.BetChoice.ChoiceName.choiceName = ticketHelper.GetResourceData(BetChoiceRefId, resourceId);
            }
            else
            {
                Template.BetChoice.ChoiceName.choiceName = string.Empty;
            }

            Template.BetChoice.ChoiceValue = null;
        }

        protected override void BuildMatch(ITicket ticket, ITicketHelper ticketHelper)
        {
            Template.MatchByTeamId = null;

            var homeTeam = $"{CN88NumberGameLang.lblNo}.{HtmlCharacters.NoneBreakingSpace}{ticket.MatchCode}";
            Template.Match.homeTeam = homeTeam;
            Template.Match.awayTeam = string.Empty;

            Template.Match.VS = null;
            Template.Match.Handicap = null;
            Template.Match.LiveScore = null;
        }

        protected override void BuildMatchRtf(RTFHelper rtfHelper)
        {
            var matchText = $"\n{Template.Match.homeTeam.Replace("&nbsp;", " ")}";
            rtfHelper.RTFRenderer.AddText(matchText);
        }
    }
}
