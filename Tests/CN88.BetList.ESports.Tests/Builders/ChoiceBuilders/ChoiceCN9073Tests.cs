namespace CN88.BetList.ESports.Tests.Builders.ChoiceBuilders
{
    using CN88.BetList.Core.Builders.ChoiceBuilders;
    using Fanex.BetList.Core.Entities;
    using NSubstitute;
    using NUnit.Framework;

    public class ChoiceCN9073Tests
    {
        [TestCase("y", "Yes")]
        [TestCase("Y", "Yes")]
        [TestCase("n", "No")]
        [TestCase("N", "No")]
        [TestCase("", "")]
        [TestCase("a", "")]
        public void BuildChoiceName_Always_RenderCorrectText(string betTeam, string expectedText)
        {
            // Arrange
            var ticket = Substitute.For<ITicket>();
            var ticketHelper = Substitute.For<ITicketHelper>();
            ticket.BetTeam = betTeam;
            var choice = new ChoiceCN9073();

            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.AreEqual(expectedText, choice.Template.BetChoice.ChoiceName.choiceName);
        }

        [Test]
        public void ChoiceCN9073_Always_InheritBaseChoiceCN88()
        {
            // Assert
            Assert.AreEqual("BaseChoiceCN88", typeof(ChoiceCN9073).BaseType.Name);
        }
    }
}
