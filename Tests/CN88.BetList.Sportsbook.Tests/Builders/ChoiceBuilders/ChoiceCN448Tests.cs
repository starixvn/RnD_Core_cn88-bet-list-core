namespace CN88.BetList.Sportsbook.Tests.Builders.ChoiceBuilders
{
    using CN88.BetList.Core.Builders.ChoiceBuilders;
    using Fanex.BetList.Core.Entities;
    using NSubstitute;
    using NUnit.Framework;

    public class ChoiceCN448Tests
    {
        [Test]
        public void ChoiceCN448_Always_InheritBaseChoiceCN88()
        {
            // Assert
            Assert.AreEqual("BaseChoiceCN88", typeof(ChoiceCN448).BaseType.Name);
        }

        [TestCase(null, "")]
        [TestCase("h", "Home")]
        [TestCase("a", "Away")]
        [TestCase("ng", "No Goal")]
        public void BuildChoiceName_Always_RenderCorrectText(string betTeam, string expectedText)
        {
            // Arrange
            var ticket = Substitute.For<ITicket>();
            ticket.BetTeam = betTeam;
            ticket.HomeId = 1;
            ticket.AwayId = 2;

            var ticketHelper = Substitute.For<ITicketHelper>();
            ticketHelper.GetTeamNameById(Arg.Is<object>(o => (long)o == 1)).Returns("Home");
            ticketHelper.GetTeamNameById(Arg.Is<object>(o => (long)o == 2)).Returns("Away");
            var choice = new ChoiceCN448();

            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.AreEqual(expectedText, choice.Template.BetChoice.ChoiceName.choiceName);
        }
    }
}
