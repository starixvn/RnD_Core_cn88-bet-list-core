namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using Fanex.BetList.Core.Entities;

    public class ChoiceCN473 : BaseChoiceCN88
    {
        protected override void BuildChoiceName(ITicket ticket, ITicketHelper ticketHelper)
        {
            Template.BetChoice.ChoiceName.choiceName = ticket.BetTeam;
        }
    }
}
