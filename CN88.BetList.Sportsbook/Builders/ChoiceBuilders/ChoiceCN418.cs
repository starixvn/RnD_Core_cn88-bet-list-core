namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using Fanex.BetList.Core.App_GlobalResources;
    using Fanex.BetList.Core.Constants;
    using Fanex.BetList.Core.Entities;

    /// <summary>
    /// Bet type name: Both Teams to Score/ Total Goal
    /// </summary>
    public class ChoiceCN418 : ChoiceCN3
    {
        protected override void CalculateChoiceName(ITicket ticket, ITicketHelper ticketHelper)
        {
            var betTeamPattern = $"{{0}} & {{1}}";
            var betTeam = string.Empty;

#pragma warning disable S131 // "switch/Select" statements should end with "default/Case Else" clauses
            switch (ticket.BetTeam.ToLowerInvariant())
#pragma warning restore S131 // "switch/Select" statements should end with "default/Case Else" clauses
            {
                case BetTeamValue.YO:
                    betTeam = string.Format(betTeamPattern, CoreBetList.lblYes, CoreBetList.over);
                    break;

                case BetTeamValue.YU:
                    betTeam = string.Format(betTeamPattern, CoreBetList.lblYes, CoreBetList.under);
                    break;

                case BetTeamValue.NO:
                    betTeam = string.Format(betTeamPattern, CoreBetList.lblNo, CoreBetList.over);
                    break;

                case BetTeamValue.NU:
                    betTeam = string.Format(betTeamPattern, CoreBetList.lblNo, CoreBetList.under);
                    break;
            }

            Template.BetChoice.ChoiceName.choiceName = betTeam;
        }
    }
}