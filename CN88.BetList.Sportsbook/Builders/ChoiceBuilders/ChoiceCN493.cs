namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using System;
    using System.Text.RegularExpressions;
    using Fanex.BetList.Core.App_GlobalResources;
    using Fanex.BetList.Core.Constants;
    using Fanex.BetList.Core.Entities;

    public class ChoiceCN493 : BaseChoiceCN88
    {
        protected override void BuildChoiceName(ITicket ticket, ITicketHelper ticketHelper)
        {
            var memberChoice = string.Empty;
            if (ticket.BetTeam.ToLowerInvariant() == BetTeamValue.AOS)
            {
                memberChoice = CoreBetList.AOS;
                if (!string.IsNullOrEmpty(ticket.TransDesc))
                {
                    Template.BetChoiceMoreInfo.Show();
                    Template.BetChoiceMoreInfo.betChoiceMoreInfo = $"{CoreBetList.Excluding}: {Regex.Replace(ticket.TransDesc, ",\\s*", ", ")}";
                }
            }
            else
            {
                var parts = ticket.BetTeam.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                const int expectedNumberOfTotalCorners = 2;

                if (parts.Length == expectedNumberOfTotalCorners)
                {
                    memberChoice = $"{CoreBetList.HalfTime} {parts[0].Trim()} / {CoreBetList.FullTime} {parts[1].Trim()}";
                }
            }

            Template.BetChoice.ChoiceName.choiceName = memberChoice;
        }
    }
}
