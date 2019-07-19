namespace CN88.BetList.Sportsbook.Tests.Builders.ChoiceBuilders
{
    using CN88.BetList.Core.Builders.ChoiceBuilders;
    using Fanex.BetList.Core.Entities;
    using NSubstitute;
    using NUnit.Framework;

    public class ChoiceCN24Tests
    {
        private ChoiceCN24 choice;
        private ITicket ticket;
        private ITicketHelper ticketHelper;

        [SetUp]
        public void Setup()
        {
            ticket = Substitute.For<ITicket>();
            ticketHelper = Substitute.For<ITicketHelper>();
            choice = new ChoiceCN24();
        }

        [Test]
        public void ChoiceCN24_Always_InheritBaseChoiceCN88()
        {
            // Assert
            Assert.AreEqual("BaseChoiceCN88", typeof(ChoiceCN24).BaseType.Name);
        }

        [TestCase(null, "")]
        [TestCase("", "")]
        [TestCase("a", "")]
        [TestCase("aaa", "")]
        [TestCase("1x", "Home or Draw")]
        [TestCase("2x", "Away or Draw")]
        [TestCase("3x", "Away or Draw")]
        [TestCase("1a", "Home or Away")]
        [TestCase("2a", "Away or Away")]
        [TestCase("3a", "Away or Away")]
        [TestCase("1h", "Home or Away")]
        [TestCase("2h", "Away or Away")]
        [TestCase("3h", "Away or Away")]
        [TestCase("1X", "Home or Draw")]
        [TestCase("2X", "Away or Draw")]
        [TestCase("3X", "Away or Draw")]
        [TestCase("1A", "Home or Away")]
        [TestCase("2A", "Away or Away")]
        [TestCase("3A", "Away or Away")]
        [TestCase("1H", "Home or Away")]
        [TestCase("2H", "Away or Away")]
        [TestCase("3H", "Away or Away")]
        public void BuildBetChoice_Always_RenderCorrectText(string betTeam, string expectedText)
        {
            // Arrange
            ticket.BetTeam = betTeam;

            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.AreEqual(expectedText, choice.Template.BetChoice.ChoiceName.choiceName);
        }
    }
}
