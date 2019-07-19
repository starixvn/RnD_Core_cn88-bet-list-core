namespace CN88.BetList.Sportsbook.Tests.Builders.ChoiceBuilders
{
    using CN88.BetList.Core.Builders.ChoiceBuilders;
    using Fanex.BetList.Core.Entities;
    using NSubstitute;
    using NUnit.Framework;

    public class ChoiceCN602Tests
    {
        [Test]
        public void ChoiceCN602_Always_InheritChoiceCN601()
        {
            // Assert
            Assert.AreEqual("ChoiceCN601", typeof(ChoiceCN602).BaseType.Name);
        }

        [TestCase("h1-5", "Home")]
        [TestCase("h6-10", "Home")]
        [TestCase("h11-15", "Home")]
        [TestCase("h16-20", "Home")]
        [TestCase("h21-25", "Home")]
        [TestCase("h26+", "Home")]
        [TestCase("H1-5", "Home")]
        [TestCase("H6-10", "Home")]
        [TestCase("H11-15", "Home")]
        [TestCase("H16-20", "Home")]
        [TestCase("H21-25", "Home")]
        [TestCase("H26+", "Home")]
        [TestCase("a1-5", "Away")]
        [TestCase("a6-10", "Away")]
        [TestCase("a11-15", "Away")]
        [TestCase("a16-20", "Away")]
        [TestCase("a21-25", "Away")]
        [TestCase("a26+", "Away")]
        [TestCase("A1-5", "Away")]
        [TestCase("A6-10", "Away")]
        [TestCase("A11-15", "Away")]
        [TestCase("A16-20", "Away")]
        [TestCase("A21-25", "Away")]
        [TestCase("A26+", "Away")]
        [TestCase("", "")]
        public void BuildChoiceName_Always_RenderCorrectText(string betTeam, string expectedText)
        {
            // Arrange
            var ticket = Substitute.For<ITicket>();
            ticket.BetTeam = betTeam;
            ticket.HomeId = 1;
            ticket.AwayId = 2;

            var ticketHelper = Substitute.For<ITicketHelper>();
            ticketHelper.GetResourceData("WMBasketball", Arg.Any<string>()).Returns(betTeam.ToLowerInvariant().Contains("h") ? "Home" : "Away");

            var choice = new ChoiceCN602();

            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.AreEqual(expectedText, choice.Template.BetChoice.ChoiceName.choiceName);
        }
    }
}
