namespace CN88.BetList.Sportsbook.Tests.Builders.ChoiceBuilders
{
    using CN88.BetList.Core.Builders.ChoiceBuilders;
    using Fanex.BetList.Core.Entities;
    using NSubstitute;
    using NUnit.Framework;

    public class ChoiceCN16Tests
    {
        private ChoiceCN16 choice;
        private ITicket ticket;
        private ITicketHelper ticketHelper;

        [SetUp]
        public void Setup()
        {
            ticket = Substitute.For<ITicket>();
            ticketHelper = Substitute.For<ITicketHelper>();
            choice = new ChoiceCN16();
        }

        [Test]
        public void ChoiceCN16_Always_InheritBaseChoiceCN88()
        {
            // Assert
            Assert.AreEqual("BaseChoiceCN88", typeof(ChoiceCN16).BaseType.Name);
        }

        [TestCase("0:0", "DD")]
        [TestCase("0:1", "DH")]
        [TestCase("0:2", "DA")]
        [TestCase("1:0", "HD")]
        [TestCase("1:1", "HH")]
        [TestCase("1:2", "HA")]
        [TestCase("2:0", "AD")]
        [TestCase("2:1", "AH")]
        [TestCase("2:2", "AA")]
        [TestCase("1:3", "")]
        [TestCase(null, "")]
        [TestCase("", "")]
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
