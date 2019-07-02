namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using Fanex.BetList.Core.App_GlobalResources;
    using Fanex.BetList.Core.Constants;
    using Fanex.BetList.Core.Entities;

    /// <summary>
    /// Bet type name: Which Half First Goal
    /// </summary>
    public class ChoiceCN419 : BaseChoiceCN88
    {
        protected override void BuildChoiceName(ITicket ticket, ITicketHelper ticketHelper)
        {
            var betTeam = string.Empty;

            switch (ticket.BetTeam.ToLowerInvariant())
            {
                case BetTeamValue.OneH:
                    betTeam = CoreBetList.FirstHalf;
                    break;

                case BetTeamValue.TwoH:
                    betTeam = CoreBetList.SecondHalf;
                    break;

                case BetTeamValue.N:
                    betTeam = CoreBetList.lblNeither;
                    break;

                default:
                    betTeam = string.Empty;
                    break;
            }

            Template.BetChoice.ChoiceName.choiceName = betTeam;
        }
    }
}