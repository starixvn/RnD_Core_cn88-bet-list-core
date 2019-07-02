namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using Fanex.BetList.Core.App_GlobalResources;
    using Fanex.BetList.Core.Constants;
    using Fanex.BetList.Core.Entities;

    /// <summary>
    /// Away No Bet.
    /// </summary>
    public class ChoiceCN122 : BaseChoiceCN88
    {
        protected override void BuildChoiceName(ITicket ticket, ITicketHelper ticketHelper)
        {
            bool betHomeTeam = ticket.BetTeam != null && ticket.BetTeam.Contains(BetTeamValue.H);
            var betTeam = betHomeTeam ? Template.Match.homeTeam : CoreBetList.lblDraw;

            Template.BetChoice.ChoiceName.choiceName = betTeam;
        }
    }
}