namespace CN88.BetList.Core.Builders
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using CN88.BetList.Core.Builders.ChoiceBuilders;
    using CN88.BetList.Core.Templates;
    using Fanex.BetList.Core.Entities;

    public class BetListCN88HtmlBuilder : BetListCN88BaseBuilder, IBetListCN88HtmlBuilder
    {
        private readonly StringBuilder content;

        public BetListCN88HtmlBuilder()
        {
            content = new StringBuilder();
        }

        public string GetBetList()
         => content.ToString();

        public IBetListCN88HtmlBuilder Append(string content)
        {
            this.content.Append(content);

            return this;
        }

        #region CHOICE

        public IBetListCN88HtmlBuilder AddChoice(ITicket ticket, ITicketHelper ticketHelper, List<ITicketData> ticketData, string openTag, string closeTag, bool isShowScoreMap)
        {
            string choice = BuildChoice(ticket, ticketHelper, ticketData);

            content.Append(string.Join(null, new[] { openTag, choice, closeTag }));

            return this;
        }

        public string BuildChoice(ITicket ticket, ITicketHelper ticketHelper, List<ITicketData> ticketData)
        {
            IChoiceCN88 choiceBuilder = CreateChoiceBuilder(ticket.BetTypeId);
            ChoiceCN88_Template choice = choiceBuilder.Render(ticket, ticketHelper, ticketData);

            if (!ticketHelper.ShowLeague)
            {
                choice.League = null;
            }

            return choice;
        }

        public ChoiceCN88_Template BuildChoiceBlock(ITicket ticket, ITicketHelper ticketHelper, List<ITicketData> ticketData)
        {
            IChoiceCN88 choiceBuilder = CreateChoiceBuilder(ticket.BetTypeId);
            ChoiceCN88_Template choice = choiceBuilder.Render(ticket, ticketHelper, ticketData);

            return choice;
        }

        #endregion CHOICE

        #region BETINFO

        public IBetListCN88HtmlBuilder AddBetInfo(
            ITicket ticket,
            ITicketHelper ticketHelper,
            Func<object, string> getOddsTypeName,
            string openTag,
            string closeTag)
        {
            var betInfo = BuildBetInfo(ticket, ticketHelper, getOddsTypeName);
            content.Append(string.Join(null, new[] { openTag, betInfo, closeTag }));

            return this;
        }

        public string BuildBetInfo(ITicket ticket, ITicketHelper ticketHelper, Func<object, string> getOddsTypeName)
            => BuildBetInfoBlock(ticket, ticketHelper, getOddsTypeName);

        public BetInfoCN88_Template BuildBetInfoBlock(ITicket ticket, ITicketHelper ticketHelper, Func<object, string> getOddsTypeName)
        {
            var betInfoBuilder = CreateBetInfoBuilder(ticket.BetTypeId);
            var betInfo = betInfoBuilder.Render(ticket, ticketHelper, getOddsTypeName);

            return betInfo;
        }

        #endregion BETINFO
    }
}
