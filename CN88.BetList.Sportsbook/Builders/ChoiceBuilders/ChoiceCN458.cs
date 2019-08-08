namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using CN88.BetList.Core.Helpers;
    using Fanex.BetList.Core.Entities;

    /// <summary>
    /// PH AIO Phase 3 - Asian 1X2.
    /// </summary>
    public class ChoiceCN458 : BaseChoiceCN88
    {
        protected override void BuildChoiceName(ITicket ticket, ITicketHelper ticketHelper)
        {
            Template.BetChoice.ChoiceName.choiceName = CN88TicketHelper.Get1x2ChoiceValue(ticket, ticketHelper);
        }
    }
}
