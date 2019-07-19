namespace CN88.BetList.Sportsbook.Tests.Builders.ChoiceBuilders
{
    using CN88.BetList.Core.Builders.ChoiceBuilders;
    using Fanex.BetList.Core.Entities;
    using NSubstitute;
    using NUnit.Framework;

    public class ChoiceCN221Tests
    {
        private ChoiceCN221 choice;
        private ITicket ticket;
        private ITicketHelper ticketHelper;

        [SetUp]
        public void Setup()
        {
            ticket = Substitute.For<ITicket>();
            ticketHelper = Substitute.For<ITicketHelper>();
            choice = new ChoiceCN221();
        }

        [Test]
        public void ChoiceCN221_Always_InheritChoiceCN3()
        {
            // Assert
            Assert.AreEqual("ChoiceCN3", typeof(ChoiceCN221).BaseType.Name);
        }

        [Test]
        public void BuildBetChoice_Always_RenderCorrectText()
        {
            // Arrange
            var expectedText = "Fast Market";
            ticketHelper.GetFastMarketSituation(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<decimal>(), Arg.Any<decimal>())
                .Returns(expectedText);

            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.AreEqual(expectedText, choice.Template.BetChoice.ChoiceName.choiceName);
        }

        [Test]
        public void BuildBetChoice_Always_RenderCorrectChoiceValue()
        {
            // Arrange
            ticket.OddsSpread = 1;

            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.AreEqual("1", choice.Template.BetChoice.ChoiceValue.choiceValue);
        }
    }
}
