namespace CN88.BetList.Sportsbook.Tests.Builders.ChoiceBuilders
{
    using CN88.BetList.Core.Builders.ChoiceBuilders;
    using Fanex.BetList.Core.Entities;
    using NSubstitute;
    using NUnit.Framework;

    public class ChoiceCN711Tests
    {
        private ChoiceCN711 choice;
        private ITicket ticket;
        private ITicketHelper ticketHelper;

        [SetUp]
        public void Setup()
        {
            ticket = Substitute.For<ITicket>();
            choice = new ChoiceCN711();
            ticketHelper = Substitute.For<ITicketHelper>();
            ticketHelper.GetResourceData("WMBadminton", Arg.Any<string>()).Returns(args => "{0} " + args[1]);
        }

        [Test]
        public void ChoiceCN711_Always_InheritBaseChoiceCN88()
        {
            // Assert
            Assert.AreEqual("BaseChoiceCN88", typeof(ChoiceCN711).BaseType.Name);
        }

        [TestCase("H1-2", "Home 1-2")]
        [TestCase("H3-5", "Home 3-5")]
        [TestCase("H6-8", "Home 6-8")]
        [TestCase("H9+", "Home 9+")]
        [TestCase("A1-2", "Away 1-2")]
        [TestCase("A3-5", "Away 3-5")]
        [TestCase("A6-8", "Away 6-8")]
        [TestCase("A9+", "Away 9+")]
        public void BuildBetChoice_Always_RenderCorrectChoiceName(string betTeam, string expectedChoiceName)
        {
            // Arrange
            ticket.BetTeam = betTeam;

            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.AreEqual(expectedChoiceName, choice.Template.BetChoice.ChoiceName.choiceName);
        }
    }
}
