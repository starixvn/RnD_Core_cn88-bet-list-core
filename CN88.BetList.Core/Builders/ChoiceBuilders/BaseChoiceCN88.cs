namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using System.Collections.Generic;
    using System.Linq;
    using CN88.BetList.Core.AppResources;
    using CN88.BetList.Core.Templates;
    using Fanex.BetList.Core.App_GlobalResources;
    using Fanex.BetList.Core.Constants;
    using Fanex.BetList.Core.Entities;
    using Fanex.BetList.Core.Utils;
    using Fanex.BetList.Core.Utils.StringExt;
    using NPOI.SS.UserModel;

    public class BaseChoiceCN88 : IChoiceCN88
    {
        private readonly int[] liveScoreSports = { 1, 3, 4, 8, 26, 28, 49, 51 };
        private const string ESportsXmlTag = "p16";
        private const string InPlayXmlAttribute = "in";
        private const int ESportsSportType = 43;
        private const string ExcelNewLine = "\n";
        private const string Space = " ";
        private const string VsText = " vs ";
        private const string ADotCharacter = " @ ";
        private const string VDotText = "v.";

        public BaseChoiceCN88()
        {
            Template = new ChoiceCN88_Template();
        }

        public ChoiceCN88_Template Template { get; set; }

        public ChoiceCN88_Template Render(ITicket ticket, ITicketHelper ticketHelper, List<ITicketData> ticketData)
        {
            BuildChoice(ticket, ticketHelper, ticketData);

            return Template;
        }

        protected virtual void BuildChoice(ITicket ticket, ITicketHelper ticketHelper, List<ITicketData> ticketData)
        {
            HideUnusedBlocks();

            BuildLeague(ticket, ticketHelper);

            BuildMatch(ticket, ticketHelper);

            BuildKickOffTime(ticket, ticketHelper);

            BuildBetChoice(ticket, ticketHelper, ticketData);

            BuildOdds(ticket, ticketData);
        }

        protected virtual void HideUnusedBlocks()
        {
            Template.MixParlay.Hide();
            Template.MoreInfo.Hide();
        }

        protected virtual void BuildOdds(ITicket ticket, List<ITicketData> ticketData)
        {
            object oddsType = string.IsNullOrEmpty(ticket.OddsType) ? (object)0 : ticket.OddsType;

            Template.BetChoice.Odds.odds = ConvertByBetType.Odds(ticket.Odds, ticket.BetTypeId, oddsType);
        }

        protected virtual void BuildLeague(ITicket ticket, ITicketHelper ticketHelper)
        {
            if (Template.League == null
                || Template.League.LeagueName == null)
            {
                return;
            }

            Template.League.LeagueName.leagueName = ticketHelper.GetLeagueNameById(ticket.LeagueId);
        }

        protected virtual void BuildScore(ITicket ticket)
        {
            if (Template.Match.LiveScore == null)
            {
                return;
            }

            Template.Match.LiveScore.Visible = ticket.IsLive;

            if (!ticket.IsLive)
            {
                return;
            }

            if (IsShowLiveText(ticket.SportTypeId))
            {
                if (ticket.SportTypeId == ESportsSportType)
                {
                    var scoreStatus = GetScoreStatus(ticket);

                    Template.Match.LiveScore.liveScore = $"<span class=\"cn88-live-text\">[{scoreStatus}]</span>";
                }
                else
                {
                    Template.Match.LiveScore.Hide();
                }
            }
            else
            {
                Template.Match.LiveScore.liveScore = $"({ticket.LiveHomeScore}-{ticket.LiveAwayScore})";
            }
        }

        private static string GetScoreStatus(ITicket ticket)
        {
            var inPlayStatus = GetInPlayStatus(ticket.ExtraInfo);

            if (string.IsNullOrEmpty(inPlayStatus))
            {
                inPlayStatus = GetInPlayStatus(ticket.TransDesc);
            }

            return string.IsNullOrEmpty(inPlayStatus) ? CoreBetList.Live : inPlayStatus;
        }

        private static string GetInPlayStatus(string data)
        {
            try
            {
                if (data.HasAttributeInXmlTag(ESportsXmlTag, InPlayXmlAttribute))
                {
                    var isInPlay = data.GetXmlTagAttributeValue(ESportsXmlTag, InPlayXmlAttribute) == "1";

                    if (isInPlay)
                    {
                        return CN88Resources.InPlay;
                    }
                }

                return string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }

        protected bool IsShowLiveText(int sportTypeId)
        {
            const int MaxSportsbookSportTypeId = 99;

            return sportTypeId > 0 &&
                sportTypeId <= MaxSportsbookSportTypeId &&
                !liveScoreSports.Contains(sportTypeId);
        }

        protected virtual void BuildBetChoice(ITicket ticket, ITicketHelper ticketHelper, List<ITicketData> ticketData)
        {
            Template.BetChoiceMoreInfo.Hide();

            BuildChoiceName(ticket, ticketHelper);

            if (Template.BetChoice.ChoiceValue != null)
            {
                Template.BetChoice.ChoiceValue.Hide();
            }
        }

        protected virtual void BuildChoiceName(ITicket ticket, ITicketHelper ticketHelper)
        {
            var isBetHomeTeam = IsBetHomeTeam(ticket);

            Template.BetChoice.ChoiceName.choiceName =
                isBetHomeTeam
                    ? ticketHelper.GetTeamNameById(ticket.HomeId)
                    : ticketHelper.GetTeamNameById(ticket.AwayId);
        }

        protected static bool IsBetHomeTeam(ITicket ticket)
        {
            bool betHomeTeam =
                ticket.BetTeam != null && ticket.BetTeam.ToLowerInvariant().Contains(BetTeamValue.H);

            return betHomeTeam;
        }

        protected virtual void BuildMatch(ITicket ticket, ITicketHelper ticketHelper)
        {
            if (Template.Match == null)
            {
                return;
            }

            var homeTeamName = ticketHelper.GetTeamNameById(ticket.HomeId);

            Template.Match.homeTeam = string.Join(null, new[] { homeTeamName, ticket.IsNeutral ? $" {CoreBetList.Neutral}" : string.Empty });
            Template.Match.awayTeam = ticketHelper.GetTeamNameById(ticket.AwayId);
            Template.MatchByTeamId.homeTeamId = $"[{ticket.HomeId}]";
            Template.MatchByTeamId.awayTeamId = $"[{ticket.AwayId}]";
            Template.Match.Handicap.Hide();

            BuildScore(ticket);
        }

        protected virtual void BuildKickOffTime(ITicket ticket, ITicketHelper ticketHelper)
        {
            Template.KickOffTime.Hide();
        }

        public List<IRichTextString> RenderRTF(ITicket ticket, ITicketHelper ticketHelper, List<ITicketData> ticketData, RTFHelper rtfHelper)
        {
            Render(ticket, ticketHelper, ticketData);

            var choiceData = BuildRTFChoice(ticket, rtfHelper, ticketHelper, ticketData);
            var rtfChoice = new List<IRichTextString> { choiceData };

            return rtfChoice;
        }

        protected virtual IRichTextString BuildRTFChoice(ITicket ticket, RTFHelper rtfHelper, ITicketHelper ticketHelper, List<ITicketData> ticketData)
        {
            BuildLeagueRft(rtfHelper);

            BuildMatchRtf(rtfHelper);

            BuildKickOffTimeRtf(rtfHelper);

            if (Template.BetChoice != null && Template.BetChoice.Visible)
            {
                Template.BetChoice.ChoiceName.choiceName = RemoveSpecialWords(Template.BetChoice.ChoiceName.choiceName);
            }

            BuildBetChoiceRtf(rtfHelper);

            var choiceRtf = rtfHelper.RTFRenderer.Render();
            rtfHelper.RTFRenderer.Clear();
            return choiceRtf;
        }

        protected virtual void BuildLeagueRft(RTFHelper rtfHelper)
        {
            if (Template.League != null && Template.League.Visible)
            {
                rtfHelper.RTFRenderer.AddText(Template.League.LeagueName.leagueName);
            }
        }

        protected virtual void BuildMatchRtf(RTFHelper rtfHelper)
        {
            if (Template.MatchByTeamId != null && Template.MatchByTeamId.Visible)
            {
                var matchIdText = string.Join(
                    string.Empty,
                    ExcelNewLine,
                    Template.MatchByTeamId.homeTeamId,
                    VsText,
                    Template.MatchByTeamId.awayTeamId);
                rtfHelper.RTFRenderer.AddText(matchIdText);
            }

            if (Template.Match != null && Template.Match.Visible)
            {
                var liveScore = Space + Template.Match.LiveScore.liveScore
                    .Replace("{liveScore}", string.Empty)
                    .Replace("<span class=\"cn88-live-text\">", string.Empty)
                    .Replace("</span>", string.Empty);
                var matchText =
                    $"{ExcelNewLine}{Template.Match.homeTeam}{Space}{BuildVSText()}{Space}{Template.Match.awayTeam}{liveScore}";

                rtfHelper.RTFRenderer.AddText(matchText);
            }
        }

        protected virtual void BuildKickOffTimeRtf(RTFHelper rtfHelper) { }

        protected virtual string BuildVSText()
            => VDotText;

        protected virtual void BuildBetChoiceRtf(RTFHelper rtfHelper)
        {
            if (Template.BetChoice != null && Template.BetChoice.Visible)
            {
                var odds = GetOddsValueFromHtml();

                var betChoiceText = string.Join(
                       string.Empty,
                       ExcelNewLine,
                       Template.BetChoice.ChoiceName.choiceName,
                       ADotCharacter,
                       odds);

                rtfHelper.RTFRenderer.AddText(betChoiceText);
            }
        }

        protected string GetOddsValueFromHtml()
            => Template.BetChoice.Odds?.odds?
                .Replace(ConvertByBetType.FontOpenTag, string.Empty)
                .Replace(ConvertByBetType.FontCloseTag, string.Empty);

        protected static string RemoveSpecialWords(string htmlText)
            => htmlText.Replace("&nbsp;", " ");
    }
}
