namespace CN88.BetList.Sportsbook.Tests.Builders.ChoiceBuilders
{
    using CN88.BetList.Core.Builders.ChoiceBuilders;
    using Fanex.BetList.Core.Entities;
    using NSubstitute;
    using NUnit.Framework;

    public class ChoiceCN496Tests
    {
        private ChoiceCN496 _choice;
        private ITicket _ticket;
        private ITicketHelper _ticketHelper;

        [SetUp]
        public void Setup()
        {
            _choice = new ChoiceCN496();
            _ticket = Substitute.For<ITicket>();
            _ticketHelper = Substitute.For<ITicketHelper>();
        }

        [TestCase("1h", "First Half")]
        [TestCase("2h", "Second Half")]
        [TestCase("tie", "Tie")]
        [TestCase("3h", "")]
        public void BuildBetTeam_Always_DisplayCorrectBetOption(string betTeam, string expectedBetOption)
        {
            // Arrange.
            _ticket.BetTeam = betTeam;

            // Act.
            var template = _choice.Render(_ticket, _ticketHelper, null);

            // Assert.
            Assert.AreEqual(expectedBetOption, template.BetChoice.ChoiceName.choiceName);
        }
    }
}
