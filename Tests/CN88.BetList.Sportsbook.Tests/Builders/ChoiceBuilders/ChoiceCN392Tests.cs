namespace CN88.BetList.Sportsbook.Tests.Builders.ChoiceBuilders
{
    using CN88.BetList.Core.Builders.ChoiceBuilders;
    using Fanex.BetList.Core.Entities;
    using NSubstitute;
    using NUnit.Framework;

    public class ChoiceCN392Tests
    {
        [Test]
        public void ChoiceCN392_Always_InheritChoiceCN4()
        {
            // Assert
            Assert.AreEqual("ChoiceCN4", typeof(ChoiceCN392).BaseType.Name);
        }

        [TestCase("HAOS", "Home To Win With AOS")]
        [TestCase("haos", "Home To Win With AOS")]
        [TestCase("AAOS", "Away To Win With AOS")]
        [TestCase("aaos", "Away To Win With AOS")]
        [TestCase("", "")]
        public void BuildChoiceName_Always_RenderCorrectText(string betTeam, string expectedText)
        {
            // Arrange
            var ticket = Substitute.For<ITicket>();
            ticket.BetTeam = betTeam;
            ticket.TransDesc = "1:1,1:2";
            var ticketHelper = Substitute.For<ITicketHelper>();
            var choice = new ChoiceCN392();

            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.AreEqual(expectedText, choice.Template.BetChoice.ChoiceName.choiceName);
        }
    }
}
