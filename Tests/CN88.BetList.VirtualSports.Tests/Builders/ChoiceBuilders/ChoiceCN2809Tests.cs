namespace CN88.BetList.VirtualSports.Tests.Builders.ChoiceBuilders
{
    using CN88.BetList.Core.Builders.ChoiceBuilders;
    using Fanex.BetList.Core.Entities;
    using NSubstitute;
    using NUnit.Framework;

    public class ChoiceCN2809Tests
    {
        private ChoiceCN2809 choice;
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
            choice = new ChoiceCN2809();

            ticketHelper = Substitute.For<ITicketHelper>();
            ticketHelper.GetTeamNameById(Arg.Is<long>(i => i == homeId)).Returns("Home Name");
            ticketHelper.GetTeamNameById(Arg.Is<long>(i => i == awayId)).Returns("Away Name");
        }

        [Test]
        public void ChoiceCN2809_Always_InheritChoiceCN2807()
        {
            // Assert
            Assert.AreEqual("ChoiceCN2807", typeof(ChoiceCN2809).BaseType.Name);
        }

        [TestCase("h", "Home Name")]
        [TestCase("H", "Home Name")]
        [TestCase("a", "Away Name")]
        [TestCase("A", "Away Name")]
        [TestCase("", "")]
        public void BuildBetChoice_Always_RenderCorrectText(string betTeam, string expectedText)
        {
            // Arrange
            ticket.BetTeam = betTeam;

            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.AreEqual(expectedText, choice.Template.BetChoice.ChoiceName.choiceName);
        }

        [Test]
        public void BuildBetChoice_Always_HideMoreInfoAndChoiceValue()
        {
            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.True(!choice.Template.BetChoiceMoreInfo.Visible && !choice.Template.BetChoice.ChoiceValue.Visible);
        }
    }
}
