namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using System.Collections.Generic;
    using Fanex.BetList.Core.Entities;

    public class ChoiceCN1037 : ChoiceCN1031
    {
        protected override void BuildBetChoice(ITicket ticket, ITicketHelper ticketHelper, List<ITicketData> ticketData)
        {
            base.BuildBetChoice(ticket, ticketHelper, ticketData);

            const int choiceNumber1 = 101;
            const int choiceNumber6 = 106;

            int choiceId = 0;
            if (int.TryParse(CN88LotteryUtils.ParseTransDesc(ticket.TransDesc)["choiceId"], out choiceId) &&
                choiceNumber1 <= choiceId &&
                choiceId <= choiceNumber6)
            {
                Template.BetChoice.BetChoiceSplitChar.Hide();
                Template.BetChoice.Odds.Hide();
            }
        }

        protected override void BuildBetChoiceRtf(RTFHelper rtfHelper)
        {
            if (Template.BetChoice == null || !Template.BetChoice.Visible)
            {
                return;
            }

            if (Template.BetChoice.Odds.Visible)
            {
                base.BuildBetChoiceRtf(rtfHelper);
            }
            else
            {
                rtfHelper.RTFRenderer.AddText($"\n{Template.BetChoice.ChoiceName.choiceName}");
            }
        }
    }
}
