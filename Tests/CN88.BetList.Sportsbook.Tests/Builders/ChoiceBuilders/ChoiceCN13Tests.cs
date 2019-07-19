namespace CN88.BetList.Sportsbook.Tests.Builders.ChoiceBuilders
{
    using CN88.BetList.Core.Builders.ChoiceBuilders;
    using Fanex.BetList.Core.Entities;
    using NSubstitute;
    using NUnit.Framework;

    public class ChoiceCN13Tests
    {
        private ChoiceCN13 choice;
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

            choice = new ChoiceCN13();
        }

        [Test]
        public void ChoiceCN13_Always_InheritChoiceCN3()
        {
            // Assert
            Assert.AreEqual("BaseChoiceCN88", typeof(ChoiceCN13).BaseType.Name);
        }

        [TestCase(null, "Away Name NO")]
        [TestCase("", "Away Name NO")]
        [TestCase("hy", "Home Name YES")]
        [TestCase("hn", "Home Name NO")]
        [TestCase("yh", "Home Name YES")]
        [TestCase("nh", "Home Name NO")]
        [TestCase("ay", "Away Name YES")]
        [TestCase("an", "Away Name NO")]
        [TestCase("ya", "Away Name YES")]
        [TestCase("na", "Away Name NO")]
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
