namespace CN88.BetList.Core.Tests.Helpers
{
    using CN88.BetList.Core.Helpers;
    using Fanex.BetList.Core.Entities;
    using NSubstitute;
    using NUnit.Framework;

    public class CN88TicketHelperTests
    {
        private ITicket ticket;
        private ITicketHelper ticketHelper;

        [SetUp]
        public void Setup()
        {
            ticket = Substitute.For<ITicket>();
            ticketHelper = Substitute.For<ITicketHelper>();
            ticketHelper.GetTeamNameById((object)1).Returns("Home Name");
            ticketHelper.GetTeamNameById((object)2).Returns("Away Name");
        }

        [TestCase("1", "")]
        [TestCase("2", "")]
        [TestCase("x", "Draw")]
        [TestCase("X", "Draw")]
        [TestCase("", "")]
        [TestCase(null, "")]
        public void Get1x2ChoiceValue_Always_ReturnCorrectValue(string betTeam, string expectedValue)
        {
            // Arrange
            ticket.BetTeam = betTeam;

            // Act
            var actualValue = CN88TicketHelper.Get1x2ChoiceValue(ticket, ticketHelper);

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestCase(0, "0")]
        [TestCase(0.25, "0 / 0.5")]
        [TestCase(0.5, "0.5")]
        [TestCase(0.75, "0.5 / 1")]
        [TestCase(1, "1")]
        [TestCase(1.25, "1 / 1.5")]
        [TestCase(1.5, "1.5")]
        [TestCase(1.75, "1.5 / 2")]
        public void GetHandicap_Always_ReturnCorrectValue(decimal hdp, string expectedValue)
        {
            // Act
            var actualValue = CN88TicketHelper.GetHandicap(hdp);

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }
    }
}
