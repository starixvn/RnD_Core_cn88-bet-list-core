namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using CN88.BetList.Core.Helpers;
    using Fanex.BetList.Core.App_GlobalResources;
    using Fanex.BetList.Core.Constants;
    using Fanex.BetList.Core.Entities;

    public class ChoiceCN486 : BaseChoiceCN88
    {
        protected override void BuildChoiceName(ITicket ticket, ITicketHelper ticketHelper)
        {
            string choiceName;

            switch (ticket.BetTeam.ToLowerInvariant())
            {
                case BetTeamValue.H:
                    choiceName = ticketHelper.GetTeamNameById(ticket.HomeId);
                    break;

                case BetTeamValue.A:
                    choiceName = ticketHelper.GetTeamNameById(ticket.AwayId);
                    break;

                case BetTeamValue.N:
                    choiceName = CoreBetList.lblNeither;
                    break;

                default:
                    choiceName = string.Empty;
                    break;
            }

            Template.BetChoice.ChoiceName.choiceName = $"{choiceName} {CN88TicketHelper.GetHandicap(ticket.Handicap1)}";
        }
    }
}
