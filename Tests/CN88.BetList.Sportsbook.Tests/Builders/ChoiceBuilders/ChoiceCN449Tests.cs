namespace CN88.BetList.Sportsbook.Tests.Builders.ChoiceBuilders
{
    using CN88.BetList.Core.Builders.ChoiceBuilders;
    using Fanex.BetList.Core.Entities;
    using NSubstitute;
    using NUnit.Framework;

    public class ChoiceCN449Tests
    {
        [Test]
        public void ChoiceCN449_Always_InheritChoiceCN3()
        {
            // Assert
            Assert.AreEqual("ChoiceCN3", typeof(ChoiceCN449).BaseType.Name);
        }

        [TestCase(null, "")]
        [TestCase("12o", "Home/Away & Over")]
        [TestCase("3xu", "3xu")]
        [TestCase("3xe", "3xe")]
        public void BuildChoiceName_Always_RenderCorrectText(string betTeam, string expectedText)
        {
            // Arrange
            var ticket = Substitute.For<ITicket>();
            ticket.BetTeam = betTeam;
            var ticketHelper = Substitute.For<ITicketHelper>();
            var choice = new ChoiceCN449();

            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.AreEqual(expectedText, choice.Template.BetChoice.ChoiceName.choiceName);
        }
    }
}
