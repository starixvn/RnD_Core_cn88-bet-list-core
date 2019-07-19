namespace CN88.BetList.Sportsbook.Tests.Builders.ChoiceBuilders
{
    using CN88.BetList.Core.Builders.ChoiceBuilders;
    using Fanex.BetList.Core.Entities;
    using NSubstitute;
    using NUnit.Framework;

    public class ChoiceCN424Tests
    {
        [Test]
        public void ChoiceCN424_Always_InheritBaseChoiceCN88()
        {
            // Assert
            Assert.AreEqual("BaseChoiceCN88", typeof(ChoiceCN424).BaseType.Name);
        }

        [TestCase("s", "Shot")]
        [TestCase("h", "Header")]
        [TestCase("p", "Penalty")]
        [TestCase("fk", "Free Kick")]
        [TestCase("og", "Own Goal")]
        [TestCase("ng", "No Goal")]
        [TestCase("", "")]
        public void BuildChoiceName_Always_RenderCorrectText(string betTeam, string expectedText)
        {
            // Arrange
            var ticket = Substitute.For<ITicket>();
            ticket.BetTeam = betTeam;
            var ticketHelper = Substitute.For<ITicketHelper>();
            var choice = new ChoiceCN424();

            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.AreEqual(expectedText, choice.Template.BetChoice.ChoiceName.choiceName);
        }
    }
}
