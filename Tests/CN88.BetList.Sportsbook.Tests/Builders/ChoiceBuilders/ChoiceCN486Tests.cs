namespace CN88.BetList.Sportsbook.Tests.Builders.ChoiceBuilders
{
    using System.Collections.Generic;
    using CN88.BetList.Core.Builders.ChoiceBuilders;
    using Fanex.BetList.Core.Entities;
    using NSubstitute;
    using NUnit.Framework;

    public class ChoiceCN486Tests
    {
        private ChoiceCN486 _choice;
        private ITicket _ticket;
        private ITicketHelper _ticketHelper;
        private List<ITicketData> _ticketData;
        private const string HomeTeamName = "Home team";
        private const string AwayTeamName = "Away team";

        [SetUp]
        public void Setup()
        {
            _choice = new ChoiceCN486();
            _ticket = Substitute.For<ITicket>();
            _ticket.Handicap1.Returns(1);
            const int homeTeamId = 1;
            const int awayTeamId = 2;
            _ticket.HomeId = homeTeamId;
            _ticket.AwayId = awayTeamId;

            _ticketHelper = Substitute.For<ITicketHelper>();
            _ticketHelper.GetTeamNameById(_ticket.HomeId).Returns(HomeTeamName);
            _ticketHelper.GetTeamNameById(_ticket.AwayId).Returns(AwayTeamName);
            _ticketData = Substitute.For<List<ITicketData>>();
        }

        [TestCase("h")]
        [TestCase("H")]
        public void BuildBetTeam_TicketBetTeamIsH_ShowHomeTeamNameAsBetOption(string betTeam)
        {
            // Arrange.
            _ticket.BetTeam = betTeam;

            // Act.
            var template = _choice.Render(_ticket, _ticketHelper, null);

            // Assert.
            Assert.AreEqual("Home team 1", template.BetChoice.ChoiceName.choiceName);
        }

        [TestCase("a")]
        [TestCase("A")]
        public void BuildBetTeam_TicketBetTeamIsA_ShowAwayTeamNameAsBetOption(string betTeam)
        {
            // Arrange.
            _ticket.BetTeam = betTeam;

            // Act.
            var template = _choice.Render(_ticket, _ticketHelper, null);

            // Assert.
            Assert.AreEqual("Away team 1", template.BetChoice.ChoiceName.choiceName);
        }

        [TestCase("n")]
        [TestCase("N")]
        public void BuildBetTeam_TicketBetTeamIsN_ShowNeitherAsBetOption(string betTeam)
        {
            // Arrange.
            _ticket.BetTeam = betTeam;

            // Act.
            var template = _choice.Render(_ticket, _ticketHelper, null);

            // Assert.
            Assert.AreEqual("Neither 1", template.BetChoice.ChoiceName.choiceName);
        }

        [TestCase("o")]
        [TestCase("U")]
        public void BuildBetTeam_TicketBetTeamIsNotOneOfExpectedValue_DisplayedBetOptionIsEmpty(string betTeam)
        {
            // Arrange.
            _ticket.BetTeam = betTeam;

            // Act.
            var template = _choice.Render(_ticket, _ticketHelper, null);

            // Assert.
            Assert.AreEqual(" 1", template.BetChoice.ChoiceName.choiceName);
        }
    }
}
