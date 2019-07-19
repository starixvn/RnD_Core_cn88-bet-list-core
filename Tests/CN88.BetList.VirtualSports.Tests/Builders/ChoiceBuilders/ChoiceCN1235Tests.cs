namespace CN88.BetList.VirtualSports.Tests.Builders.ChoiceBuilders
{
    using CN88.BetList.Core.Builders.ChoiceBuilders;
    using Fanex.BetList.Core.Entities;
    using NSubstitute;
    using NUnit.Framework;

    public class ChoiceCN1235Tests
    {
        private ChoiceCN1235 choice;
        private ITicket ticket;
        private ITicketHelper ticketHelper;

        [SetUp]
        public void Setup()
        {
            ticket = Substitute.For<ITicket>();
            choice = new ChoiceCN1235();
            ticketHelper = Substitute.For<ITicketHelper>();
        }

        [Test]
        public void ChoiceCN1235_Always_InheritBaseVirtualSportsChoiceCN88()
        {
            // Assert
            Assert.AreEqual("BaseVirtualSportsChoiceCN88", typeof(ChoiceCN1235).BaseType.Name);
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

        [TestCase("1", "Win-0")]
        [TestCase("2", "Win-15")]
        [TestCase("3", "Win-30")]
        [TestCase("4", "Win-40")]
        [TestCase("5", "0-Win")]
        [TestCase("6", "15-Win")]
        [TestCase("7", "30-Win")]
        [TestCase("8", "40-Win")]
        [TestCase("", "")]
        [TestCase(" 8", "40-Win")]
        [TestCase(" 8  ", "40-Win")]
        [TestCase("8    ", "40-Win")]
        public void BuildChoiceName_Always_RenderCorrectText(string betTeam, string expectedText)
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
