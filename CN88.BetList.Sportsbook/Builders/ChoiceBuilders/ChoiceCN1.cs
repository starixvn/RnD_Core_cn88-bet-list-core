namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using System;
    using System.Collections.Generic;
    using CN88.BetList.Core.Constants;
    using CN88.BetList.Core.Utils;
    using Fanex.BetList.Core.Entities;

    public class ChoiceCN1 : BaseChoiceCN88
    {
        protected override void BuildMatch(ITicket ticket, ITicketHelper ticketHelper)
        {
            base.BuildMatch(ticket, ticketHelper);

            Template.Match.VS.Hide();
            Template.Match.Handicap.Show();
            Template.BetChoice.ChoiceValue.Hide();
        }

        protected override void BuildChoice(ITicket ticket, ITicketHelper ticketHelper, List<ITicketData> ticketData)
        {
            base.BuildChoice(ticket, ticketHelper, ticketData);

            CalculateHandicap(ticket);
        }

        private void CalculateHandicap(ITicket ticket)
        {
            var isHomeOverAway = ticket.Handicap1 >= ticket.Handicap2;

            SetHandicap(ticket, isHomeOverAway);
            SwitchTeam(ticket, isHomeOverAway);
        }

        protected virtual void SwitchTeam(ITicket ticket, bool isHomeOverAway)
        {
            if (!isHomeOverAway)
            {
                var awayTeam = Template.Match.awayTeam;
                Template.Match.awayTeam = Template.Match.homeTeam;
                Template.Match.homeTeam = awayTeam;

                var awayTeamId = Template.MatchByTeamId.awayTeamId;
                Template.MatchByTeamId.awayTeamId = Template.MatchByTeamId.homeTeamId;
                Template.MatchByTeamId.homeTeamId = awayTeamId;

                SwitchScore(ticket);
            }
        }

        protected virtual void SwitchScore(ITicket ticket)
        {
            if (!IsShowLiveText(ticket.SportTypeId))
            {
                Template.Match.LiveScore.liveScore = $"({ticket.LiveAwayScore}-{ticket.LiveHomeScore})";
            }
        }

        private void SetHandicap(ITicket ticket, bool isHomeOverAway)
        {
            var handicapValue = isHomeOverAway
                ? Math.Abs(ticket.Handicap1)
                : Math.Abs(ticket.Handicap2);
            Template.Match.Handicap.handicap = handicapValue % SportsbookCommonConstant.Handicap_Half == 0
                ? handicapValue.ToHandicap()
                : $"{(handicapValue - SportsbookCommonConstant.Handicap_Quarter).ToHandicap()} / {(handicapValue + SportsbookCommonConstant.Handicap_Quarter).ToHandicap()}";
        }

        protected override string BuildVSText()
            => Template.Match?.Handicap?.handicap;
    }
}
