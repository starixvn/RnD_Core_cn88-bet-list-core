namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using System.Collections.Generic;
    using Fanex.BetList.Core.Entities;
    using Fanex.BetList.Core.Utils;

    public delegate string MemberChoiceMappingHandler(ITicket ticket, ITicketHelper ticketHelper);

    public class ChoiceCN1501 : BaseChoiceCN88
    {
        private static Dictionary<string, MemberChoiceMappingHandler> memberChoiceMapper = new Dictionary<string, MemberChoiceMappingHandler>
        {
            ["33"] = (ticket, ticketHelper) => BuildIndexBigSmallBetTeam("35", ticket, ticketHelper),
            ["34"] = (ticket, ticketHelper) => BuildIndexBigSmallBetTeam("36", ticket, ticketHelper)
        };

        protected override void BuildLeague(ITicket ticket, ITicketHelper ticketHelper)
        {
            string gameTypeName = ticketHelper.GetBetTypeNameById(ticket.BetTypeId);
            var gameId = CN88KenoUtils.ParseTransDesc(ticket.TransDesc)["gameId"];

            Template.League.LeagueName.leagueName = $"{gameTypeName} [{gameId}]";
        }

        protected override void BuildMatch(ITicket ticket, ITicketHelper ticketHelper)
        {
            Template.MatchByTeamId.Hide();
            Template.Match.Hide();
        }

        protected override void BuildBetChoice(ITicket ticket, ITicketHelper ticketHelper, List<ITicketData> ticketData)
        {
            Template.BetChoiceMoreInfo.Hide();
            Template.BetChoice.ChoiceValue.Hide();

            string memberChoice;

            var choiceId = CN88KenoUtils.ParseTransDesc(ticket.TransDesc)["choiceId"];

            memberChoice = !string.IsNullOrEmpty(choiceId) && memberChoiceMapper.ContainsKey(choiceId)
                   ? memberChoiceMapper[choiceId](ticket, ticketHelper)
                   : ticketHelper.GetKenoBetChoiceName(choiceId, out string kenoBetTypeId);

            Template.BetChoice.ChoiceName.choiceName = memberChoice;
        }

        private static string BuildIndexBigSmallBetTeam(string mappedChoiceId, ITicket ticket, ITicketHelper ticketHelper)
        {
            string kenoBetTypeId;
            string memberChoicePattern = ticketHelper.GetKenoBetChoiceName(mappedChoiceId, out kenoBetTypeId);
            decimal bets = 0;
            int range = 0;

            if (!string.IsNullOrEmpty(ticket.BetCheck) && int.TryParse(ticket.BetCheck, out range) && range != 0)
            {
                bets = ticket.Stake / range;
            }

            return string.Format(memberChoicePattern, ConvertByBetType.Stake(bets), range);
        }
    }
}
