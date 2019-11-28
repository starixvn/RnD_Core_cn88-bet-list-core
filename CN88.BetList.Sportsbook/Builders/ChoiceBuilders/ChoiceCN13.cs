namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using Fanex.BetList.Core.App_GlobalResources;
    using Fanex.BetList.Core.Constants;
    using Fanex.BetList.Core.Entities;

    /// <summary>
    /// Clean Sheet.
    /// </summary>
    public class ChoiceCN13 : BaseChoiceCN88
    {
        protected override void BuildChoiceName(ITicket ticket, ITicketHelper ticketHelper)
        {
            string team = ticket.BetTeam != null && ticket.BetTeam.ToLowerInvariant().Contains(BetTeamValue.H) ? Template.Match.homeTeam : Template.Match.awayTeam;
            string yesNo = ticket.BetTeam != null && ticket.BetTeam.ToLowerInvariant().Contains(BetTeamValue.Y) ? CoreBetList.lblYes : CoreBetList.lblNo;

            Template.BetChoice.ChoiceName.choiceName = string.Join(null, new[] { team, " ", yesNo.ToUpperInvariant() });
        }
    }
}
