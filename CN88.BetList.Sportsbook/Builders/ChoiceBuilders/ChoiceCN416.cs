namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using Fanex.BetList.Core.App_GlobalResources;
    using Fanex.BetList.Core.Constants;
    using Fanex.BetList.Core.Entities;

    public class ChoiceCN416 : ChoiceCN4
    {
        protected override void BuildBetChoice(ITicket ticket, ITicketHelper ticketHelper, List<ITicketData> ticketData)
        {
            base.BuildBetChoice(ticket, ticketHelper, ticketData);

            Template.BetChoice.ChoiceName.choiceName = BuildBetChoiceString(ticket.BetTeam);

            var excluding = BuildExcludingBlock(ticket.BetTeam, ticket.TransDesc);

            if (!string.IsNullOrWhiteSpace(excluding))
            {
                Template.BetChoiceMoreInfo.Show();
                Template.BetChoiceMoreInfo.betChoiceMoreInfo = excluding;
            }
        }

        private static string BuildBetChoiceString(string betTeam)
        {
            if (string.IsNullOrEmpty(betTeam))
            {
                return string.Empty;
            }

            var betChoice = betTeam.ToLowerInvariant().Replace(BetTeamValue.AOS, CoreBetList.AOS).Replace(":", "-");

            var halfTimeChoice = betChoice.Substring(0, betChoice.IndexOf("/", StringComparison.InvariantCulture)).Trim();
            var fullTimeChoice = betChoice.Remove(0, betChoice.IndexOf("/", StringComparison.InvariantCulture) + 1).Trim();

            betChoice = $"{CoreBetList.HalfTime} {halfTimeChoice} / {CoreBetList.FullTime} {fullTimeChoice}";

            return betChoice;
        }

        private static string FormatTransDesc(string transDesc, bool isFullTime)
        {
            var result = Regex.Replace(transDesc, ",\\s*", ", ").Replace(":", "-");
            var indexOfSlash = result.IndexOf("/", StringComparison.InvariantCulture);

            result = isFullTime
                ? result.Substring(indexOfSlash + 1, result.Length - (indexOfSlash + 1))
                : result.Substring(0, indexOfSlash);

            return result;
        }

        private static string BuildExcludingBlock(string betTeam, string transDesc)
        {
            if (string.IsNullOrEmpty(transDesc))
            {
                return string.Empty;
            }

            var betTeamValue = betTeam.ToLowerInvariant();

            if (betTeamValue.StartsWith(BetTeamValue.AOS, StringComparison.InvariantCulture)
                && betTeamValue.EndsWith(BetTeamValue.AOS, StringComparison.InvariantCulture))
            {
                return BuildHtExcludingBlock(transDesc) + "<br/>" + BuildFtExcludingBlock(transDesc);
            }

            if (betTeamValue.StartsWith(BetTeamValue.AOS, StringComparison.InvariantCulture)
                && !betTeamValue.EndsWith(BetTeamValue.AOS, StringComparison.InvariantCulture))
            {
                return BuildHtExcludingBlock(transDesc);
            }

            if (!betTeamValue.StartsWith(BetTeamValue.AOS, StringComparison.InvariantCulture)
                && betTeamValue.EndsWith(BetTeamValue.AOS, StringComparison.InvariantCulture))
            {
                return BuildFtExcludingBlock(transDesc);
            }

            return string.Empty;
        }

        private static string BuildHtExcludingBlock(string transDesc)
        {
            string[] excludingTag =
            {
                CoreBetList.AOSHTExcluding,
                ": ",
                FormatTransDesc(transDesc, false)
            };

            return string.Join(null, excludingTag);
        }

        private static string BuildFtExcludingBlock(string transDesc)
        {
            string[] excludingTag =
           {
                CoreBetList.AOSFTExcluding,
                ": ",
                FormatTransDesc(transDesc, true)
           };

            return string.Join(null, excludingTag);
        }
    }
}