namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using System;
    using System.Collections.Generic;
    using Fanex.BetList.Core.App_GlobalResources;
    using Fanex.BetList.Core.Constants;
    using Fanex.BetList.Core.Entities;

    public class ChoiceCN2807 : ChoiceCN2801
    {
        public const string BasketballRefId = "WMBasketball";

        protected override void BuildScore(ITicket ticket)
        {
            Template.Match.LiveScore.Visible = false;
        }

        protected override void BuildBetChoice(ITicket ticket, ITicketHelper ticketHelper, List<ITicketData> ticketData)
        {
            Template.BetChoiceMoreInfo.Hide();
            Template.BetChoice.ChoiceValue.Hide();

            string betTeam = ticket.BetTeam.ToLowerInvariant();

            if (betTeam.Length > 1)
            {
                string resourceId = betTeam.Substring(1);
                string betOptionFormat = ticketHelper.GetResourceData(BasketballRefId, resourceId);
                string teamName = betTeam.StartsWith(BetTeamValue.H, StringComparison.InvariantCultureIgnoreCase)
                    ? CoreBetList.Home
                    : CoreBetList.Away;

                if (!string.IsNullOrEmpty(betOptionFormat))
                {
                    Template.BetChoice.ChoiceName.choiceName = string.Format(betOptionFormat, teamName);
                    return;
                }
            }

            Template.BetChoice.ChoiceName.choiceName = string.Empty;
        }

        protected override void BuildKickOffTime(ITicket ticket, ITicketHelper ticketHelper)
        {
            Template.KickOffTime.Hide();
        }

        protected override void BuildKickOffTimeRtf(RTFHelper rtfHelper) { }
    }
}
