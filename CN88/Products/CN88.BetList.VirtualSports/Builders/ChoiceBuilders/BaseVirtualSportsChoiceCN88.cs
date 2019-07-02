namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using Fanex.BetList.Core.App_GlobalResources;
    using Fanex.BetList.Core.Entities;

    public class BaseVirtualSportsChoiceCN88 : BaseChoiceCN88
    {
        protected override void BuildKickOffTime(ITicket ticket, ITicketHelper ticketHelper)
        {
            Template.KickOffTime.Show();
            Template.KickOffTime.kickOffTime = CN88VirtualSportsChoiceUtils.ParseKickOffTime(ticket);
        }

        protected override void BuildKickOffTimeRtf(RTFHelper rtfHelper)
        {
            rtfHelper.RTFRenderer.AddText($"\n{Template.KickOffTime.kickOffTime}");
        }

        protected override void BuildMatch(ITicket ticket, ITicketHelper ticketHelper)
        {
            Template.MatchByTeamId.Hide();

            var isHomeTeam = ticket.Handicap1 > ticket.Handicap2 || (ticket.Handicap1 == 0 && ticket.Handicap2 == 0);
            var homeTeamName = isHomeTeam ? ticketHelper.GetTeamNameById(ticket.HomeId) : ticketHelper.GetTeamNameById(ticket.AwayId);
            Template.Match.homeTeam = string.Join(null, new[] {
                homeTeamName,
                ticket.IsNeutral ? $" {CoreBetList.Neutral}" : string.Empty
            });

            Template.Match.Handicap.Hide();

            var awayTeamName = isHomeTeam ? ticketHelper.GetTeamNameById(ticket.AwayId) : ticketHelper.GetTeamNameById(ticket.HomeId);
            Template.Match.awayTeam = awayTeamName;

            BuildScore(ticket);
        }

        protected override void BuildScore(ITicket ticket)
        {
            Template.Match.LiveScore.Visible = ticket.IsLive;

            if (!ticket.IsLive)
            {
                return;
            }

            Template.Match.LiveScore.liveScore = $"({ticket.LiveHomeScore}-{ticket.LiveAwayScore})";
        }

        protected override void BuildMatchRtf(RTFHelper rtfHelper)
        {
            var liveScore = " " + Template.Match.LiveScore.liveScore
                      .Replace("{liveScore}", string.Empty)
                      .Replace("<span class=\"cn88-live-text\">", string.Empty)
                      .Replace("</span>", string.Empty);

            var hdp = Template.Match.Handicap != null && Template.Match.Handicap.Visible
                ? Template.Match.Handicap.handicap
                : string.Empty;

            var matchText = $"\n{Template.Match.homeTeam} {BuildVSText()}{hdp} {Template.Match.awayTeam}{liveScore}";

            rtfHelper.RTFRenderer.AddText(matchText);
        }
    }
}
