namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using Fanex.BetList.Core.App_GlobalResources;
    using Fanex.BetList.Core.Entities;

    public class ChoiceCN1236 : BaseVirtualSportsChoiceCN88
    {
        protected override void BuildScore(ITicket ticket)
        {
            Template.Match.LiveScore.Visible = false;
        }

        protected override void BuildChoiceName(ITicket ticket, ITicketHelper ticketHelper)
        {
            Template.BetChoiceMoreInfo.Hide();
            Template.BetChoice.ChoiceValue.Hide();
            Template.BetChoice.ChoiceName.choiceName = string.Join(null, new[] { ticket.BetTeam, " ", CoreBetList.points });
        }
    }
}
