namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using Fanex.BetList.Core.App_GlobalResources;
    using Fanex.BetList.Core.Constants;
    using Fanex.BetList.Core.Entities;

    public class ChoiceCN496 : BaseChoiceCN88
    {
        protected override void BuildChoiceName(ITicket ticket, ITicketHelper ticketHelper)
        {
            string choiceName;
            switch (ticket.BetTeam.ToLowerInvariant())
            {
                case BetTeamValue.OneH:
                    choiceName = CoreBetList.FirstHalf;
                    break;
                case BetTeamValue.TwoH:
                    choiceName = CoreBetList.SecondHalf;
                    break;
                case BetTeamValue.Tie:
                    choiceName = CoreBetList.Tie;
                    break;
                default:
                    choiceName = string.Empty;
                    break;
            }

            Template.BetChoice.ChoiceName.choiceName = choiceName;
        }
    }
}
