namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using System;
    using System.Text.RegularExpressions;
    using CN88.BetList.Core.Templates;
    using Fanex.BetList.Core.Entities;

    internal static class CN88VirtualSportsChoiceUtils
    {
        private const string MatchInfoPattern = "m=\"([^\"]*)\"";
        private const string ExcludingScoresPattern = "s=\"([^\"]*)\"";

        public static string ParseKickOffTime(ITicket ticket)
        {
            const string ExpectedDateTimeFormat = "yyyy-MM-dd HH:mm";
            DateTime eventTime;

            return DateTime.TryParse(ticket.ShowTime, out eventTime) ? eventTime.ToString(ExpectedDateTimeFormat) : ticket.ShowTime;
        }

        public static string ParseMatchInfo(string transDesc, ITicketHelper ticketHelper)
        {
            string matchCode = ParseNeccessaryInfoFromTransDesc(transDesc, MatchInfoPattern);

            return ticketHelper.GetBetRadarMatchCodeFormat(matchCode);
        }

        public static void AppendMatchOrRoundInfo(this ChoiceCN88_Template template, string matchRoundInfo)
            => template.Match.Append($"<div class=\"match\">{matchRoundInfo}</div>");

        public static string ParseExcludingScoresInfo(string transDesc)
            => ParseNeccessaryInfoFromTransDesc(transDesc, ExcludingScoresPattern);

        private static string ParseNeccessaryInfoFromTransDesc(string transDesc, string pattern)
        {
            if (!string.IsNullOrEmpty(transDesc))
            {
                Match match = Regex.Match(transDesc, pattern, RegexOptions.IgnoreCase);

                if (match?.Groups.Count >= 2)
                {
                    return match.Groups[1].Value;
                }
            }

            return string.Empty;
        }
    }
}
