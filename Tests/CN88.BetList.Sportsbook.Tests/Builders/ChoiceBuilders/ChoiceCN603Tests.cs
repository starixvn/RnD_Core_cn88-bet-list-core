namespace CN88.BetList.Sportsbook.Tests.Builders.ChoiceBuilders
{
    using CN88.BetList.Core.Builders.ChoiceBuilders;
    using Fanex.BetList.Core.Entities;
    using NSubstitute;
    using NUnit.Framework;

    public class ChoiceCN603Tests
    {
        [Test]
        public void ChoiceCN603_Always_InheritBaseChoiceCN88()
        {
            // Assert
            Assert.AreEqual("BaseChoiceCN88", typeof(ChoiceCN603).BaseType.Name);
        }

        [TestCase("h", "HomeName")]
        [TestCase("H", "HomeName")]
        [TestCase("a", "AwayName")]
        [TestCase("A", "AwayName")]
        [TestCase("", "")]
        public void BuildChoiceName_Always_RenderCorrectText(string betTeam, string expectedText)
        {
            // Arrange
            var ticket = Substitute.For<ITicket>();
            ticket.BetTeam = betTeam;
            ticket.HomeId = 1;
            ticket.AwayId = 2;

            var ticketHelper = Substitute.For<ITicketHelper>();
            ticketHelper.GetTeamNameById(Arg.Is<object>(o => (long)o == 1)).Returns("HomeName");
            ticketHelper.GetTeamNameById(Arg.Is<object>(o => (long)o == 2)).Returns("AwayName");

            var choice = new ChoiceCN603();

            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.AreEqual(expectedText, choice.Template.BetChoice.ChoiceName.choiceName);
        }
    }
}
