namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using Fanex.BetList.Core.App_GlobalResources;
    using Fanex.BetList.Core.Constants;
    using Fanex.BetList.Core.Entities;

    public class ChoiceCN2707 : BaseVirtualSportsChoiceCN88
    {
        private string _excludingScores;

        protected override void BuildBetChoice(ITicket ticket, ITicketHelper ticketHelper, List<ITicketData> ticketData)
        {
            Template.BetChoiceMoreInfo.Hide();
            Template.BetChoice.ChoiceValue.Hide();

            string choice = ticket.BetTeam;

            choice = BetTeamValue.AOS == choice.ToLowerInvariant() ? CoreBetList.AOS : choice.Replace(':', '-');

            Template.BetChoice.ChoiceName.choiceName = choice;

            _excludingScores = CN88VirtualSportsChoiceUtils.ParseExcludingScoresInfo(ticket.TransDesc);

            if (BetTeamValue.AOS == ticket.BetTeam.ToLowerInvariant())
            {
                if (string.IsNullOrEmpty(_excludingScores))
                {
                    return;
                }

                Template.MoreInfo.Visible = true;
                Template.MoreInfo.SetValue(BuildExcludingBlock(_excludingScores));
            }
        }

        protected override void BuildKickOffTime(ITicket ticket, ITicketHelper ticketHelper)
        {
            Template.KickOffTime.Show();
            Template.KickOffTime.kickOffTime = CN88VirtualSportsChoiceUtils.ParseMatchInfo(ticket.TransDesc, ticketHelper);
        }

        protected override void BuildBetChoiceRtf(RTFHelper rtfHelper)
        {
            var odds = GetOddsValueFromHtml();

            var betChoiceText = $"\n{Template.BetChoice.ChoiceName.choiceName} @ {odds}";

            rtfHelper.RTFRenderer.AddText(betChoiceText);
            rtfHelper.RTFRenderer.AddText($"\n{CoreBetList.Excluding}: {FormatExcludingList(_excludingScores)}");
        }

        private static string BuildExcludingBlock(string excludingList)
            => $"<div class=\"excluding-choices\">{CoreBetList.Excluding}: {FormatExcludingList(excludingList)}</div>";

        private static string FormatExcludingList(string excludingList)
            => Regex.Replace(excludingList, ",\\s*", ", ").Replace(":", "-");
    }
}
