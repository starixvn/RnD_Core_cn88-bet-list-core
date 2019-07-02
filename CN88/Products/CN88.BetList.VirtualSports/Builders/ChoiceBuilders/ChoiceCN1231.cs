namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using System.Collections.Generic;
    using Fanex.BetList.Core.Entities;
    using Fanex.BetList.Core.Utils;

    public class ChoiceCN1231 : BaseVirtualSportsChoiceCN88
    {
        protected override void BuildMatch(ITicket ticket, ITicketHelper ticketHelper)
        {
            Template.MatchByTeamId.Hide();
            Template.Match.Hide();
        }

        protected override void BuildKickOffTime(ITicket ticket, ITicketHelper ticketHelper)
        {
            Template.KickOffTime.Show();
            Template.KickOffTime.kickOffTime = CN88VirtualSportsChoiceUtils.ParseKickOffTime(ticket);
        }

        protected override void BuildMatchRtf(RTFHelper rtfHelper)
        {
        }

        protected override void BuildKickOffTimeRtf(RTFHelper rtfHelper)
        {
            rtfHelper.RTFRenderer.AddText($"\n{Template.KickOffTime.kickOffTime}");
        }

        protected override void BuildBetChoice(ITicket ticket, ITicketHelper ticketHelper, List<ITicketData> ticketData)
        {
            Template.BetChoiceMoreInfo.Hide();
            Template.BetChoice.ChoiceValue.Hide();

            Template.BetChoice.ChoiceName.choiceName = string.Join(null, new[] { ticket.MatchCode, " - ", ticketHelper.GetHorseTeamNameById(ticket.HomeId) });
        }

        protected override void BuildOdds(ITicket ticket, List<ITicketData> ticketData)
        {
            object oddsType = string.IsNullOrEmpty(ticket.OddsType) ? (object)0 : ticket.OddsType;

            Template.BetChoice.Odds.odds = ConvertByBetType.VirtualHorseRacingOdds(ticket.Odds, ticket.BetTypeId, oddsType);
        }
    }
}
