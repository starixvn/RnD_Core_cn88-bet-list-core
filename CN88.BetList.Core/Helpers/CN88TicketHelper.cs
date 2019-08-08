namespace CN88.BetList.Core.Helpers
{
    using CN88.BetList.Core.Utils;
    using Fanex.BetList.Core.App_GlobalResources;
    using Fanex.BetList.Core.Constants;
    using Fanex.BetList.Core.Entities;

    public static class CN88TicketHelper
    {
        public const decimal Handicap_Half = 0.5m;
        public const decimal Handicap_Quarter = 0.25m;

        public static string Get1x2ChoiceValue(ITicket ticket, ITicketHelper ticketHelper)
        {
            var result = string.Empty;

            switch (ticket.BetTeam?.ToLowerInvariant())
            {
                case BetTeamValue.NumberOne:
                    result = ticketHelper.GetTeamNameById(ticket.HomeId);
                    break;
                case BetTeamValue.NumberTwo:
                    result = ticketHelper.GetTeamNameById(ticket.AwayId);
                    break;
                case BetTeamValue.X:
                    result = CoreBetList.draw;
                    break;
                default:
                    result = string.Empty;
                    break;
            }

            return result;
        }

        public static string GetHandicap(decimal handicapValue)
        {
            var result = handicapValue % Handicap_Half == 0
                ? handicapValue.ToHandicap()
                : $"{(handicapValue - Handicap_Quarter).ToHandicap()} / {(handicapValue + Handicap_Quarter).ToHandicap()}";

            return result;
        }
    }
}
