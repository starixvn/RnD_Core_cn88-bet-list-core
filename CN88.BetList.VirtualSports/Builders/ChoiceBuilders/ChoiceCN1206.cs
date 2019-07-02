namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using System.Collections.Generic;
    using Fanex.BetList.Core.App_GlobalResources;
    using Fanex.BetList.Core.Entities;

    public class ChoiceCN1206 : BaseVirtualSportsChoiceCN88
    {
        protected override void BuildBetChoice(ITicket ticket, ITicketHelper ticketHelper, List<ITicketData> ticketData)
        {
            Template.BetChoiceMoreInfo.Hide();
            Template.BetChoice.ChoiceValue.Hide();

            // &nbsp; because export format
            var betTeam = string.Empty;

            switch (ticket.BetTeam.ToLowerInvariant())
            {
                case "4-over":
                case "4&over":
                    betTeam = CoreBetList.FourAndOver;
                    break;

                case "7-over":
                case "7&over":
                    betTeam = CoreBetList.SevenAndOver;
                    break;

                default:
                    betTeam = ticket.BetTeam.ToLowerInvariant();
                    break;
            }

            Template.BetChoice.ChoiceName.choiceName = betTeam;
        }
    }
}
