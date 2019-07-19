namespace CN88.BetList.Sportsbook.Tests.Builders.ChoiceBuilders
{
    using System.Collections.Generic;
    using CN88.BetList.Core.Builders.ChoiceBuilders;
    using Fanex.BetList.Core.Entities;
    using NSubstitute;
    using NUnit.Framework;

    public class ChoiceCN479Tests
    {
        private ChoiceCN479 _choice;
        private ITicket _ticket;
        private ITicketHelper _ticketHelper;
        private List<ITicketData> _ticketData;

        [SetUp]
        public void Setup()
        {
            _choice = new ChoiceCN479();
            _ticket = Substitute.For<ITicket>();
            _ticket.Handicap1.Returns(1);

            _ticketHelper = Substitute.For<ITicketHelper>();
            _ticketData = Substitute.For<List<ITicketData>>();
        }

        [TestCase("y")]
        [TestCase("Y")]
        public void BuildBetTeam_TicketBetTeamIsY_DisplayedBetOptionIsCornerBefore(string betTeam)
        {
            // Arrange.
            _ticket.BetTeam = betTeam;

            // Act.
            var template = _choice.Render(_ticket, _ticketHelper, null);

            // Assert.
            Assert.AreEqual("Corner Before 1:00", template.BetChoice.ChoiceName.choiceName);
        }

        [TestCase("n")]
        [TestCase("N")]
        [TestCase("a")]
        [TestCase("H")]
        public void BuildBetTeam_TicketBetTeamIsAnyOtherValue_DisplayedBetOptionIsNoCornerBefore(string betTeam)
        {
            // Arrange.
            _ticket.BetTeam = betTeam;

            // Act.
            var template = _choice.Render(_ticket, _ticketHelper, null);

            // Assert.
            Assert.AreEqual("No Corner Before 1:00", template.BetChoice.ChoiceName.choiceName);
        }

    }
}
