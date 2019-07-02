namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using System.Collections.Generic;
    using CN88.BetList.Core.AppResources;
    using Fanex.BetList.Core.Entities;

    public class ChoiceCN89 : BaseNumberGameChoiceCN88
    {
        protected override void BuildChoiceValue(ITicket ticket, ITicketHelper ticketHelper, List<ITicketData> ticketData)
        {
            var betTeam = string.Empty;

            switch (ticket.BetTeam)
            {
                case "1:1":
                    betTeam = CN88NumberGameLang.lblOverOdd;
                    break;

                case "1:2":
                    betTeam = CN88NumberGameLang.lblOverEven;
                    break;

                case "2:1":
                    betTeam = CN88NumberGameLang.lblUnderOdd;
                    break;

                case "2:2":
                    betTeam = CN88NumberGameLang.lblUnderEven;
                    break;

                default:
                    betTeam = string.Empty;
                    break;
            }

            Template.BetChoice.ChoiceName.choiceName = betTeam;
            Template.BetChoice.ChoiceValue = null;
        }
    }
}
