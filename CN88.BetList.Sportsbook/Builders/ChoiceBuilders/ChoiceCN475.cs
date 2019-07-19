namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using CN88.BetList.Core.AppResources;
    using CN88.BetList.Core.Helpers;
    using Fanex.BetList.Core.App_GlobalResources;
    using Fanex.BetList.Core.Constants;
    using Fanex.BetList.Core.Entities;

    public class ChoiceCN475 : BaseChoiceCN88
    {
        protected override void BuildChoiceName(ITicket ticket, ITicketHelper ticketHelper)
        {
            string choiceName;
            switch (ticket.BetTeam.ToLowerInvariant())
            {
                case BetTeamValue.O:
                    choiceName = CoreBetList.over;
                    break;

                case BetTeamValue.U:
                    choiceName = CoreBetList.under;
                    break;

                case BetTeamValue.E:
                    choiceName = CN88SportsbookResources.Exact;
                    break;

                default:
                    choiceName = string.Empty;
                    break;
            }

            Template.BetChoice.ChoiceName.choiceName = $"{choiceName} {CN88TicketHelper.GetHandicap(ticket.Handicap1)}";
        }
    }
}
