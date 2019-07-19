namespace CN88.BetList.ESports.Tests.Builders.ChoiceBuilders
{
    using CN88.BetList.Core.Builders.ChoiceBuilders;
    using Fanex.BetList.Core.Entities;
    using NSubstitute;
    using NUnit.Framework;

    public class ChoiceCN9003Tests
    {
        [TestCase("o", "Over")]
        [TestCase("O", "Over")]
        [TestCase("e", "Under")]
        [TestCase("E", "Under")]
        [TestCase("", "Under")]
        [TestCase("a", "Under")]
        public void BuildChoiceName_Always_RenderCorrectText(string betTeam, string expectedText)
        {
            // Arrange
            var ticket = Substitute.For<ITicket>();
            var ticketHelper = Substitute.For<ITicketHelper>();
            ticket.BetTeam = betTeam;
            var choice = new ChoiceCN9003();

            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.AreEqual(expectedText, choice.Template.BetChoice.ChoiceName.choiceName);
        }

        [Test]
        public void ChoiceCN9003_Always_InheritChoiceCN3()
        {
            // Assert
            Assert.AreEqual("ChoiceCN3", typeof(ChoiceCN9003).BaseType.Name);
        }
    }
}
