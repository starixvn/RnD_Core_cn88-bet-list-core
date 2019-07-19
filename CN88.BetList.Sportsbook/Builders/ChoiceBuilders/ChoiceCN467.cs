namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using System;
    using Fanex.BetList.Core.App_GlobalResources;
    using Fanex.BetList.Core.Entities;

    public class ChoiceCN467 : BaseChoiceCN88
    {
        protected override void BuildChoiceName(ITicket ticket, ITicketHelper ticketHelper)
        {
            Template.BetChoice.ChoiceName.choiceName = GetChoiceName(ticket);
        }

        private static string GetChoiceName(ITicket ticket)
        {
            var standardizedBetTeam = ticket.BetTeam?.ToUpperInvariant();
            if (string.IsNullOrWhiteSpace(standardizedBetTeam))
            {
                return string.Empty;
            }

            const int expectedNumberOfIndicators = 2;
            const int minimumIdicatorLength = 2;

            var totalGoalsIndicators = standardizedBetTeam.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

            if (totalGoalsIndicators.Length != expectedNumberOfIndicators)
            {
                return string.Empty;
            }

            var halfTimeTotalGoalsIndicator = totalGoalsIndicators[0].Trim();
            var fullTimeTotalGoalsIndicator = totalGoalsIndicators[1].Trim();
            var halfTimeTotalGoals = halfTimeTotalGoalsIndicator.Length >= minimumIdicatorLength
                ? halfTimeTotalGoalsIndicator.Substring(1)
                : string.Empty;
            var fullTimeTotalGoals = fullTimeTotalGoalsIndicator.Length >= minimumIdicatorLength
                ? fullTimeTotalGoalsIndicator.Substring(1)
                : string.Empty;

            if (string.IsNullOrEmpty(halfTimeTotalGoals) || string.IsNullOrEmpty(fullTimeTotalGoals))
            {
                return string.Empty;
            }

            return $"{CoreBetList.HalfTime} {halfTimeTotalGoals} / {CoreBetList.FullTime} {fullTimeTotalGoals}";
        }
    }
}
