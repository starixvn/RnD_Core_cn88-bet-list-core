namespace CN88.BetList.Sportsbook.Tests.Builders.ChoiceBuilders
{
    using CN88.BetList.Core.Builders.ChoiceBuilders;
    using Fanex.BetList.Core.Entities;
    using NSubstitute;
    using NUnit.Framework;

    public class ChoiceCN28Tests
    {
        private ChoiceCN28 choice;
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

            choice = new ChoiceCN28();
        }

        [Test]
        public void ChoiceCN28_Always_InheritBaseChoiceCN88()
        {
            // Assert
            Assert.AreEqual("BaseChoiceCN88", typeof(ChoiceCN28).BaseType.Name);
        }

        [TestCase("1", "Home Name (0)")]
        [TestCase("2", "Away Name (0)")]
        [TestCase("", "Draw (0)")]
        [TestCase("x", "Draw (0)")]
        public void BuildBetChoice_Always_RenderCorrectText(string betTeam, string expectedText)
        {
            // Arrange
            ticket.BetTeam = betTeam;

            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.AreEqual(expectedText, choice.Template.BetChoice.ChoiceName.choiceName);
        }

        [TestCase(2, 1, "Draw (A+1)")]
        [TestCase(1, 2, "Draw (H+1)")]
        [TestCase(2, 2, "Draw (0)")]
        public void BuildBetChoice_Always_RenderCorrectHDP(decimal hdp1, decimal hdp2, string expectedText)
        {
            // Arrange
            ticket.BetTeam = "x";
            ticket.Handicap1 = hdp1;
            ticket.Handicap2 = hdp2;

            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.AreEqual(expectedText, choice.Template.BetChoice.ChoiceName.choiceName);
        }
    }
}
