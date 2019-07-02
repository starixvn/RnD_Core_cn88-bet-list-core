namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using Fanex.BetList.Core.App_GlobalResources;
    using Fanex.BetList.Core.Constants;
    using Fanex.BetList.Core.Entities;

    /// <summary>
    /// PH AIO Phase 3 - Highest Scoring Half (2 Way).
    /// </summary>
    public class ChoiceCN452 : BaseChoiceCN88
    {
        protected override void BuildChoiceName(ITicket ticket, ITicketHelper ticketHelper)
        {
            string betTeam = ticket.BetTeam?.ToLowerInvariant();

            switch (betTeam)
            {
                case BetTeamValue.OneH:
                    betTeam = CoreBetList.FirstHalf;
                    break;

                case BetTeamValue.TwoH:
                    betTeam = CoreBetList.SecondHalf;
                    break;

                default:
                    betTeam = string.Empty;
                    break;
            }

            Template.BetChoice.ChoiceName.choiceName = betTeam;
        }
    }
}