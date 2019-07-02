namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using Fanex.BetList.Core.App_GlobalResources;
    using Fanex.BetList.Core.Constants;
    using Fanex.BetList.Core.Entities;

    /// <summary>
    /// BAIO - FT Winning Margin 14 Way
    /// </summary>
    public class ChoiceCN601 : BaseChoiceCN88
    {
        protected const string BasketballRefId = "WMBasketball";

#pragma warning disable S1541 // Methods and properties should not be too complex

        protected override void BuildChoiceName(ITicket ticket, ITicketHelper ticketHelper)
#pragma warning restore S1541 // Methods and properties should not be too complex
        {
            var betTeam = string.Empty;

            switch (ticket.BetTeam.ToLowerInvariant())
            {
                case BetTeamValue.H1to2:
                    betTeam = string.Format(ticketHelper.GetResourceData(BasketballRefId, "1-2"), CoreBetList.Home);
                    break;

                case BetTeamValue.H3to6:
                    betTeam = string.Format(ticketHelper.GetResourceData(BasketballRefId, "3-6"), CoreBetList.Home);
                    break;

                case BetTeamValue.H7to9:
                    betTeam = string.Format(ticketHelper.GetResourceData(BasketballRefId, "7-9"), CoreBetList.Home);
                    break;

                case BetTeamValue.H10to13:
                    betTeam = string.Format(ticketHelper.GetResourceData(BasketballRefId, "10-13"), CoreBetList.Home);
                    break;

                case BetTeamValue.H14to16:
                    betTeam = string.Format(ticketHelper.GetResourceData(BasketballRefId, "14-16"), CoreBetList.Home);
                    break;

                case BetTeamValue.H17to20:
                    betTeam = string.Format(ticketHelper.GetResourceData(BasketballRefId, "17-20"), CoreBetList.Home);
                    break;

                case BetTeamValue.H21Over:
                    betTeam = string.Format(ticketHelper.GetResourceData(BasketballRefId, "21+"), CoreBetList.Home);
                    break;

                case BetTeamValue.A1to2:
                    betTeam = string.Format(ticketHelper.GetResourceData(BasketballRefId, "1-2"), CoreBetList.Away);
                    break;

                case BetTeamValue.A3to6:
                    betTeam = string.Format(ticketHelper.GetResourceData(BasketballRefId, "3-6"), CoreBetList.Away);
                    break;

                case BetTeamValue.A7to9:
                    betTeam = string.Format(ticketHelper.GetResourceData(BasketballRefId, "7-9"), CoreBetList.Away);
                    break;

                case BetTeamValue.A10to13:
                    betTeam = string.Format(ticketHelper.GetResourceData(BasketballRefId, "10-13"), CoreBetList.Away);
                    break;

                case BetTeamValue.A14to16:
                    betTeam = string.Format(ticketHelper.GetResourceData(BasketballRefId, "14-16"), CoreBetList.Away);
                    break;

                case BetTeamValue.A17to20:
                    betTeam = string.Format(ticketHelper.GetResourceData(BasketballRefId, "17-20"), CoreBetList.Away);
                    break;

                case BetTeamValue.A21Over:
                    betTeam = string.Format(ticketHelper.GetResourceData(BasketballRefId, "21+"), CoreBetList.Away);
                    break;

                default:
                    betTeam = string.Empty;
                    break;
            }

            Template.BetChoice.ChoiceName.choiceName = betTeam;
        }
    }
}