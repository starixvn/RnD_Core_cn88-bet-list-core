namespace CN88.BetList.Sportsbook.Tests.Builders.ChoiceBuilders
{
    using CN88.BetList.Core.Builders.ChoiceBuilders;
    using Fanex.BetList.Core.Entities;
    using NSubstitute;
    using NUnit.Framework;

    public class ChoiceCN143Tests
    {
        private ChoiceCN143 choice;
        private ITicket ticket;
        private ITicketHelper ticketHelper;

        [SetUp]
        public void Setup()
        {
            ticket = Substitute.For<ITicket>();
            ticketHelper = Substitute.For<ITicketHelper>();
            choice = new ChoiceCN143();
        }

        [Test]
        public void ChoiceCN143_Always_InheritChoiceCN3()
        {
            // Assert
            Assert.AreEqual("ChoiceCN3", typeof(ChoiceCN143).BaseType.Name);
        }

        [TestCase("", "")]
        [TestCase("hhh", "")]
        [TestCase("ho", "Home/Over")]
        [TestCase("ao", "Away/Over")]
        [TestCase("do", "Draw/Over")]
        [TestCase("hu", "Home/Under")]
        [TestCase("au", "Away/Under")]
        [TestCase("du", "Draw/Under")]
        [TestCase("hh", "Home/Under")]
        [TestCase("ah", "Away/Under")]
        [TestCase("dh", "Draw/Under")]
        [TestCase("xh", "/Under")]
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
