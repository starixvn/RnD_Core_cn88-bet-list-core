namespace CN88.BetList.VirtualSports.Tests.Builders.ChoiceBuilders
{
    using CN88.BetList.Core.Builders.ChoiceBuilders;
    using Fanex.BetList.Core.Entities;
    using NSubstitute;
    using NUnit.Framework;

    public class ChoiceCN2701Tests
    {
        private ChoiceCN2701 choice;
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

            choice = new ChoiceCN2701();
        }

        [Test]
        public void ChoiceCN2701_Always_InheritBaseVirtualSportsChoiceCN88()
        {
            // Assert
            Assert.AreEqual("BaseVirtualSportsChoiceCN88", typeof(ChoiceCN2701).BaseType.Name);
        }

        [Test]
        public void BuildBetChoice_Always_HideMoreInfoAndChoiceValue()
        {
            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.True(!choice.Template.BetChoiceMoreInfo.Visible &&
                !choice.Template.BetChoice.ChoiceValue.Visible);
        }

        [TestCase("1", "Home Name")]
        [TestCase("A", "")]
        [TestCase("X", "Draw")]
        [TestCase("2", "Away Name")]
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
        public void BuildBetChoice_Always_ShowKickOffTime()
        {
            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.True(choice.Template.KickOffTime.Visible);
        }

        [TestCase("", "")]
        [TestCase(null, "")]
        [TestCase("t='1'", "")]
        [TestCase("m=\"E0001\"", "")]
        public void BuildBetChoice_Always_RenderCorrectKickOffTime(string transDesc, string expectedText)
        {
            // Arrange
            ticket.TransDesc = transDesc;
            ticketHelper.GetBetRadarMatchCodeFormat("1").Returns("Match Code");

            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.AreEqual(expectedText, choice.Template.KickOffTime.kickOffTime);
        }
    }
}
