namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Fanex.BetList.Core.Entities;
    using Fanex.BetList.Core.Utils.StringExt;
    using Fanex.BetList.Core.Utils.TicketHelperExt;

    public class ChoiceCN376 : BaseChoiceCN88
    {
        public const string OptionHtmlFormat = "<div class='bettype-description'>{0}</div>";

        protected override void BuildBetChoice(ITicket ticket, ITicketHelper ticketHelper, List<ITicketData> ticketData)
        {
            base.BuildBetChoice(ticket, ticketHelper, ticketData);

            var betTeam = new StringBuilder();

            var options = PenaltyShootoutComboExtensions.GetRoundInfo(ticket, ticketHelper).OrderBy(i => i.Round);
            foreach (var option in options)
            {
                betTeam.AppendFormat(OptionHtmlFormat, option.Text);
            }

            Template.BetChoice.ChoiceName.Hide();
            Template.BetChoiceMoreInfo.Show();
            Template.BetChoiceMoreInfo.betChoiceMoreInfo = betTeam.ToString();
        }

        protected override void BuildBetChoiceRtf(RTFHelper rtfHelper)
        {
            Template.BetChoice.ChoiceName.choiceName = string.Empty;
            base.BuildBetChoiceRtf(rtfHelper);
            
            if (Template.BetChoiceMoreInfo != null && Template.BetChoiceMoreInfo.Visible)
            {
                var betchoices = Template.BetChoiceMoreInfo.ToString().SplitHTMLIntoRows();
                rtfHelper.RTFRenderer.AddText("\n");
                rtfHelper.RTFRenderer.AddText(string.Join("\n", betchoices));
            }
        }
    }
}
