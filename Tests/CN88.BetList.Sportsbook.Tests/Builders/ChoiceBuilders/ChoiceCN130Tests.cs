namespace CN88.BetList.Sportsbook.Tests.Builders.ChoiceBuilders
{
    using CN88.BetList.Core.Builders.ChoiceBuilders;
    using Fanex.BetList.Core.Entities;
    using NSubstitute;
    using NUnit.Framework;

    public class ChoiceCN130Tests
    {
        private ChoiceCN130 choice;
        private ITicket ticket;
        private ITicketHelper ticketHelper;

        [SetUp]
        public void Setup()
        {
            ticket = Substitute.For<ITicket>();
            ticketHelper = Substitute.For<ITicketHelper>();
            choice = new ChoiceCN130();
        }

        [Test]
        public void ChoiceCN130_Always_InheritChoiceCN3()
        {
            // Assert
            Assert.AreEqual("BaseChoiceCN88", typeof(ChoiceCN130).BaseType.Name);
        }

        [TestCase("", "")]
        [TestCase("0", "No Goals")]
        [TestCase("1", "1 Goal")]
        [TestCase("2", "2 Goals")]
        [TestCase("3", "3 Goals")]
        [TestCase("4", "4 Goals")]
        [TestCase("5", "5 Goals")]
        [TestCase("6", "6 Goals")]
        [TestCase("7&over", "7+")]
        [TestCase("4&over", "4+")]
        [TestCase("5&over", "5+")]
        [TestCase("8", "")]
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
