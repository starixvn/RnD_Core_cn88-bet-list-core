namespace CN88.BetList.NumberGame.Tests.Builders.ChoiceBuilders
{
    using CN88.BetList.Core.Builders.ChoiceBuilders;
    using Fanex.BetList.Core.Entities;
    using NSubstitute;
    using NUnit.Framework;

    public class ChoiceCN89Tests
    {
        private ChoiceCN89 choice;
        private ITicket ticket;
        private ITicketHelper ticketHelper;

        [SetUp]
        public void Setup()
        {
            ticket = Substitute.For<ITicket>();
            ticketHelper = Substitute.For<ITicketHelper>();
            choice = new ChoiceCN89();
        }

        [Test]
        public void ChoiceCN89_Always_InheritBaseNumberGameChoiceCN88()
        {
            // Assert
            Assert.AreEqual("BaseNumberGameChoiceCN88", typeof(ChoiceCN89).BaseType.Name);
        }

        [Test]
        public void BuildChoiceName_Always_ChoiceValueIsNull()
        {
            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.IsNull(choice.Template.BetChoice.ChoiceValue);
        }

        [TestCase("1:1", "Over 37.5/Odd")]
        [TestCase("1:2", "Over 37.5/Even")]
        [TestCase("2:1", "Under 37.5/Odd")]
        [TestCase("2:2", "Under 37.5/Even")]
        [TestCase("3:1", "")]
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
