namespace CN88.BetList.Sportsbook.Tests.Builders.ChoiceBuilders
{
    using CN88.BetList.Core.Builders.ChoiceBuilders;
    using Fanex.BetList.Core.Entities;
    using NSubstitute;
    using NUnit.Framework;

    public class ChoiceCN454Tests
    {
        [Test]
        public void ChoiceCN454_Always_InheritBaseChoiceCN88()
        {
            // Assert
            Assert.AreEqual("BaseChoiceCN88", typeof(ChoiceCN454).BaseType.Name);
        }

        [TestCase("NG", "No Goal")]
        [TestCase("12h", "Home/Away & Home")]
        [TestCase("x3a", "x3a")]
        [TestCase("12n", "12n")]
        [TestCase(null, "")]
        [TestCase("12 ", "12 ")]
        [TestCase("1  ", "1  ")]
        [TestCase(" 23", " 23")]
        [TestCase(" 2 ", " 2 ")]
        [TestCase(" 23", " 23")]
        [TestCase("1 3", "1 3")]
        [TestCase("   ", "   ")]
        public void BuildChoiceName_Always_RenderCorrectText(string betTeam, string expectedText)
        {
            // Arrange
            var ticket = Substitute.For<ITicket>();
            ticket.BetTeam = betTeam;
            var ticketHelper = Substitute.For<ITicketHelper>();
            var choice = new ChoiceCN454();

            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.AreEqual(expectedText, choice.Template.BetChoice.ChoiceName.choiceName);
        }
    }
}
