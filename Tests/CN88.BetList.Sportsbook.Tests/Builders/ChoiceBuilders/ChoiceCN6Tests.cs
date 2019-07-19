namespace CN88.BetList.Sportsbook.Tests.Builders.ChoiceBuilders
{
    using CN88.BetList.Core.Builders.ChoiceBuilders;
    using Fanex.BetList.Core.Entities;
    using NSubstitute;
    using NUnit.Framework;

    public class ChoiceCN6Tests
    {
        [Test]
        public void ChoiceCN6_Always_InheritBaseChoiceCN88()
        {
            // Assert
            Assert.AreEqual("BaseChoiceCN88", typeof(ChoiceCN6).BaseType.Name);
        }

        [TestCase("4-over", "&nbsp;4+")]
        [TestCase("4&over", "&nbsp;4+")]
        [TestCase("7-over", "&nbsp;7+")]
        [TestCase("7&over", "&nbsp;7+")]
        [TestCase("4-Over", "&nbsp;4+")]
        [TestCase("4&Over", "&nbsp;4+")]
        [TestCase("7-Over", "&nbsp;7+")]
        [TestCase("7&Over", "&nbsp;7+")]
        [TestCase("BetTeam", "&nbsp;betteam")]
        public void BuildChoiceName_Always_RenderCorrectText(string betTeam, string expectedText)
        {
            // Arrange
            var ticket = Substitute.For<ITicket>();
            ticket.BetTeam = betTeam;
            var ticketHelper = Substitute.For<ITicketHelper>();
            var choice = new ChoiceCN6();

            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.AreEqual(expectedText, choice.Template.BetChoice.ChoiceName.choiceName);
        }
    }
}
