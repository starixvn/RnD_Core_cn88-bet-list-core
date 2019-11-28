namespace CN88.BetList.Sportsbook.Tests.Builders.ChoiceBuilders
{
    using CN88.BetList.Core.Builders.ChoiceBuilders;
    using Fanex.BetList.Core.Entities;
    using NSubstitute;
    using NUnit.Framework;

    public class ChoiceCN397Tests
    {
        [Test]
        public void ChoiceCN397_Always_InheritBaseChoiceCN88()
        {
            // Assert
            Assert.AreEqual("BaseChoiceCN88", typeof(ChoiceCN397).BaseType.Name);
        }

        [TestCase("h1", "Home to Win by 1 Goal")]
        [TestCase("H1", "Home to Win by 1 Goal")]
        [TestCase("h2", "Home to Win by 2 Goals")]
        [TestCase("H2", "Home to Win by 2 Goals")]
        [TestCase("h3+", "Home to Win by 3+ Goals")]
        [TestCase("H3+", "Home to Win by 3+ Goals")]
        [TestCase("a1", "Away to Win by 1 Goal")]
        [TestCase("A1", "Away to Win by 1 Goal")]
        [TestCase("a2", "Away to Win by 2 Goals")]
        [TestCase("A2", "Away to Win by 2 Goals")]
        [TestCase("a3+", "Away to Win by 3+ Goals")]
        [TestCase("A3+", "Away to Win by 3+ Goals")]
        [TestCase("d", "Any Score Draw (Exclude 0-0)")]
        [TestCase("D", "Any Score Draw (Exclude 0-0)")]
        [TestCase("ng", "No Goal")]
        [TestCase("NG", "No Goal")]
        [TestCase("", "")]
        public void BuildChoiceName_Always_RenderCorrectText(string betTeam, string expectedText)
        {
            // Arrange
            var ticket = Substitute.For<ITicket>();
            ticket.BetTeam = betTeam;
            var ticketHelper = Substitute.For<ITicketHelper>();
            var choice = new ChoiceCN397();

            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.AreEqual(expectedText, choice.Template.BetChoice.ChoiceName.choiceName);
        }
    }
}
