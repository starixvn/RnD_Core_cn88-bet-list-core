namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using Fanex.BetList.Core.App_GlobalResources;
    using Fanex.BetList.Core.Constants;
    using Fanex.BetList.Core.Entities;

    /// <summary>
    /// BAIO - Quarter X Winning Margin 7 Way
    /// </summary>
    public class ChoiceCN614 : ChoiceCN601
    {
        protected override void BuildChoiceName(ITicket ticket, ITicketHelper ticketHelper)
        {
            var betTeam = string.Empty;

            switch (ticket.BetTeam.ToLowerInvariant())
            {
                case BetTeamValue.H1to4:
                    betTeam = string.Format(ticketHelper.GetResourceData(BasketballRefId, "1-4"), CoreBetList.Home);
                    break;

                case BetTeamValue.H5to8:
                    betTeam = string.Format(ticketHelper.GetResourceData(BasketballRefId, "5-8"), CoreBetList.Home);
                    break;

                case BetTeamValue.H9Over:
                    betTeam = string.Format(ticketHelper.GetResourceData(BasketballRefId, "9+"), CoreBetList.Home);
                    break;

                case BetTeamValue.D:
                    betTeam = ticketHelper.GetResourceData(BasketballRefId, "D");
                    break;

                case BetTeamValue.A1to4:
                    betTeam = string.Format(ticketHelper.GetResourceData(BasketballRefId, "1-4"), CoreBetList.Away);
                    break;

                case BetTeamValue.A5to8:
                    betTeam = string.Format(ticketHelper.GetResourceData(BasketballRefId, "5-8"), CoreBetList.Away);
                    break;

                case BetTeamValue.A9Over:
                    betTeam = string.Format(ticketHelper.GetResourceData(BasketballRefId, "9+"), CoreBetList.Away);
                    break;

                default:
                    betTeam = string.Empty;
                    break;
            }

            Template.BetChoice.ChoiceName.choiceName = betTeam;
        }
    }
}