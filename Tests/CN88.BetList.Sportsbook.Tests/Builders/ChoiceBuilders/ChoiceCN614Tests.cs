namespace CN88.BetList.Sportsbook.Tests.Builders.ChoiceBuilders
{
    using CN88.BetList.Core.Builders.ChoiceBuilders;
    using Fanex.BetList.Core.Entities;
    using NSubstitute;
    using NUnit.Framework;

    public class ChoiceCN614Tests
    {
        [Test]
        public void ChoiceCN614_Always_InheritChoiceCN601()
        {
            // Assert
            Assert.AreEqual("ChoiceCN601", typeof(ChoiceCN614).BaseType.Name);
        }

        [TestCase("h1-4", "h1-4")]
        [TestCase("h5-8", "h5-8")]
        [TestCase("h9+", "h9+")]
        [TestCase("H1-4", "H1-4")]
        [TestCase("H5-8", "H5-8")]
        [TestCase("H9+", "H9+")]
        [TestCase("d", "d")]
        [TestCase("D", "D")]
        [TestCase("a1-4", "a1-4")]
        [TestCase("a5-8", "a5-8")]
        [TestCase("a9+", "a9+")]
        [TestCase("A1-4", "A1-4")]
        [TestCase("A5-8", "A5-8")]
        [TestCase("A9+", "A9+")]
        [TestCase("b", "")]
        public void BuildChoiceName_Always_RenderCorrectText(string betTeam, string expectedText)
        {
            // Arrange
            var ticket = Substitute.For<ITicket>();
            ticket.BetTeam = betTeam;
            var ticketHelper = Substitute.For<ITicketHelper>();
            ticketHelper.GetResourceData("WMBasketball", Arg.Any<string>()).Returns(betTeam);

            var choice = new ChoiceCN614();

            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.AreEqual(expectedText, choice.Template.BetChoice.ChoiceName.choiceName);
        }
    }
}
