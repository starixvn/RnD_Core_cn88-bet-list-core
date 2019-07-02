namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using Fanex.BetList.Core.App_GlobalResources;
    using Fanex.BetList.Core.Entities;

    /// <summary>
    ///  Choice for bet type 128 HT/FT Odd/Even.
    /// </summary>
    public class ChoiceCN128 : BaseChoiceCN88
    {
        protected override void BuildChoiceName(ITicket ticket, ITicketHelper ticketHelper)
        {
            var betTeam = string.Empty;

#pragma warning disable S131 // "switch/Select" statements should end with "default/Case Else" clauses
            switch (ticket.BetTeam)
#pragma warning restore S131 // "switch/Select" statements should end with "default/Case Else" clauses
            {
                case "oo":
                    betTeam = CoreBetList.oo;
                    break;

                case "oe":
                    betTeam = CoreBetList.oe;
                    break;

                case "eo":
                    betTeam = CoreBetList.eo;
                    break;

                case "ee":
                    betTeam = CoreBetList.ee;
                    break;
            }

            Template.BetChoice.ChoiceName.choiceName = betTeam;
        }
    }
}