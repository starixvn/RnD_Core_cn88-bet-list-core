namespace CN88.BetList.Sportsbook.Tests.Builders.ChoiceBuilders
{
    using CN88.BetList.Core.Builders.ChoiceBuilders;
    using Fanex.BetList.Core.Entities;
    using NSubstitute;
    using NUnit.Framework;

    public class ChoiceCN18Tests
    {
        private ChoiceCN18 choice;
        private ITicket ticket;
        private ITicketHelper ticketHelper;

        [SetUp]
        public void Setup()
        {
            ticket = Substitute.For<ITicket>();
            ticketHelper = Substitute.For<ITicketHelper>();
            choice = new ChoiceCN18();
        }

        [Test]
        public void ChoiceCN18_Always_InheritChoiceCN3()
        {
            // Assert
            Assert.AreEqual("ChoiceCN3", typeof(ChoiceCN18).BaseType.Name);
        }

        [TestCase("o", "Over")]
        [TestCase("O", "Over")]
        [TestCase("u", "Under")]
        [TestCase("U", "Under")]
        [TestCase("", "Under")]
        [TestCase("a", "Under")]
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
