namespace CN88.BetList.Sportsbook.Tests.Builders.ChoiceBuilders
{
    using CN88.BetList.Core.Builders.ChoiceBuilders;
    using Fanex.BetList.Core.Entities;
    using NSubstitute;
    using NUnit.Framework;

    public class ChoiceCN15Tests
    {
        private ChoiceCN15 choice;
        private ITicket ticket;
        private ITicketHelper ticketHelper;

        [SetUp]
        public void Setup()
        {
            const int homeId = 1;
            const int awayId = 2;

            ticket = Substitute.For<ITicket>();
            ticket.HomeId = homeId;
            ticket.AwayId = awayId;

            ticketHelper = Substitute.For<ITicketHelper>();
            ticketHelper.GetTeamNameById(Arg.Is<long>(i => i == homeId)).Returns("Home Name");
            ticketHelper.GetTeamNameById(Arg.Is<long>(i => i == awayId)).Returns("Away Name");

            choice = new ChoiceCN15();
        }

        [Test]
        public void ChoiceCN15_Always_InheritBaseChoiceCN88()
        {
            // Assert
            Assert.AreEqual("BaseChoiceCN88", typeof(ChoiceCN15).BaseType.Name);
        }

        [TestCase("1", "Home Name")]
        [TestCase("A", "")]
        [TestCase("X", "Draw")]
        [TestCase("2", "Away Name")]
        public void BuildBetChoice_Always_RenderCorrectText(string betTeam, string expectedText)
        {
            // Arrange
            ticket.BetTeam = betTeam;

            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.AreEqual(expectedText, choice.Template.BetChoice.ChoiceName.choiceName);
        }
    }
}
