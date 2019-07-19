namespace CN88.BetList.Sportsbook.Tests.Builders.ChoiceBuilders
{
    using CN88.BetList.Core.Builders.ChoiceBuilders;
    using Fanex.BetList.Core.Entities;
    using NSubstitute;
    using NUnit.Framework;

    public class ChoiceCN450Tests
    {
        [Test]
        public void ChoiceCN450_Always_InheritChoiceCN3()
        {
            // Assert
            Assert.AreEqual("ChoiceCN3", typeof(ChoiceCN450).BaseType.Name);
        }

        [TestCase(null, "")]
        [TestCase("ou", "Odd & Under")]
        [TestCase("eo", "Even & Over")]
        [TestCase("ax", "ax")]
        public void BuildChoiceName_Always_RenderCorrectText(string betTeam, string expectedText)
        {
            // Arrange
            var ticket = Substitute.For<ITicket>();
            ticket.BetTeam = betTeam;
            var ticketHelper = Substitute.For<ITicketHelper>();
            var choice = new ChoiceCN450();

            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.AreEqual(expectedText, choice.Template.BetChoice.ChoiceName.choiceName);
        }
    }
}
