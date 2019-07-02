namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using Fanex.BetList.Core.Entities;

    public class ChoiceCN1220 : BaseVirtualSportsChoiceCN88
    {
        protected override void BuildMatch(ITicket ticket, ITicketHelper ticketHelper)
        {
            base.BuildMatch(ticket, ticketHelper);

            Template.MatchByTeamId.Hide();
        }
    }
}
