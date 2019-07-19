namespace CN88.BetList.Lottery.Tests.Builders.ChoiceBuilders
{
    using CN88.BetList.Core.Builders.ChoiceBuilders;
    using Fanex.BetList.Core.Entities;
    using NSubstitute;
    using NUnit.Framework;

    public class ChoiceCN1031Tests
    {
        private ChoiceCN1031 choice;
        private ITicket ticket;
        private ITicketHelper ticketHelper;

        [SetUp]
        public void Setup()
        {
            ticket = Substitute.For<ITicket>();
            choice = new ChoiceCN1031();
            ticketHelper = Substitute.For<ITicketHelper>();
        }

        [Test]
        public void ChoiceCN1031_Always_InheritBaseChoiceCN88()
        {
            // Assert
            Assert.AreEqual("BaseChoiceCN88", typeof(ChoiceCN1031).BaseType.Name);
        }

        [Test]
        public void BuildLeague_Always_RendersCorrectLeagueName()
        {
            // Arrange
            ticket.TransDesc = "betChoice=GameId,100;";
            ticketHelper.GetBetTypeNameById(Arg.Any<object>()).Returns("BetTypeName");

            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.AreEqual("BetTypeName [GameId]", choice.Template.League.LeagueName.leagueName);
        }

        [Test]
        public void BuildMatch_Always_HideCorrectElements()
        {
            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.True(!choice.Template.MatchByTeamId.Visible &&
                !choice.Template.Match.Visible);
        }

        [Test]
        public void BuildBetChoice_Always_HideCorrectElements()
        {
            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.True(!choice.Template.BetChoiceMoreInfo.Visible &&
                !choice.Template.BetChoice.ChoiceValue.Visible);
        }

        [TestCase("betChoice=1,100;")]
        [TestCase("betChoice=1,107;")]
        [TestCase("betChoice=1,a;")]
        public void BuildBetChoice_Always_RenderCorrectText(string transDesc)
        {
            // Arrange
            ticket.TransDesc = transDesc;
            ticketHelper.GetLotteryBetChoiceName(Arg.Any<string>(), out _).Returns("LotteryBetChoiceName");

            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.AreEqual("LotteryBetChoiceName", choice.Template.BetChoice.ChoiceName.choiceName);
        }
    }
}
