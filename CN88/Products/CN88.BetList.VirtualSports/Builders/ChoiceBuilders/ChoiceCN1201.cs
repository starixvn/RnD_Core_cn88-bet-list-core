namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using System.Collections.Generic;
    using CN88.BetList.Core.Constants;
    using CN88.BetList.Core.Utils;
    using Fanex.BetList.Core.Entities;

    public class ChoiceCN1201 : BaseVirtualSportsChoiceCN88
    {
        protected override void BuildMatch(ITicket ticket, ITicketHelper ticketHelper)
        {
            base.BuildMatch(ticket, ticketHelper);

            Template.Match.VS.Hide();

            var isHomeTeam = ticket.Handicap1 > ticket.Handicap2 || (ticket.Handicap1 == 0 && ticket.Handicap2 == 0);
            var hdp = isHomeTeam ? ticket.Handicap1 : ticket.Handicap2;
            Template.Match.Handicap.handicap = hdp % VirtualSportsCommonConstant.Handicap_Half == 0
                ? hdp.ToHandicap()
                : $"{(hdp - VirtualSportsCommonConstant.Handicap_Quarter).ToHandicap()} / {(hdp + VirtualSportsCommonConstant.Handicap_Quarter).ToHandicap()}";

            Template.Match.Handicap.Show();
        }

        protected override void BuildBetChoice(ITicket ticket, ITicketHelper ticketHelper, List<ITicketData> ticketData)
        {
            base.BuildBetChoice(ticket, ticketHelper, ticketData);

            Template.BetChoiceMoreInfo.Hide();
            Template.BetChoice.ChoiceValue.Hide();
        }

        protected override string BuildVSText() => string.Empty;
    }
}
