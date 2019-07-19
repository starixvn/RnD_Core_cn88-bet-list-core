namespace CN88.BetList.Keno.Tests.Builders.ChoiceBuilders
{
    using CN88.BetList.Core.Builders.ChoiceBuilders;
    using Fanex.BetList.Core.Entities;
    using NSubstitute;
    using NUnit.Framework;

    public class ChoiceCN1501Tests
    {
        private ChoiceCN1501 choice;
        private ITicket ticket;
        private ITicketHelper ticketHelper;

        [SetUp]
        public void Setup()
        {
            ticket = Substitute.For<ITicket>();
            ticketHelper = Substitute.For<ITicketHelper>();
            choice = new ChoiceCN1501();
        }

        [Test]
        public void ChoiceCN1501_Always_InheritChoiceCN3()
        {
            // Assert
            Assert.AreEqual("BaseChoiceCN88", typeof(ChoiceCN1501).BaseType.Name);
        }

        [TestCase("betChoice=1,2;")]
        public void BuildLeague_Always_RenderCorrectText(string transDec)
        {
            // Arrange
            ticket.TransDesc = transDec;
            ticketHelper.GetBetTypeNameById(Arg.Any<object>()).Returns("BetTypeName");

            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.AreEqual("BetTypeName [1]", choice.Template.League.LeagueName.leagueName);
        }

        [Test]
        public void BuildMatch_Always_HideCorrectElements()
        {
            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.True(!choice.Template.MatchByTeamId.Visible && !choice.Template.Match.Visible);
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

        [TestCase("betChoice=1;", "KenoBetChoiceName")]
        [TestCase("betChoice=2,;", "KenoBetChoiceName")]
        [TestCase("betChoice=2,32;", "KenoBetChoiceName")]
        [TestCase("betChoice=2,35;", "KenoBetChoiceName")]
        public void BuildBetChoice_NotHaveChoiceId_RenderCorrectText(string transDesc, string expectedText)
        {
            // Arrange
            ticket.TransDesc = transDesc;
            ticketHelper.GetKenoBetChoiceName(Arg.Any<string>(), out string _).Returns("KenoBetChoiceName");

            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.AreEqual(expectedText, choice.Template.BetChoice.ChoiceName.choiceName);
        }

        [TestCase("betChoice=2,33;", null, "KenoBetChoiceName")]
        [TestCase("betChoice=2,33;", "", "KenoBetChoiceName")]
        [TestCase("betChoice=2,33;", "BetCheck", "KenoBetChoiceName")]
        [TestCase("betChoice=2,33;", "0", "KenoBetChoiceName")]
        [TestCase("betChoice=2,34;", "1", "KenoBetChoiceName")]
        public void BuildBetChoice_HaveChoiceId_RenderCorrectText(
            string transDesc, string betCheck, string expectedText)
        {
            // Arrange
            ticket.TransDesc = transDesc;
            ticket.BetCheck = betCheck;
            ticket.Stake = 5;
            ticketHelper.GetKenoBetChoiceName(Arg.Any<string>(), out string _).Returns("KenoBetChoiceName");

            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.AreEqual(expectedText, choice.Template.BetChoice.ChoiceName.choiceName);
        }
    }
}
