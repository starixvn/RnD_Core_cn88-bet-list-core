namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using Fanex.BetList.Core.Entities;
    using Fanex.BetList.Core.Utils;

    /// <summary>
    /// Fast Markets: Next 1 minute.
    /// </summary>
    public class ChoiceCN221 : ChoiceCN3
    {
        protected override void CalculateChoiceName(ITicket ticket, ITicketHelper ticketHelper)
        {
            var choice = ticketHelper.GetFastMarketSituation(
                ticket.BetTypeId.ToString(),
                ticket.BetTeam,
                ticket.Handicap1,
                ticket.Handicap2);

            Template.BetChoice.ChoiceName.choiceName = choice;
            Template.BetChoice.ChoiceValue.choiceValue = ConvertByBetType.Hdp(ticket.OddsSpread);
        }
    }
}