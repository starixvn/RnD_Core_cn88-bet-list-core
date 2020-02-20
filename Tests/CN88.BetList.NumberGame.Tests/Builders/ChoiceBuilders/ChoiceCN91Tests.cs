namespace CN88.BetList.NumberGame.Tests.Builders.ChoiceBuilders
{
    using CN88.BetList.Core.Builders.ChoiceBuilders;
    using Fanex.BetList.Core.Entities;
    using NSubstitute;
    using NUnit.Framework;

    public class ChoiceCN91Tests
    {
        private ChoiceCN91 choice;
        private ITicket ticket;
        private ITicketHelper ticketHelper;

        [SetUp]
        public void Setup()
        {
            choice = new ChoiceCN91();
            ticket = Substitute.For<ITicket>();
            ticketHelper = Substitute.For<ITicketHelper>();
        }

        [Test]
        public void ChoiceCN91_Always_InheritBaseNumberGameChoiceCN88()
        {
            // Assert
            Assert.AreEqual("BaseNumberGameChoiceCN88", typeof(ChoiceCN91).BaseType.Name);
        }

        [TestCase("r", "Red")]
        [TestCase("b", "Blue")]
        public void BuildChoiceName_Always_RenderCorrectText(string betTeam, string expectedText)
        {
            // Arrange
            ticket.BetTeam = betTeam;

            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.AreEqual(expectedText, choice.Template.BetChoice.ChoiceName.choiceName);
        }

        [Test]
        public void BuildMatch_Always_SetMatchByTeamIdIsNull()
        {
            // Act
            var choiceTemplate = choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.IsNull(choiceTemplate.MatchByTeamId);
        }

        [Test]
        public void BuildMatch_Always_SetHomeTeamCorrectText()
        {
            // Arrange
            ticket.MatchCode = "123";

            // Act
            var choiceTemplate = choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.AreEqual("Number Game No&nbsp;123", choiceTemplate.Match.homeTeam);
        }

        [Test]
        public void BuildMatch_Always_SetAwayTeamIsEmpty()
        {
            // Arrange

            // Act
            var choiceTemplate = choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.IsEmpty(choiceTemplate.Match.awayTeam);
        }

        [Test]
        public void BuildMatch_Always_SetMatchVSIsNull()
        {
            // Arrange

            // Act
            var choiceTemplate = choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.IsNull(choiceTemplate.Match.VS);
        }

        [Test]
        public void BuildMatch_Always_SetMatchHandicapIsNull()
        {
            // Arrange

            // Act
            var choiceTemplate = choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.IsNull(choiceTemplate.Match.Handicap);
        }

        [Test]
        public void BuildMatch_Always_SetLiveScoreIsBetId()
        {
            // Arrange
            ticket.BetId = 20;

            // Act
            var choiceTemplate = choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.AreEqual("(20)", choiceTemplate.Match.LiveScore.liveScore);
        }
    }
}
