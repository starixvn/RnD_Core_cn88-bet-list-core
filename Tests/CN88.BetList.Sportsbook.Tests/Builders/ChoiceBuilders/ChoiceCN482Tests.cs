namespace CN88.BetList.Sportsbook.Tests.Builders.ChoiceBuilders
{
    using System.Collections.Generic;
    using CN88.BetList.Core.Builders.ChoiceBuilders;
    using Fanex.BetList.Core.Entities;
    using NSubstitute;
    using NUnit.Framework;

    public class ChoiceCN482Tests
    {
        private ChoiceCN482 _choice;
        private ITicket _ticket;
        private ITicketHelper _ticketHelper;
        private List<ITicketData> _ticketData;

        [SetUp]
        public void Setup()
        {
            _choice = new ChoiceCN482();
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
        [TestCase("a")]
        [TestCase("H")]
        public void BuildBetTeam_TicketBetTeamIsAnyOtherValue_DisplayedBetOptionIsUnder(string betTeam)
        {
            // Arrange.
            _ticket.BetTeam = betTeam;

            // Act.
            var template = _choice.Render(_ticket, _ticketHelper, null);

            // Assert.
            Assert.AreEqual("Under 1", template.BetChoice.ChoiceName.choiceName);
        }
    }
}
