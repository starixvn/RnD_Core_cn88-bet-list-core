namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using Fanex.BetList.Core.App_GlobalResources;
    using Fanex.BetList.Core.Entities;
    using Fanex.BetList.Core.Utils;
    using NPOI.SS.UserModel;

    public class ChoiceCN2799 : BaseVirtualSportsChoiceCN88
    {
        protected override void BuildBetChoice(ITicket ticket, ITicketHelper ticketHelper, List<ITicketData> ticketData)
        {
            Template.League.Hide();
            Template.Match.Hide();
            Template.MatchByTeamId.Hide();
            Template.BetChoice.Hide();
            Template.BetChoiceMoreInfo.Hide();
            Template.MixParlay.Show();

            Template.MixParlay.mixparlayFunction = BuildMixParlaySubBetsFuncName(ticket, ticketHelper);
            Template.MixParlay.mixParlayTitle = CoreBetList.lblMixParlay;

            BuildOfferNamesBlock(ticket, ticketHelper);

            Template.MoreInfo.Visible = false;
            Template.KickOffTime.Hide();
        }

        protected override void BuildOdds(ITicket ticket, List<ITicketData> ticketData)
        {
            Template.BetChoice.Odds.odds = ShowOdds(ticket) ? FormatOdds(ticket.MasterOdds) : "-";
        }

        protected override IRichTextString BuildRTFChoice(ITicket ticket, RTFHelper rtfHelper, ITicketHelper ticketHelper, List<ITicketData> ticketData)
        {
            BuildChoice(ticket, ticketHelper, ticketData);

            rtfHelper.RTFRenderer.AddText(
                Template.MixParlay.OfferNames.offerNames
                    .Replace("<div>", string.Empty)
                    .Replace("</div>", "\n")
                    .TrimEnd('\n'));

            var choiceRtf = rtfHelper.RTFRenderer.Render();
            rtfHelper.RTFRenderer.Clear();

            return choiceRtf;
        }

        protected virtual void BuildOfferNamesBlock(ITicket ticket, ITicketHelper ticketHelper)
        {
            var offerNames = ticketHelper.GetCombinationMPOfferNameList(ticket.BetTeam, ticket.BetCheck, ticket.Handicap1, ticket.Handicap2);
            var offerNamesBlock = offerNames == null ? string.Empty : string.Concat(offerNames.Select(name => $"<div>{name}</div>"));
            var offerNamesId = $"{ticket.TransId}-{ticketHelper.Index}";
            Template.MixParlay.OfferNames.offerNamesId = offerNamesId;
            Template.MixParlay.OfferNames.offerNames = offerNamesBlock;
            Template.MixParlay.SubTickets.subTicketsId = offerNamesId;
        }

        private static string BuildMixParlaySubBetsFuncName(ITicket ticket, ITicketHelper ticketHelper)
        {
            return string.IsNullOrWhiteSpace(ticketHelper.ClientSystemParlaySubbetsDetailFunction)
                ? CreateSubBetsJsFunction(ticket, ticketHelper)
                 : ticketHelper.ClientSystemParlaySubbetsDetailFunction;
        }

        private static string CreateSubBetsJsFunction(ITicket ticket, ITicketHelper ticketHelper)
            => "showParlaySubBetsCN88(" +
                     $"{ticket.TransId}, " +
                     $"{ticketHelper.Index}, " +
                     $"'{ticket.RefNo}', " +
                     $"{ticket.Handicap1}, " +
                     $"{ticket.Handicap2}, " +
                     $"'{ticket.BetCheck}', " +
                     $"'{ticket.BetTeam}', " +
                     $"{GetCustId(ticket)}, this)";

        private static string GetCustId(ITicket ticket)
            => ticket.CustId.ToString(CultureInfo.InvariantCulture);

        private static bool ShowOdds(ITicket ticket)
        {
            string statusId = ticket.StatusId != null ? ticket.StatusId.ToString() : string.Empty;
            string status = ticket.Status ?? string.Empty;

            status = status.Trim().ToLowerInvariant();

            bool isWin = statusId == BetStatusId.Won || status == BetStatus.Won;

            return isWin && ticket.MasterOdds != 0;
        }

        private static string FormatOdds(decimal odds)
            => odds < 0
                ? string.Format(ConvertByBetType.Minus, string.Format(Formatter.DECIMALFORMAT40, odds))
                : string.Format(Formatter.DECIMALFORMAT40, odds);
    }
}
