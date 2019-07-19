namespace CN88.BetList.Sportsbook.Tests.Builders.ChoiceBuilders
{
    using System.Collections.Generic;
    using CN88.BetList.Core.Builders.ChoiceBuilders;
    using Fanex.BetList.Core.Entities;
    using NSubstitute;
    using NUnit.Framework;

    public class ChoiceCN475Tests
    {
        private ChoiceCN475 _choice;
        private ITicket _ticket;
        private ITicketHelper _ticketHelper;
        private List<ITicketData> _ticketData;

        [SetUp]
        public void Setup()
        {
            _choice = new ChoiceCN475();
            _ticket = Substitute.For<ITicket>();
            _ticket.Handicap1.Returns(1);

            _ticketHelper = Substitute.For<ITicketHelper>();
            _ticketData = Substitute.For<List<ITicketData>>();
        }

        [TestCase("o")]
        [TestCase("O")]
        public void BuildBetTeam_TicketBetTeamIsO_DisplayedBetOptionIsOver(string betTeam)
        {
            // Arrange.
            _ticket.BetTeam = betTeam;

            // Act.
            var template = _choice.Render(_ticket, _ticketHelper, null);

            // Assert.
            Assert.AreEqual("Over 1", template.BetChoice.ChoiceName.choiceName);
        }

        [TestCase("u")]
        [TestCase("U")]
        public void BuildBetTeam_TicketBetTeamIsU_DisplayedBetOptionIsUnder(string betTeam)
        {
            // Arrange.
            _ticket.BetTeam = betTeam;

            // Act.
            var template = _choice.Render(_ticket, _ticketHelper, null);

            // Assert.
            Assert.AreEqual("Under 1", template.BetChoice.ChoiceName.choiceName);
        }

        [TestCase("e")]
        [TestCase("E")]
        public void BuildBetTeam_TicketBetTeamIsE_DisplayedBetOptionIsExact(string betTeam)
        {
            // Arrange.
            _ticket.BetTeam = betTeam;
            _ticket.Handicap1 = 1;

            // Act.
            var template = _choice.Render(_ticket, _ticketHelper, null);

            // Assert.
            Assert.AreEqual("Exact 1", template.BetChoice.ChoiceName.choiceName);
        }

        [TestCase("a")]
        [TestCase("H")]
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
