namespace CN88.BetList.Core.Builders.BetInfoBuilders
{
    using System;
    using CN88.BetList.Core.AppResources;
    using CN88.BetList.Core.Constants;
    using CN88.BetList.Core.Templates;
    using Fanex.BetList.Core.Constants;
    using Fanex.BetList.Core.Entities;
    using Fanex.BetList.Core.Utils;
    using NPOI.SS.UserModel;

    public class BaseBetInfoCN88 : IBetInfoCN88
    {
        public BaseBetInfoCN88()
        {
            Template = new BetInfoCN88_Template();
        }

        public BetInfoCN88_Template Template { get; }

        #region HTML RENDER

        public BetInfoCN88_Template Render(
            ITicket ticket,
            ITicketHelper ticketHelper,
            Func<object, string> getOddsTypeName)
        {
            BuildBetInfo(ticket, ticketHelper, getOddsTypeName);

            return Template;
        }

        public virtual string RenderBetTypeName(ITicket ticket, ITicketHelper ticketHelper)
        {
            var liveText = ticket.IsLive ? $"({CN88Resources.InPlay}) " : string.Empty;
            return $"{liveText}{GetBetTypeName(ticket, ticketHelper)}";
        }

        protected virtual void BuildBetInfo(ITicket ticket, ITicketHelper ticketHelper, Func<object, string> getOddsTypeName)
        {
            BuildOddsAndBetId(ticket, ticketHelper, getOddsTypeName);
            BuildSportType(ticket, ticketHelper);
            BuildBetTypeName(ticket, ticketHelper);
        }

        protected virtual void BuildOddsAndBetId(ITicket ticket, ITicketHelper ticketHelper, Func<object, string> getOddsTypeName)
        {
            BuildOdds(ticket, ticketHelper, getOddsTypeName);
            BuildBetId(ticket, ticketHelper);
        }

        protected virtual void BuildOdds(ITicket ticket, ITicketHelper ticketHelper, Func<object, string> getOddsTypeName)
        {
            var oddsType = string.IsNullOrEmpty(ticket.OddsType) ? (object)0 : ticket.OddsType;
            var oddsTypeName = getOddsTypeName(ConvertByBetType.OddsType(ticket.BetTypeId, oddsType));

            Template.OddsTypeAndBetId.OddsType.oddsType = !string.IsNullOrWhiteSpace(oddsTypeName)
                ? $"{oddsTypeName} "
                : string.Empty;
        }

        protected virtual void BuildBetId(ITicket ticket, ITicketHelper ticketHelper)
            => Template.OddsTypeAndBetId.BetId.betId = ticket.TransId.ToString();

        protected virtual void BuildSportType(ITicket ticket, ITicketHelper ticketHelper)
            => Template.SportType.SportTypeName.sportTypeName = ticketHelper.GetSportNameById(ticket.SportTypeId);

        protected virtual void BuildBetTypeName(ITicket ticket, ITicketHelper ticketHelper)
        {
            Template.BetType.BetTypeName.betTypeName = RenderBetTypeName(ticket, ticketHelper);
        }

        protected virtual string GetBetTypeName(ITicket ticket, ITicketHelper ticketHelper)
        {
            var refNo = ticket.RefNo;

            if (IsCashOutBetTicket(ticket) && !IsOutRight(ticket.BetTypeId))
            {
                refNo = CommonValue.RefNoDefault;
            }

            return ticketHelper.GetBetTypeNameById(ticket.BetTypeId, refNo);
        }

        #endregion HTML RENDER

        #region EXCEL RENDER

        public IRichTextString RenderRTF(
            ITicket ticket,
            ITicketHelper ticketHelper,
            Func<object, string> getOddsTypeName,
            RTFHelper rtfHelper)
        {
            Render(ticket, ticketHelper, getOddsTypeName);

            return BuildRTFBetInfo(rtfHelper);
        }

        protected virtual IRichTextString BuildRTFBetInfo(RTFHelper rtfHelper)
        {
            BuildRTFOddsAndBetId(rtfHelper);
            BuildRTFSportType(rtfHelper);
            BuildRTFBetType(rtfHelper);

            var betInfo = rtfHelper.RTFRenderer.Render();
            rtfHelper.RTFRenderer.Clear();

            return betInfo;
        }

        protected virtual void BuildRTFOddsAndBetId(RTFHelper rtfHelper)
        {
            BuildRTFOdds(rtfHelper);
            BuildRTFBetId(rtfHelper);
            rtfHelper.RTFRenderer.AddText(ExcelCharacters.BreakingLine);
        }

        protected virtual void BuildRTFOdds(RTFHelper rtfHelper)
        {
            var oddsTypeName = Template.OddsTypeAndBetId.OddsType.oddsType;
            rtfHelper.RTFRenderer.AddText(oddsTypeName);
        }

        protected virtual void BuildRTFBetId(RTFHelper rtfHelper)
        {
            var betId = Template.OddsTypeAndBetId.BetId.betId;
            rtfHelper.RTFRenderer.AddText(betId);
        }

        protected virtual void BuildRTFSportType(RTFHelper rtfHelper)
        {
            var sportName = Template.SportType.SportTypeName.sportTypeName;

            if (!string.IsNullOrWhiteSpace(sportName))
            {
                rtfHelper.RTFRenderer.AddText(sportName);
                rtfHelper.RTFRenderer.AddText(ExcelCharacters.BreakingLine);
            }
        }

        protected virtual void BuildRTFBetType(RTFHelper rtfHelper)
        {
            var betTypeName = RemoveSpecialWords(Template.BetType.BetTypeName.betTypeName);
            rtfHelper.RTFRenderer.AddText(betTypeName);
        }

        private static bool IsCashOutBetTicket(ITicket ticket) => ticket.BetdaqId == 1 && !IsBetTrade(ticket.BetTypeId);

        private static bool IsOutRight(int betTypeId) => betTypeId == BetTypeIdConstant.Outright;

        private static bool IsBetTrade(int betTypeId) => betTypeId == BetTypeIdConstant.BetTrade_Sold || betTypeId == BetTypeIdConstant.BetTrade_Bought;

        protected static string RemoveSpecialWords(string htmlText) => htmlText.Replace("&nbsp;", " ");

        #endregion EXCEL RENDER
    }
}
