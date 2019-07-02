namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using Fanex.BetList.Core.App_GlobalResources;
    using Fanex.BetList.Core.Entities;

    /// <summary>
    /// PH AIO Phase 3 - 1H Asian 1X2.
    /// </summary>
    public class ChoiceCN459 : BaseChoiceCN88
    {
        protected override void BuildChoiceName(ITicket ticket, ITicketHelper ticketHelper)
        {
            Template.BetChoice.ChoiceName.choiceName = $"{CoreBetList.HtAsian}{CoreBetList.Seperator1X2}{ticket.BetTeam?.ToUpperInvariant()}";
        }
    }
}