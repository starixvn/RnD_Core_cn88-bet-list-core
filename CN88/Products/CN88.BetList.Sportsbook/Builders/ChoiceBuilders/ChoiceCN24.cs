namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using System;
    using Fanex.BetList.Core.App_GlobalResources;
    using Fanex.BetList.Core.Constants;
    using Fanex.BetList.Core.Entities;

    /// <summary>
    /// Double Chance.
    /// </summary>
    public class ChoiceCN24 : BaseChoiceCN88
    {
        protected override void BuildChoiceName(ITicket ticket, ITicketHelper ticketHelper)
        {
            string betTeam = ticket.BetTeam;

            if (!string.IsNullOrEmpty(betTeam) && betTeam.Length == 2)
            {
                var firstChance = string.Equals(BetTeamValue.NumberOne, betTeam[0].ToString(), StringComparison.InvariantCultureIgnoreCase)
                        ? CoreBetList.Home
                        : CoreBetList.Away;
                var secondChance = string.Equals(BetTeamValue.X, betTeam[1].ToString(), StringComparison.InvariantCultureIgnoreCase)
                        ? CoreBetList.lblDraw
                        : CoreBetList.Away;

                Template.BetChoice.ChoiceName.choiceName = $"{firstChance} {CoreBetList.lblOr} {secondChance}";
            }
            else
            {
                Template.BetChoice.ChoiceName.choiceName = string.Empty;
            }
        }
    }
}