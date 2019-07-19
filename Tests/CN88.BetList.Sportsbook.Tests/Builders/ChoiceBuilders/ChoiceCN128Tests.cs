namespace CN88.BetList.Sportsbook.Tests.Builders.ChoiceBuilders
{
    using CN88.BetList.Core.Builders.ChoiceBuilders;
    using Fanex.BetList.Core.Entities;
    using NSubstitute;
    using NUnit.Framework;

    public class ChoiceCN128Tests
    {
        private ChoiceCN128 choice;
        private ITicket ticket;
        private ITicketHelper ticketHelper;

        [SetUp]
        public void Setup()
        {
            ticket = Substitute.For<ITicket>();
            ticketHelper = Substitute.For<ITicketHelper>();
            choice = new ChoiceCN128();
        }

        [Test]
        public void ChoiceCN128_Always_InheritChoiceCN3()
        {
            // Assert
            Assert.AreEqual("BaseChoiceCN88", typeof(ChoiceCN128).BaseType.Name);
        }

        [TestCase(null, "")]
        [TestCase("oo", "Odd/Odd")]
        [TestCase("oe", "Odd/Even")]
        [TestCase("eo", "Even/Odd")]
        [TestCase("ee", "Even/Even")]
        [TestCase("", "")]
        [TestCase("a", "")]
        [TestCase("ao", "")]
        [TestCase("ae", "")]
        [TestCase("oa", "")]
        [TestCase("ea", "")]
        [TestCase("aa", "")]
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
