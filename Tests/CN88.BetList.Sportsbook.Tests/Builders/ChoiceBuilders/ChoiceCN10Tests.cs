namespace CN88.BetList.Sportsbook.Tests.Builders.ChoiceBuilders
{
    using CN88.BetList.Core.Builders.ChoiceBuilders;
    using Fanex.BetList.Core.Entities;
    using NSubstitute;
    using NUnit.Framework;

    public class ChoiceCN10Tests
    {
        private ChoiceCN10 choice;
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

            choice = new ChoiceCN10();
        }

        [Test]
        public void ChoiceCN10_Always_InheritBaseChoiceCN88()
        {
            // Assert
            Assert.AreEqual("BaseChoiceCN88", typeof(ChoiceCN10).BaseType.Name);
        }

        [TestCase(0, "Away Name")]
        [TestCase(1, "Home Name")]
        public void BuildBetChoice_Always_RenderCorrectText(int homeId, string expectedText)
        {
            // Arrange
            ticket.HomeId = homeId;
            ticket.AwayId = 2;

            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.AreEqual(expectedText, choice.Template.BetChoice.ChoiceName.choiceName);
        }

        [Test]
        public void BuildBetChoice_Always_HideCorrectElements()
        {
            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.True(!choice.Template.Match.Visible &&
                !choice.Template.MatchByTeamId.Visible);
        }
    }
}
