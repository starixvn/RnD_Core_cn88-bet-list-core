namespace CN88.BetList.Sportsbook.Tests.Builders.ChoiceBuilders
{
    using CN88.BetList.Core.Builders.ChoiceBuilders;
    using Fanex.BetList.Core.Entities;
    using NSubstitute;
    using NUnit.Framework;

    public class ChoiceCN608Tests
    {
        [Test]
        public void ChoiceCN608_Always_InheritChoiceCN602()
        {
            // Assert
            Assert.AreEqual("ChoiceCN602", typeof(ChoiceCN608).BaseType.Name);
        }

        [TestCase("d", "ResourceData")]
        [TestCase("D", "ResourceData")]
        [TestCase("", "")]
        public void BuildChoiceName_Always_RenderCorrectText(string betTeam, string expectedText)
        {
            // Arrange
            var ticket = Substitute.For<ITicket>();
            ticket.BetTeam = betTeam;
            var ticketHelper = Substitute.For<ITicketHelper>();
            ticketHelper.GetResourceData("WMBasketball", "D").Returns("ResourceData");

            var choice = new ChoiceCN608();

            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.AreEqual(expectedText, choice.Template.BetChoice.ChoiceName.choiceName);
        }
    }
}
