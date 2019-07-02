namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using Fanex.BetList.Core.App_GlobalResources;
    using Fanex.BetList.Core.Entities;

    public class ChoiceCN1235 : BaseVirtualSportsChoiceCN88
    {
        protected override void BuildScore(ITicket ticket)
        {
            Template.Match.LiveScore.Visible = false;
        }

        protected override void BuildChoiceName(ITicket ticket, ITicketHelper ticketHelper)
        {
            Template.BetChoiceMoreInfo.Hide();
            Template.BetChoice.ChoiceValue.Hide();
            string betTeam;

            switch (ticket.BetTeam.Trim())
            {
                case "1":
                    betTeam = CoreBetList.virtualtennis_scorebet_win_0;
                    break;

                case "2":
                    betTeam = CoreBetList.virtualtennis_scorebet_win_15;
                    break;

                case "3":
                    betTeam = CoreBetList.virtualtennis_scorebet_win_30;
                    break;

                case "4":
                    betTeam = CoreBetList.virtualtennis_scorebet_win_40;
                    break;

                case "5":
                    betTeam = CoreBetList.virtualtennis_scorebet_0_win;
                    break;

                case "6":
                    betTeam = CoreBetList.virtualtennis_scorebet_15_win;
                    break;

                case "7":
                    betTeam = CoreBetList.virtualtennis_scorebet_30_win;
                    break;

                case "8":
                    betTeam = CoreBetList.virtualtennis_scorebet_40_win;
                    break;

                default:
                    betTeam = string.Empty;
                    break;
            }

            Template.BetChoice.ChoiceName.choiceName = betTeam;
        }
    }
}
