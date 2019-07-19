namespace CN88.BetList.Sportsbook.Tests.Builders.ChoiceBuilders
{
    using CN88.BetList.Core.Builders.ChoiceBuilders;
    using Fanex.BetList.Core.Entities;
    using NSubstitute;
    using NUnit.Framework;

    public class ChoiceCN408Tests
    {
        [Test]
        public void ChoiceCN408_Always_InheritBaseChoiceCN88()
        {
            // Assert
            Assert.AreEqual("BaseChoiceCN88", typeof(ChoiceCN408).BaseType.Name);
        }

        [TestCase("h1", "Home to Win by 1 Goal")]
        [TestCase("h2", "Home to Win by 2 Goals")]
        [TestCase("h3", "Home to Win by 3+ Goals")]
        [TestCase("d", "Any Score Draw (Exclude 0-0)")]
        [TestCase("a1", "Away to Win by 1 Goal")]
        [TestCase("a2", "Away to Win by 2 Goals")]
        [TestCase("a3", "Away to Win by 3+ Goals")]
        [TestCase("ng", "No Goal")]
        [TestCase("", "")]
        public void BuildChoiceName_Always_RenderCorrectText(string betTeam, string expectedText)
        {
            // Arrange
            var ticket = Substitute.For<ITicket>();
            ticket.BetTeam = betTeam;
            var ticketHelper = Substitute.For<ITicketHelper>();
            var choice = new ChoiceCN408();

            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.AreEqual(expectedText, choice.Template.BetChoice.ChoiceName.choiceName);
        }
    }
}
