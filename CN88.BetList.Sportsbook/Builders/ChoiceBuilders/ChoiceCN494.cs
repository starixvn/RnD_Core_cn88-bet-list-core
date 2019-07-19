namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using System.Text.RegularExpressions;
    using Fanex.BetList.Core.App_GlobalResources;
    using Fanex.BetList.Core.Constants;
    using Fanex.BetList.Core.Entities;

    public class ChoiceCN494 : BaseChoiceCN88
    {
        protected override void BuildChoiceName(ITicket ticket, ITicketHelper ticketHelper)
        {
            var isAOS = ticket.BetTeam.ToLowerInvariant() == BetTeamValue.AOS;
            var choiceName = isAOS ? CoreBetList.AOS : ticket.BetTeam.Trim();
            Template.BetChoice.ChoiceName.choiceName = choiceName;

            if (isAOS && !string.IsNullOrEmpty(ticket.TransDesc))
            {
                Template.BetChoiceMoreInfo.Show();
                Template.BetChoiceMoreInfo.betChoiceMoreInfo = $"{CoreBetList.Excluding}: {Regex.Replace(ticket.TransDesc, ",\\s*", ", ")}";
            }
        }
    }
}
