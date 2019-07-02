namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using System.Collections.Generic;
    using CN88.BetList.Core.AppResources;
    using Fanex.BetList.Core.Constants;
    using Fanex.BetList.Core.Entities;

    public class BaseNumberGameChoiceCN88 : BaseChoiceCN88
    {
        protected override void BuildBetChoice(ITicket ticket, ITicketHelper ticketHelper, List<ITicketData> ticketData)
        {
            Template.BetChoiceMoreInfo.Hide();

            BuildChoiceValue(ticket, ticketHelper, ticketData);
        }

        protected override void BuildMatch(ITicket ticket, ITicketHelper ticketHelper)
        {
            Template.MatchByTeamId = null;

            var homeTeam = $"{CN88NumberGameLang.numbergameno}{HtmlCharacters.NoneBreakingSpace}{ticket.MatchCode}";
            Template.Match.homeTeam = homeTeam;
            Template.Match.awayTeam = string.Empty;

            Template.Match.VS = null;
            Template.Match.Handicap = null;
            if (ticket.IsLive)
            {
                Template.Match.LiveScore.liveScore = $"({ticket.BetId})";
            }
            else
            {
                Template.Match.LiveScore.Hide();
            }
        }

        protected virtual void BuildChoiceValue(ITicket ticket, ITicketHelper ticketHelper, List<ITicketData> ticketData) { }

        protected override void BuildMatchRtf(RTFHelper rtfHelper)
        {
            var matchText = $"\n{Template.Match.homeTeam.Replace("&nbsp;", " ")}";
            matchText += Template.Match.LiveScore.Visible ? $" {Template.Match.LiveScore.liveScore}" : string.Empty;
            rtfHelper.RTFRenderer.AddText(matchText);
        }
    }
}
