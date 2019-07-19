namespace CN88.BetList.Sportsbook.Tests.Builders.ChoiceBuilders
{
    using CN88.BetList.Core.Builders.ChoiceBuilders;
    using Fanex.BetList.Core.Entities;
    using NSubstitute;
    using NUnit.Framework;

    public class ChoiceCN611Tests
    {
        [Test]
        public void ChoiceCN611_Always_InheritChoiceCN603()
        {
            // Assert
            Assert.AreEqual("ChoiceCN603", typeof(ChoiceCN611).BaseType.Name);
        }

        [TestCase("o", "Odd")]
        [TestCase("O", "Odd")]
        [TestCase("e", "Even")]
        [TestCase("E", "Even")]
        [TestCase("", "Even")]
        public void BuildChoiceName_Always_RenderCorrectText(string betTeam, string expectedText)
        {
            // Arrange
            var ticket = Substitute.For<ITicket>();
            ticket.BetTeam = betTeam;
            var ticketHelper = Substitute.For<ITicketHelper>();
            var choice = new ChoiceCN611();

            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.AreEqual(expectedText, choice.Template.BetChoice.ChoiceName.choiceName);
        }
    }
}
