namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using System;
    using Fanex.BetList.Core.App_GlobalResources;
    using Fanex.BetList.Core.Constants;
    using Fanex.BetList.Core.Entities;
    using Fanex.BetList.Core.Utils;

    /// <summary>
    /// 3-way handicap.
    /// </summary>
    public class ChoiceCN28 : BaseChoiceCN88
    {
        protected override void BuildChoiceName(ITicket ticket, ITicketHelper ticketHelper)
        {
            string teamName;
            string handicap;
            decimal hdp1 = ticket.Handicap1;
            decimal hdp2 = ticket.Handicap2;

            if (ticket.BetTeam == BetTeamValue.NumberOne)
            {
                teamName = Template.Match.homeTeam;
                handicap = Formatter.FormatSignNumber((int)(hdp2 - hdp1));
            }
            else if (ticket.BetTeam == BetTeamValue.NumberTwo)
            {
                teamName = Template.Match.awayTeam;
                handicap = Formatter.FormatSignNumber((int)(hdp1 - hdp2));
            }
            else
            {
                teamName = CoreBetList.lblDraw;
                if (hdp1 - hdp2 > 0)
                {
                    handicap = CoreBetList.a;
                }
                else if (hdp1 - hdp2 < 0)
                {
                    handicap = CoreBetList.h;
                }
                else
                {
                    handicap = string.Empty;
                }

                handicap += Formatter.FormatSignNumber((int)Math.Abs(hdp2 - hdp1));
            }

            Template.BetChoice.ChoiceName.choiceName = string.Join(null, new[] { teamName, " (", handicap, ")" });
        }
    }
}