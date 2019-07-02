namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using System.Collections.Generic;
    using Fanex.BetList.Core.App_GlobalResources;
    using Fanex.BetList.Core.Constants;
    using Fanex.BetList.Core.Entities;
    using Fanex.BetList.Core.Utils;

    public class ChoiceCN3 : BaseChoiceCN88
    {
        protected override void BuildBetChoice(ITicket ticket, ITicketHelper ticketHelper, List<ITicketData> ticketData)
        {
            base.BuildBetChoice(ticket, ticketHelper, ticketData);

            Template.BetChoice.ChoiceValue.Show();

            Template.BetChoice.ChoiceValue.choiceValue = ConvertByBetType.Hdp(ticket.Handicap1);

            CalculateChoiceName(ticket, ticketHelper);
        }

        protected virtual void CalculateChoiceName(ITicket ticket, ITicketHelper ticketHelper)
        {
            Template.BetChoice.ChoiceName.choiceName =
                BetTeamValue.H == ticket.BetTeam.ToLowerInvariant()
                ? CoreBetList.over
                : CoreBetList.under;
        }

        protected override void BuildBetChoiceRtf(RTFHelper rtfHelper)
        {
            if (Template.BetChoice != null && Template.BetChoice.Visible)
            {
                var odds = GetOddsValueFromHtml();

                var betChoiceText = string.Join(
                       string.Empty,
                       "\n",
                       $"{Template.BetChoice.ChoiceName.choiceName} {Template.BetChoice.ChoiceValue.choiceValue}",
                       " @ ",
                       odds);

                rtfHelper.RTFRenderer.AddText(betChoiceText);
            }
        }
    }
}
