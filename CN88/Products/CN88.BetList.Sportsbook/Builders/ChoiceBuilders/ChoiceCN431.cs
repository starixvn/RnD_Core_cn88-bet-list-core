namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using Fanex.BetList.Core.App_GlobalResources;
    using Fanex.BetList.Core.Constants;
    using Fanex.BetList.Core.Entities;

    public class ChoiceCN431 : BaseChoiceCN88
    {
        protected override void BuildChoiceName(ITicket ticket, ITicketHelper ticketHelper)
        {
            var betTeam = string.Empty;
            string betTeamTemplate = "{0} " + CoreBetList.lblOr + " {1}";

            switch (ticket.BetTeam.ToLowerInvariant())
            {
                case BetTeamValue.HD:
                    betTeam = string.Format(betTeamTemplate, CoreBetList.Home, CoreBetList.draw);
                    break;

                case BetTeamValue.HA:
                    betTeam = string.Format(betTeamTemplate, CoreBetList.Home, CoreBetList.Away);
                    break;

                case BetTeamValue.DA:
                    betTeam = string.Format(betTeamTemplate, CoreBetList.Away, CoreBetList.draw);
                    break;

                default:
                    betTeam = string.Empty;
                    break;
            }

            Template.BetChoice.ChoiceName.choiceName = betTeam;
        }
    }
}