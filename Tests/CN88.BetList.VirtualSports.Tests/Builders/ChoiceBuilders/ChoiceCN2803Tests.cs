namespace CN88.BetList.VirtualSports.Tests.Builders.ChoiceBuilders
{
    using CN88.BetList.Core.Builders.ChoiceBuilders;
    using Fanex.BetList.Core.Entities;
    using NSubstitute;
    using NUnit.Framework;

    public class ChoiceCN2803Tests
    {
        private ChoiceCN2803 choice;
        private ITicket ticket;
        private ITicketHelper ticketHelper;

        [SetUp]
        public void Setup()
        {
            ticket = Substitute.For<ITicket>();
            choice = new ChoiceCN2803();
            ticketHelper = Substitute.For<ITicketHelper>();
        }

        [Test]
        public void ChoiceCN2803_Always_InheritChoiceCN2703()
        {
            // Assert
            Assert.AreEqual("ChoiceCN2703", typeof(ChoiceCN2803).BaseType.Name);
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
