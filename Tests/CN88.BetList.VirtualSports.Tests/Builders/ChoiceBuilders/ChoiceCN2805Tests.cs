namespace CN88.BetList.VirtualSports.Tests.Builders.ChoiceBuilders
{
    using CN88.BetList.Core.Builders.ChoiceBuilders;
    using Fanex.BetList.Core.Entities;
    using NSubstitute;
    using NUnit.Framework;

    public class ChoiceCN2805Tests
    {
        private ChoiceCN2805 choice;
        private ITicket ticket;
        private ITicketHelper ticketHelper;

        [SetUp]
        public void Setup()
        {
            ticket = Substitute.For<ITicket>();
            choice = new ChoiceCN2805();
            ticketHelper = Substitute.For<ITicketHelper>();
            ticketHelper.GetResourceData("WMBasketball", "D").Returns("Option: {0}");
        }

        [Test]
        public void ChoiceCN2805_Always_InheritChoiceCN2705()
        {
            // Assert
            Assert.AreEqual("ChoiceCN2705", typeof(ChoiceCN2805).BaseType.Name);
        }

        [Test]
        public void BuildBetChoice_Always_HideLiveScore()
        {
            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.False(choice.Template.Match.LiveScore.Visible);
        }
    }
}
