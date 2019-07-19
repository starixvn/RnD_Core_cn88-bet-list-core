namespace CN88.BetList.Sportsbook.Tests.Builders.ChoiceBuilders
{
    using CN88.BetList.Core.Builders.ChoiceBuilders;
    using Fanex.BetList.Core.Entities;
    using NSubstitute;
    using NUnit.Framework;

    public class ChoiceCN136Tests
    {
        private ChoiceCN136 choice;
        private ITicket ticket;
        private ITicketHelper ticketHelper;

        [SetUp]
        public void Setup()
        {
            ticket = Substitute.For<ITicket>();
            ticketHelper = Substitute.For<ITicketHelper>();
            choice = new ChoiceCN136();
        }

        [Test]
        public void ChoiceCN136_Always_InheritChoiceCN3()
        {
            // Assert
            Assert.AreEqual("BaseChoiceCN88", typeof(ChoiceCN136).BaseType.Name);
        }

        [TestCase("", "Even")]
        [TestCase("o", "Odd")]
        [TestCase("O", "Odd")]
        [TestCase("e", "Even")]
        [TestCase("E", "Even")]
        [TestCase("a", "Even")]
        [TestCase("A", "Even")]
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
