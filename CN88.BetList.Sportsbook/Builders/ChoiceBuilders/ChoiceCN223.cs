namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using Fanex.BetList.Core.Entities;

    /// <summary>
    /// Fast Markets: What will happen first in next 1 minute
    /// </summary>
    public class ChoiceCN223 : BaseChoiceCN88
    {
        protected override void BuildChoiceName(ITicket ticket, ITicketHelper ticketHelper)
        {
            var choice = ticketHelper.GetFastMarketSituation(
                ticket.BetTypeId.ToString(),
                ticket.BetTeam,
                ticket.Handicap1,
                ticket.Handicap2);

            Template.BetChoice.ChoiceName.choiceName = choice;
        }
    }
}