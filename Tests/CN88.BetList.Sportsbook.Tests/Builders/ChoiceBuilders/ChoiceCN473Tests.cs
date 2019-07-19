namespace CN88.BetList.Sportsbook.Tests.Builders.ChoiceBuilders
{
    using System.Collections.Generic;
    using CN88.BetList.Core.Builders.ChoiceBuilders;
    using Fanex.BetList.Core.Entities;
    using NSubstitute;
    using NUnit.Framework;

    public class ChoiceCN473Tests
    {
        private ChoiceCN473 _choice;
        private ITicket _ticket;
        private ITicketHelper _ticketHelper;
        private List<ITicketData> _ticketData;

        [SetUp]
        public void Setup()
        {
            _choice = new ChoiceCN473();
            _ticket = Substitute.For<ITicket>();
            _ticketHelper = Substitute.For<ITicketHelper>();
            _ticketData = Substitute.For<List<ITicketData>>();
        }

        [Test]
        public void BuildBetTeam_Always_DisplayedBetOptionIsTicketBetTeam()
        {
            // Arrange.
            const string betTeam = "0-5";

            _ticket.BetTeam = betTeam;

            // Act.
            var template = _choice.Render(_ticket, _ticketHelper, null);

            // Assert.
            Assert.AreEqual(betTeam, template.BetChoice.ChoiceName.choiceName);
        }
    }
}
