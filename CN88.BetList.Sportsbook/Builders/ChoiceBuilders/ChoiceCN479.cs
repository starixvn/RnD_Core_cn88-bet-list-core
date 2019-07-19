namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using CN88.BetList.Core.AppResources;
    using Fanex.BetList.Core.Constants;
    using Fanex.BetList.Core.Entities;
    using Fanex.BetList.Core.Utils;

    public class ChoiceCN479 : BaseChoiceCN88
    {
        protected override void BuildChoiceName(ITicket ticket, ITicketHelper ticketHelper)
        {
            var choiceName = ticket.BetTeam.ToLowerInvariant() == BetTeamValue.Y
                ? CN88SportsbookResources.CornerBefore
                : CN88SportsbookResources.NoCornerBefore;
            Template.BetChoice.ChoiceName.choiceName = string.Format(choiceName, ConvertByBetType.Hdp(ticket.Handicap1));
        }
    }
}
