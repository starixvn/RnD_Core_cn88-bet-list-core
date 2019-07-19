namespace CN88.BetList.VirtualSports.Tests.Builders.ChoiceBuilders
{
    using CN88.BetList.Core.Builders.ChoiceBuilders;
    using Fanex.BetList.Core.Entities;
    using NSubstitute;
    using NUnit.Framework;

    public class ChoiceCN2808Tests
    {
        private ChoiceCN2808 choice;
        private ITicket ticket;
        private ITicketHelper ticketHelper;

        [SetUp]
        public void Setup()
        {
            ticket = Substitute.For<ITicket>();
            choice = new ChoiceCN2808();
            ticketHelper = Substitute.For<ITicketHelper>();
            ticketHelper.GetResourceData("WMBasketball", "D").Returns("Draw");
        }

        [Test]
        public void ChoiceCN2808_Always_InheritChoiceCN2807()
        {
            // Assert
            Assert.AreEqual("ChoiceCN2807", typeof(ChoiceCN2808).BaseType.Name);
        }

        [Test]
        public void BuildBetChoice_BetTeamIsD_RenderCorrectText()
        {
            // Arrange
            ticket.BetTeam = "d";

            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.AreEqual("Draw", choice.Template.BetChoice.ChoiceName.choiceName);
        }

        [Test]
        public void BuildBetChoice_BetTeamIsNotD_RenderCorrectText()
        {
            // Arrange
            ticket.BetTeam = "a";

            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.AreEqual("", choice.Template.BetChoice.ChoiceName.choiceName);
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
