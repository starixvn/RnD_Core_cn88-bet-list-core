namespace CN88.BetList.Sportsbook.Tests.Builders.ChoiceBuilders
{
    using CN88.BetList.Core.Builders.ChoiceBuilders;
    using Fanex.BetList.Core.Entities;
    using NSubstitute;
    using NUnit.Framework;

    public class ChoiceCN601Tests
    {
        [Test]
        public void ChoiceCN601_Always_InheritBaseChoiceCN88()
        {
            // Assert
            Assert.AreEqual("BaseChoiceCN88", typeof(ChoiceCN601).BaseType.Name);
        }

        [TestCase("h1-2", "Home")]
        [TestCase("h3-6", "Home")]
        [TestCase("h7-9", "Home")]
        [TestCase("h10-13", "Home")]
        [TestCase("h14-16", "Home")]
        [TestCase("h17-20", "Home")]
        [TestCase("h21+", "Home")]
        [TestCase("H1-2", "Home")]
        [TestCase("H3-6", "Home")]
        [TestCase("H7-9", "Home")]
        [TestCase("H10-13", "Home")]
        [TestCase("H14-16", "Home")]
        [TestCase("H17-20", "Home")]
        [TestCase("H21+", "Home")]
        [TestCase("a1-2", "Away")]
        [TestCase("a3-6", "Away")]
        [TestCase("a7-9", "Away")]
        [TestCase("a10-13", "Away")]
        [TestCase("a14-16", "Away")]
        [TestCase("a17-20", "Away")]
        [TestCase("a21+", "Away")]
        [TestCase("A1-2", "Away")]
        [TestCase("A3-6", "Away")]
        [TestCase("A7-9", "Away")]
        [TestCase("A10-13", "Away")]
        [TestCase("A14-16", "Away")]
        [TestCase("A17-20", "Away")]
        [TestCase("A21+", "Away")]
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

            var choice = new ChoiceCN601();

            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.AreEqual(expectedText, choice.Template.BetChoice.ChoiceName.choiceName);
        }
    }
}
