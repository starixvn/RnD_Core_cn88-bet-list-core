namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using System.Collections.Generic;
    using Fanex.BetList.Core.App_GlobalResources;
    using Fanex.BetList.Core.Constants;
    using Fanex.BetList.Core.Entities;

    /// <summary>
    /// PH AIO Phase 3 - Time Of 1st Goal.
    /// </summary>
    public class ChoiceCN455 : BaseChoiceCN88
    {
        private readonly Dictionary<string, string> BetTeamMaps = new Dictionary<string, string>
        {
            ["1-10"] = "00:01-10:00",
            ["11-20"] = "10:01-20:00",
            ["21-30"] = "20:01-30:00",
            ["31-40"] = "30:01-40:00",
            ["41-50"] = "40:01-50:00",
            ["51-60"] = "50:01-60:00",
            ["61-70"] = "60:01-70:00",
            ["71-80"] = "70:01-80:00",
            ["81-90"] = $"80:01-{CoreBetList.FT455}"
        };

        protected override void BuildChoiceName(ITicket ticket, ITicketHelper ticketHelper)
        {
            var betTeam = ticket.BetTeam?.Trim()?.ToLowerInvariant();

            if (betTeam == BetTeamValue.NG)
            {
                betTeam = CoreBetList.NoGoal14;
            }
            else if (!string.IsNullOrEmpty(betTeam) && BetTeamMaps.ContainsKey(betTeam))
            {
                betTeam = BetTeamMaps[betTeam];
            }
            else
            {
                betTeam = string.Empty;
            }

            Template.BetChoice.ChoiceName.choiceName = betTeam;
        }
    }
}