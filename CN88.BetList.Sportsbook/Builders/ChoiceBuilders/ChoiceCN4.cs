namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using Fanex.BetList.Core.App_GlobalResources;
    using Fanex.BetList.Core.Constants;
    using Fanex.BetList.Core.Entities;

    public class ChoiceCN4 : BaseChoiceCN88
    {
        protected override void BuildBetChoice(ITicket ticket, ITicketHelper ticketHelper, List<ITicketData> ticketData)
        {
            base.BuildBetChoice(ticket, ticketHelper, ticketData);

            var choice = ticket.BetTeam;
            Template.BetChoice.ChoiceName.choiceName =
                BetTeamValue.AOS == choice.ToLowerInvariant()
                    ? CoreBetList.AOS
                    : choice.Replace(":", "-");

            if (BetTeamValue.AOS == ticket.BetTeam.ToLowerInvariant()
                && !string.IsNullOrEmpty(ticket.TransDesc))
            {
                Template.BetChoiceMoreInfo.Show();
                Template.BetChoiceMoreInfo.betChoiceMoreInfo = $"{CoreBetList.Excluding}: {FormatTransDesc(ticket.TransDesc)}";
            }
        }

        private static string FormatTransDesc(string transDesc)
            => Regex.Replace(transDesc, ",\\s*", ", ").Replace(":", "-");

        protected override void BuildBetChoiceRtf(RTFHelper rtfHelper)
        {
            base.BuildBetChoiceRtf(rtfHelper);

            BuildBetChoiceMoreInfoRtf(rtfHelper);
        }

        protected virtual void BuildBetChoiceMoreInfoRtf(RTFHelper rtfHelper)
        {
            if (Template.BetChoiceMoreInfo != null && Template.BetChoiceMoreInfo.Visible)
            {
                rtfHelper.RTFRenderer.AddText($"\n{Template.BetChoiceMoreInfo.betChoiceMoreInfo.Replace("<br/>", "\n")}");
            }
        }
    }
}