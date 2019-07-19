namespace CN88.BetList.NumberGame.Tests.Builders.ChoiceBuilders
{
    using CN88.BetList.Core.Builders.ChoiceBuilders;
    using Fanex.BetList.Core.Entities;
    using NSubstitute;
    using NUnit.Framework;

    public class ChoiceCN88Tests
    {
        [Test]
        public void ChoiceCN88_Always_InheritBaseNumberGameChoiceCN88()
        {
            // Assert
            Assert.AreEqual("BaseNumberGameChoiceCN88", typeof(ChoiceCN88).BaseType.Name);
        }

        [TestCase("h", "2nd ball win")]
        [TestCase("a", "3rd ball win")]
        [TestCase("", "3rd ball win")]
        public void BuildChoiceName_Always_RenderCorrectText(string betTeam, string expectedText)
        {
            // Arrange
            var ticket = Substitute.For<ITicket>();
            ticket.BetTeam = betTeam;
            var ticketHelper = Substitute.For<ITicketHelper>();
            var choice = new ChoiceCN88();

            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.AreEqual(expectedText, choice.Template.BetChoice.ChoiceName.choiceName);
        }
    }
}
