namespace CN88.BetList.VirtualSports.Tests.Builders.ChoiceBuilders
{
    using CN88.BetList.Core.Builders.ChoiceBuilders;
    using Fanex.BetList.Core.Entities;
    using NSubstitute;
    using NUnit.Framework;

    public class ChoiceCN1224Tests
    {
        private ChoiceCN1224 choice;
        private ITicket ticket;
        private ITicketHelper ticketHelper;

        [SetUp]
        public void Setup()
        {
            ticket = Substitute.For<ITicket>();
            choice = new ChoiceCN1224();
            ticketHelper = Substitute.For<ITicketHelper>();
        }

        [Test]
        public void ChoiceCN1224_Always_InheritBaseVirtualSportsChoiceCN88()
        {
            // Assert
            Assert.AreEqual("BaseVirtualSportsChoiceCN88", typeof(ChoiceCN1224).BaseType.Name);
        }

        [Test]
        public void BuildBetChoice_Always_HideCorrectElements()
        {
            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.True(!choice.Template.BetChoiceMoreInfo.Visible
                && !choice.Template.BetChoice.ChoiceValue.Visible);
        }

        [TestCase(null, "")]
        [TestCase("", "")]
        [TestCase("a", "")]
        [TestCase("aaa", "")]
        [TestCase("1x", "Home<span class=\"underdog\"> or </span>Draw")]
        [TestCase("1a", "Home<span class=\"underdog\"> or </span>Away")]
        [TestCase("1h", "Home<span class=\"underdog\"> or </span>Away")]
        [TestCase("2x", "Away<span class=\"underdog\"> or </span>Draw")]
        [TestCase("2a", "Away<span class=\"underdog\"> or </span>Away")]
        [TestCase("2h", "Away<span class=\"underdog\"> or </span>Away")]
        [TestCase("3x", "Away<span class=\"underdog\"> or </span>Draw")]
        [TestCase("3a", "Away<span class=\"underdog\"> or </span>Away")]
        [TestCase("3h", "Away<span class=\"underdog\"> or </span>Away")]
        [TestCase("1X", "Home<span class=\"underdog\"> or </span>Draw")]
        [TestCase("1A", "Home<span class=\"underdog\"> or </span>Away")]
        [TestCase("1H", "Home<span class=\"underdog\"> or </span>Away")]
        [TestCase("2X", "Away<span class=\"underdog\"> or </span>Draw")]
        [TestCase("2A", "Away<span class=\"underdog\"> or </span>Away")]
        [TestCase("2H", "Away<span class=\"underdog\"> or </span>Away")]
        [TestCase("3X", "Away<span class=\"underdog\"> or </span>Draw")]
        [TestCase("3A", "Away<span class=\"underdog\"> or </span>Away")]
        [TestCase("3H", "Away<span class=\"underdog\"> or </span>Away")]
        public void BuildBetChoice_Always_RenderCorrectText(string betTeam, string expectedText)
        {
            // Arrange
            ticket.BetTeam = betTeam;

            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.AreEqual(expectedText, choice.Template.BetChoice.ChoiceName.choiceName);
        }
    }
}
