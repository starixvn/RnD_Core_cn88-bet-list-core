namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using System;
    using System.Collections.Generic;
    using Fanex.BetList.Core.App_GlobalResources;
    using Fanex.BetList.Core.Constants;
    using Fanex.BetList.Core.Entities;

    public class ChoiceCN1224 : BaseVirtualSportsChoiceCN88
    {
        protected override void BuildBetChoice(ITicket ticket, ITicketHelper ticketHelper, List<ITicketData> ticketData)
        {
            Template.BetChoiceMoreInfo.Hide();
            Template.BetChoice.ChoiceValue.Hide();

            string betTeam = ticket.BetTeam;

            if (!string.IsNullOrEmpty(betTeam) && betTeam.Length == 2)
            {
                var firstChance = string.Equals(BetTeamValue.NumberOne, betTeam[0].ToString(), StringComparison.InvariantCultureIgnoreCase)
                        ? CoreBetList.Home
                        : CoreBetList.Away;
                var secondChance = string.Equals(BetTeamValue.X, betTeam[1].ToString(), StringComparison.InvariantCultureIgnoreCase)
                        ? CoreBetList.lblDraw
                        : CoreBetList.Away;

                Template.BetChoice.ChoiceName.choiceName = $"{firstChance}<span class=\"underdog\"> {CoreBetList.lblOr} </span>{secondChance}";
            }
            else
            {
                Template.BetChoice.ChoiceName.choiceName = string.Empty;
            }
        }
    }
}
