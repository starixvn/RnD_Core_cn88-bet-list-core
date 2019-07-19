namespace CN88.BetList.Sportsbook.Tests.Builders.ChoiceBuilders
{
    using CN88.BetList.Core.Builders.ChoiceBuilders;
    using Fanex.BetList.Core.Entities;
    using NSubstitute;
    using NUnit.Framework;

    public class ChoiceCN417Tests
    {
        [Test]
        public void ChoiceCN417_Always_InheritBaseChoiceCN88()
        {
            // Assert
            Assert.AreEqual("BaseChoiceCN88", typeof(ChoiceCN417).BaseType.Name);
        }

        [TestCase("yh", "Yes/Home")]
        [TestCase("yd", "Yes/Draw")]
        [TestCase("ya", "Yes/Away")]
        [TestCase("nh", "No/Home")]
        [TestCase("nd", "No/Draw")]
        [TestCase("na", "No/Away")]
        [TestCase("", "")]
        public void BuildChoiceName_Always_RenderCorrectText(string betTeam, string expectedText)
        {
            // Arrange
            var ticket = Substitute.For<ITicket>();
            ticket.BetTeam = betTeam;
            var ticketHelper = Substitute.For<ITicketHelper>();
            var choice = new ChoiceCN417();

            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.AreEqual(expectedText, choice.Template.BetChoice.ChoiceName.choiceName);
        }
    }
}
