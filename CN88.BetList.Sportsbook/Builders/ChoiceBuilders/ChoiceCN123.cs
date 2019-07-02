namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using Fanex.BetList.Core.App_GlobalResources;
    using Fanex.BetList.Core.Constants;
    using Fanex.BetList.Core.Entities;

    /// <summary>
    /// Draw no draw.
    /// </summary>
    public class ChoiceCN123 : BaseChoiceCN88
    {
        protected override void BuildChoiceName(ITicket ticket, ITicketHelper ticketHelper)
        {
            bool betHomeTeam = ticket.BetTeam == BetTeamValue.H;
            var betTeam = betHomeTeam ? CoreBetList.lblDraw : CoreBetList.lblNoDraw;

            Template.BetChoice.ChoiceName.choiceName = betTeam;
        }
    }
}