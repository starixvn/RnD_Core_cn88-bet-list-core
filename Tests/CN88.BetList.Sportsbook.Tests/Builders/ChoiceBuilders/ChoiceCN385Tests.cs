namespace CN88.BetList.Sportsbook.Tests.Builders.ChoiceBuilders
{
    using CN88.BetList.Core.Builders.ChoiceBuilders;
    using Fanex.BetList.Core.Entities;
    using NSubstitute;
    using NUnit.Framework;

    public class ChoiceCN385Tests
    {
        [Test]
        public void ChoiceCN385_Always_InheritBaseChoiceCN88()
        {
            // Assert
            Assert.AreEqual("BaseChoiceCN88", typeof(ChoiceCN385).BaseType.Name);
        }

        [TestCase("1", "Home name")]
        [TestCase("2", "Away name")]
        [TestCase("x", "Draw")]
        [TestCase("X", "Draw")]
        [TestCase("", "")]
        public void BuildChoiceName_Always_RenderCorrectText(string betTeam, string expectedText)
        {
            // Arrange
            var ticket = Substitute.For<ITicket>();
            ticket.BetTeam = betTeam;
            var ticketHelper = Substitute.For<ITicketHelper>();
            ticketHelper.GetTeamNameById(Arg.Any<long>()).Returns(expectedText);
            var choice = new ChoiceCN385();

            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.AreEqual(expectedText, choice.Template.BetChoice.ChoiceName.choiceName);
        }
    }
}
