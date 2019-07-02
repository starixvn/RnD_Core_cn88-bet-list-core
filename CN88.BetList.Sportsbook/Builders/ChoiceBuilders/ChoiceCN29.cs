namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using CN88.BetList.Core.AppResources;
    using Fanex.BetList.Core.App_GlobalResources;
    using Fanex.BetList.Core.Entities;
    using NPOI.SS.UserModel;

    public class ChoiceCN29 : BaseChoiceCN88
    {
        protected override void BuildChoice(ITicket ticket, ITicketHelper ticketHelper, List<ITicketData> ticketData)
        {
            Template.League.Hide();
            Template.Match.Hide();
            Template.MatchByTeamId.Hide();
            Template.BetChoice.Hide();
            Template.BetChoiceMoreInfo.Hide();
            Template.KickOffTime.Hide();

            Template.MixParlay.mixparlayFunction = BuildSubBetsJsFunction(ticket, ticketHelper);
            Template.MixParlay.mixParlayTitle = CoreBetList.lblMixParlay;

            BuildOfferNamesBlock(ticket, ticketHelper);
            BuildDetailLink(ticket, ticketHelper);
        }

        private static string BuildSubBetsJsFunction(ITicket ticket, ITicketHelper ticketHelper)
            => string.IsNullOrWhiteSpace(ticketHelper.ClientSystemParlaySubbetsDetailFunction)
                    ? CreateSubBetsJsFunction(ticket, ticketHelper)
                    : ticketHelper.ClientSystemParlaySubbetsDetailFunction;

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

        protected virtual void BuildOfferNamesBlock(ITicket ticket, ITicketHelper ticketHelper)
        {
            var offerNames = ticketHelper.GetCombinationMPOfferNameList(
                    ticket.BetTeam, ticket.BetCheck, ticket.Handicap1, ticket.Handicap2);
            var offerNamesBlock = string.Empty;

            if (offerNames != null)
            {
                offerNamesBlock = string.Join(
                    string.Empty,
                    offerNames.Select(name => $"<div>{name}</div>"));
            }

            var offerNamesId = $"{ticket.TransId}-{ticketHelper.Index}";
            Template.MixParlay.OfferNames.offerNamesId = offerNamesId;
            Template.MixParlay.OfferNames.offerNames = offerNamesBlock;
            Template.MixParlay.SubTickets.subTicketsId = offerNamesId;

        }

        protected virtual void BuildDetailLink(ITicket ticket, ITicketHelper ticketHelper)
        {
            var isShowDetailLink = ShowDetailLink(ticket, ticketHelper);

            Template.MoreInfo.Visible = isShowDetailLink;

            if (!isShowDetailLink)
            {
                return;
            }

            var custId = GetCustId(ticket);
            Template.MoreInfo.moreInfoFunction =
                    string.IsNullOrWhiteSpace(ticketHelper.ClientDetailSystemParlayFunction)
                            ? $"showCombMPDetail('{ticket.RefNo}', " +
                                $"'{ticket.WinlostDate.ToString(CultureInfo.InvariantCulture)}', " +
                                $"{ticket.TransId}, " +
                                $"'{ticket.BetId}', " +
                                $"{custId}, " +
                                $"'{ticket.BetTeam}', this)"
                            : ticketHelper.ClientDetailSystemParlayFunction;

            Template.MoreInfo.moreInfoTitle = CN88Resources.details;
            Template.MoreInfo.detailText = CN88Resources.details;
        }

        private static bool ShowDetailLink(ITicket ticket, ITicketHelper ticketHelper)
            => ticketHelper.ShowSystemParlayDetail && IsAcceptedTicket(ticket);

        private static bool IsAcceptedTicket(ITicket ticket)
        {
            var status = ticket.Status.ToLowerInvariant();

            return status == BetStatus.Running
                || status == BetStatus.Won
                || status == BetStatus.Lose
                || status == BetStatus.Draw;
        }

        private static string GetCustId(ITicket ticket)
            => ticket.CustId.ToString(CultureInfo.InvariantCulture);

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
    }
}
