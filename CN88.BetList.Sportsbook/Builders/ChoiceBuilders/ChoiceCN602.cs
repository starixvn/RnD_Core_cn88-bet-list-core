namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using Fanex.BetList.Core.App_GlobalResources;
    using Fanex.BetList.Core.Constants;
    using Fanex.BetList.Core.Entities;

    /// <summary>
    /// BAIO -  FT Winning Margin 12 Way
    /// </summary>
    public class ChoiceCN602 : ChoiceCN601
    {
#pragma warning disable S1541 // Methods and properties should not be too complex

        protected override void BuildChoiceName(ITicket ticket, ITicketHelper ticketHelper)
#pragma warning restore S1541 // Methods and properties should not be too complex
        {
            var betTeam = string.Empty;

            switch (ticket.BetTeam.ToLowerInvariant())
            {
                case BetTeamValue.H1to5:
                    betTeam = string.Format(ticketHelper.GetResourceData(BasketballRefId, "1-5"), CoreBetList.Home);
                    break;

                case BetTeamValue.H6to10:
                    betTeam = string.Format(ticketHelper.GetResourceData(BasketballRefId, "6-10"), CoreBetList.Home);
                    break;

                case BetTeamValue.H11to15:
                    betTeam = string.Format(ticketHelper.GetResourceData(BasketballRefId, "11-15"), CoreBetList.Home);
                    break;

                case BetTeamValue.H16to20:
                    betTeam = string.Format(ticketHelper.GetResourceData(BasketballRefId, "16-20"), CoreBetList.Home);
                    break;

                case BetTeamValue.H21to25:
                    betTeam = string.Format(ticketHelper.GetResourceData(BasketballRefId, "21-25"), CoreBetList.Home);
                    break;

                case BetTeamValue.H26Over:
                    betTeam = string.Format(ticketHelper.GetResourceData(BasketballRefId, "26+"), CoreBetList.Home);
                    break;

                case BetTeamValue.A1to5:
                    betTeam = string.Format(ticketHelper.GetResourceData(BasketballRefId, "1-5"), CoreBetList.Away);
                    break;

                case BetTeamValue.A6to10:
                    betTeam = string.Format(ticketHelper.GetResourceData(BasketballRefId, "6-10"), CoreBetList.Away);
                    break;

                case BetTeamValue.A11to15:
                    betTeam = string.Format(ticketHelper.GetResourceData(BasketballRefId, "11-15"), CoreBetList.Away);
                    break;

                case BetTeamValue.A16to20:
                    betTeam = string.Format(ticketHelper.GetResourceData(BasketballRefId, "16-20"), CoreBetList.Away);
                    break;

                case BetTeamValue.A21to25:
                    betTeam = string.Format(ticketHelper.GetResourceData(BasketballRefId, "21-25"), CoreBetList.Away);
                    break;

                case BetTeamValue.A26Over:
                    betTeam = string.Format(ticketHelper.GetResourceData(BasketballRefId, "26+"), CoreBetList.Away);
                    break;

                default:
                    betTeam = string.Empty;
                    break;
            }

            Template.BetChoice.ChoiceName.choiceName = betTeam;
        }
    }
}