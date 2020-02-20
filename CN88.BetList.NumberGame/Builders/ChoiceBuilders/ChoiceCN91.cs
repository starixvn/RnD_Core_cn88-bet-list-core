namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using System.Collections.Generic;
    using CN88.BetList.Core.AppResources;
    using Fanex.BetList.Core.Constants;
    using Fanex.BetList.Core.Entities;

    public class ChoiceCN91 : BaseNumberGameChoiceCN88
    {
        protected override void BuildChoiceValue(ITicket ticket, ITicketHelper ticketHelper, List<ITicketData> ticketData)
        {
            var betTeam = ticket.BetTeam?.ToLowerInvariant() == BetTeamValue.R ? CN88NumberGameLang.Red : CN88NumberGameLang.Blue;

            Template.BetChoice.ChoiceName.choiceName = betTeam;
            Template.BetChoice.ChoiceValue = null;
        }

        protected override void BuildMatch(ITicket ticket, ITicketHelper ticketHelper)
        {
            Template.MatchByTeamId = null;

            var homeTeam = $"{CN88NumberGameLang.numbergameno}{HtmlCharacters.NoneBreakingSpace}{ticket.MatchCode}";
            Template.Match.homeTeam = homeTeam;
            Template.Match.awayTeam = string.Empty;

            Template.Match.VS = null;
            Template.Match.Handicap = null;
            Template.Match.LiveScore.liveScore = $"({ticket.BetId})";
        }
    }
}
