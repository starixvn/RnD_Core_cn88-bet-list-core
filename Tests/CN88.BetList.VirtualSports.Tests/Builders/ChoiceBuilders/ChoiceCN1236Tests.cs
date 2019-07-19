namespace CN88.BetList.VirtualSports.Tests.Builders.ChoiceBuilders
{
    using CN88.BetList.Core.Builders.ChoiceBuilders;
    using Fanex.BetList.Core.Entities;
    using NSubstitute;
    using NUnit.Framework;

    public class ChoiceCN1236Tests
    {
        private ChoiceCN1236 choice;
        private ITicket ticket;
        private ITicketHelper ticketHelper;

        [SetUp]
        public void Setup()
        {
            ticket = Substitute.For<ITicket>();
            choice = new ChoiceCN1236();
            ticketHelper = Substitute.For<ITicketHelper>();
        }

        [Test]
        public void ChoiceCN1236_Always_InheritBaseVirtualSportsChoiceCN88()
        {
            // Assert
            Assert.AreEqual("BaseVirtualSportsChoiceCN88", typeof(ChoiceCN1236).BaseType.Name);
        }

        [Test]
        public void BuildBetChoice_Always_HideCorrectElements()
        {
            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.True(!choice.Template.Match.LiveScore.Visible &&
                !choice.Template.BetChoiceMoreInfo.Visible &&
                !choice.Template.BetChoice.ChoiceValue.Visible);
        }

        [Test]
        public void BuildChoiceName_Always_RenderCorrectText()
        {
            // Arrange
            ticket.BetTeam = "1";

            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.AreEqual("1 Points", choice.Template.BetChoice.ChoiceName.choiceName);
        }
    }
}
