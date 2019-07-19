namespace CN88.BetList.VirtualSports.Tests.Builders.ChoiceBuilders
{
    using CN88.BetList.Core.Builders.ChoiceBuilders;
    using Fanex.BetList.Core.Entities;
    using NSubstitute;
    using NUnit.Framework;

    public class ChoiceCN1204Tests
    {
        private ChoiceCN1204 choice;
        private ITicket ticket;
        private ITicketHelper ticketHelper;

        [SetUp]
        public void Setup()
        {
            ticket = Substitute.For<ITicket>();
            choice = new ChoiceCN1204();
            ticketHelper = Substitute.For<ITicketHelper>();
        }

        [Test]
        public void ChoiceCN1204_Always_InheritBaseVirtualSportsChoiceCN88()
        {
            // Assert
            Assert.AreEqual("BaseVirtualSportsChoiceCN88", typeof(ChoiceCN1204).BaseType.Name);
        }

        [Test]
        public void BuildBetChoice_Always_HideCorrectElements()
        {
            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.True(!choice.Template.BetChoiceMoreInfo.Visible
                && !choice.Template.BetChoice.ChoiceValue.Visible);
        }

        [TestCase("5:0", "5:0 UP")]
        [TestCase("0:5", "0:5 UP")]
        [TestCase("0:1", "0:1")]
        [TestCase("1:0", "1:0")]
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
