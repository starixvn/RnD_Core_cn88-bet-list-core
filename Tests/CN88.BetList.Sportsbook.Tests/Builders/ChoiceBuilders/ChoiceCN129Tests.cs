namespace CN88.BetList.Sportsbook.Tests.Builders.ChoiceBuilders
{
    using CN88.BetList.Core.Builders.ChoiceBuilders;
    using Fanex.BetList.Core.Entities;
    using NSubstitute;
    using NUnit.Framework;

    public class ChoiceCN129Tests
    {
        private ChoiceCN129 choice;
        private ITicket ticket;
        private ITicketHelper ticketHelper;

        [SetUp]
        public void Setup()
        {
            ticket = Substitute.For<ITicket>();
            ticketHelper = Substitute.For<ITicketHelper>();
            choice = new ChoiceCN129();
        }

        [Test]
        public void ChoiceCN129_Always_InheritChoiceCN3()
        {
            // Assert
            Assert.AreEqual("BaseChoiceCN88", typeof(ChoiceCN129).BaseType.Name);
        }

        [TestCase(null, "")]
        [TestCase("0", "No Goals")]
        [TestCase("1", "1 Goal")]
        [TestCase("2", "2 Goals")]
        [TestCase("3", "3 Goals")]
        [TestCase("4", "4 Goals")]
        [TestCase("4&over", "4+")]
        [TestCase("5", "5 Goals")]
        [TestCase("5&over", "5+")]
        [TestCase("6", "6 Goals")]
        [TestCase("7&over", "7+")]
        [TestCase("", "")]
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
