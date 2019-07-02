namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using System.Collections.Generic;
    using Fanex.BetList.Core.App_GlobalResources;
    using Fanex.BetList.Core.Entities;

    /// <summary>
    /// Bet Type: HT/FT.
    /// </summary>
    public class ChoiceCN16 : BaseChoiceCN88
    {
        private readonly Dictionary<string, string> betTeamPatterns
                = new Dictionary<string, string>
                {
                    { "0:0", CoreBetList.dd },
                    { "0:1", CoreBetList.dh },
                    { "0:2", CoreBetList.da },
                    { "1:0", CoreBetList.hd },
                    { "1:1", CoreBetList.hh },
                    { "1:2", CoreBetList.ha },
                    { "2:0", CoreBetList.ad },
                    { "2:1", CoreBetList.ah },
                    { "2:2", CoreBetList.aa }
                };

        protected override void BuildChoiceName(ITicket ticket, ITicketHelper ticketHelper)
        {
            Template.BetChoice.ChoiceName.choiceName =
                (!string.IsNullOrWhiteSpace(ticket.BetTeam) && betTeamPatterns.ContainsKey(ticket.BetTeam))
                ? betTeamPatterns[ticket.BetTeam]
                : string.Empty;
        }
    }
}