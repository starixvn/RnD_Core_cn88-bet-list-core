namespace CN88.BetList.Sportsbook.Tests.Builders.ChoiceBuilders
{
    using CN88.BetList.Core.Builders.ChoiceBuilders;
    using Fanex.BetList.Core.Entities;
    using NSubstitute;
    using NUnit.Framework;

    public class ChoiceCN469Tests
    {
        [Test]
        public void ChoiceCN469_Always_InheritChoiceCN601()
        {
            // Assert
            Assert.AreEqual("ChoiceCN468", typeof(ChoiceCN469).BaseType.Name);
        }

        [TestCase("o", "Equal/Over")]
        [TestCase("O", "Equal/Over")]
        [TestCase("u", "Equal/Under")]
        [TestCase("U", "Equal/Under")]
        [TestCase("", "Equal/Under")]
        public void BuildChoiceName_Always_RenderCorrectText(string betTeam, string expectedText)
        {
            // Arrange
            var ticket = Substitute.For<ITicket>();
            ticket.BetTeam = betTeam;
            var ticketHelper = Substitute.For<ITicketHelper>();
            var choice = new ChoiceCN469();

            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.AreEqual(expectedText, choice.Template.BetChoice.ChoiceName.choiceName);
        }
    }
}
