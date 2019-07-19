namespace CN88.BetList.Sportsbook.Tests.Builders.ChoiceBuilders
{
    using CN88.BetList.Core.Builders.ChoiceBuilders;
    using Fanex.BetList.Core.Entities;
    using NSubstitute;
    using NUnit.Framework;

    public class ChoiceCN418Tests
    {
        [Test]
        public void ChoiceCN418_Always_InheritChoiceCN3()
        {
            // Assert
            Assert.AreEqual("ChoiceCN3", typeof(ChoiceCN418).BaseType.Name);
        }

        [TestCase("yo", "Yes & Over")]
        [TestCase("yu", "Yes & Under")]
        [TestCase("no", "No & Over")]
        [TestCase("nu", "No & Under")]
        [TestCase("", "")]
        public void BuildChoiceName_Always_RenderCorrectText(string betTeam, string expectedText)
        {
            // Arrange
            var ticket = Substitute.For<ITicket>();
            ticket.BetTeam = betTeam;
            var ticketHelper = Substitute.For<ITicketHelper>();
            var choice = new ChoiceCN418();

            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.AreEqual(expectedText, choice.Template.BetChoice.ChoiceName.choiceName);
        }
    }
}
