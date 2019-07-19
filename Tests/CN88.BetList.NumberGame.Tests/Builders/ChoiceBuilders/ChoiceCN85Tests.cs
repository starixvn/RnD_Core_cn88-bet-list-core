namespace CN88.BetList.NumberGame.Tests.Builders.ChoiceBuilders
{
    using CN88.BetList.Core.Builders.ChoiceBuilders;
    using Fanex.BetList.Core.Entities;
    using NSubstitute;
    using NUnit.Framework;

    public class ChoiceCN85Tests
    {
        [Test]
        public void ChoiceCN85_Always_InheritChoiceCN81()
        {
            // Assert
            Assert.AreEqual("ChoiceCN81", typeof(ChoiceCN85).BaseType.Name);
        }

        [TestCase("h", "Over <span style='color:#555555;font-weight: bold;'>37.5</span>")]
        [TestCase("H", "Over <span style='color:#555555;font-weight: bold;'>37.5</span>")]
        [TestCase("a", "Under <span style='color:#555555;font-weight: bold;'>37.5</span>")]
        [TestCase("A", "Under <span style='color:#555555;font-weight: bold;'>37.5</span>")]
        [TestCase("", "Under <span style='color:#555555;font-weight: bold;'>37.5</span>")]
        public void BuildChoiceName_Always_RenderCorrectText(string betTeam, string expectedText)
        {
            // Arrange
            var ticket = Substitute.For<ITicket>();
            ticket.BetTeam = betTeam;
            var ticketHelper = Substitute.For<ITicketHelper>();
            var choice = new ChoiceCN85();

            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.AreEqual(expectedText, choice.Template.BetChoice.ChoiceName.choiceName);
        }

        [Test]
        public void ChoiceCN85_Always_HideChoiceValue()
        {
            // Arrange
            var ticket = Substitute.For<ITicket>();
            var ticketHelper = Substitute.For<ITicketHelper>();
            var choice = new ChoiceCN85();

            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.False(choice.Template.BetChoice.ChoiceValue.Visible);
        }
    }
}
