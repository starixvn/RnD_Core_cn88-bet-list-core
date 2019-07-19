namespace CN88.BetList.Sportsbook.Tests.Builders.ChoiceBuilders
{
    using CN88.BetList.Core.Builders.ChoiceBuilders;
    using Fanex.BetList.Core.Entities;
    using NSubstitute;
    using NUnit.Framework;

    public class ChoiceCN223Tests
    {
        private ChoiceCN223 choice;
        private ITicket ticket;
        private ITicketHelper ticketHelper;

        [SetUp]
        public void Setup()
        {
            ticket = Substitute.For<ITicket>();
            ticketHelper = Substitute.For<ITicketHelper>();
            choice = new ChoiceCN223();
        }

        [Test]
        public void ChoiceCN223_Always_InheritBaseChoiceCN88()
        {
            // Assert
            Assert.AreEqual("BaseChoiceCN88", typeof(ChoiceCN223).BaseType.Name);
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
    }
}
