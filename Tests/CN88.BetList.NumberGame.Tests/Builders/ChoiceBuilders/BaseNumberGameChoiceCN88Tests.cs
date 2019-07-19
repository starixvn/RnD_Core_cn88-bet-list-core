namespace CN88.BetList.NumberGame.Tests.Builders.ChoiceBuilders
{
    using System.Collections.Generic;
    using CN88.BetList.Core.Builders.ChoiceBuilders;
    using Fanex.BetList.Core.Entities;
    using Fanex.BetList.Core.Utils;
    using NSubstitute;
    using NUnit.Framework;

    public class BaseNumberGameChoiceCN88Tests
    {
        private BaseNumberGameChoiceCN88 choice;
        private ITicket ticket;
        private ITicketHelper ticketHelper;
        private RTFHelper rtfHelper;

        [SetUp]
        public void Setup()
        {
            const int homeId = 1;
            const int awayId = 2;

            ticket = Substitute.For<ITicket>();
            ticket.HomeId = homeId;
            ticket.AwayId = awayId;

            choice = new BaseNumberGameChoiceCN88();
            ticketHelper = Substitute.For<ITicketHelper>();
            ticketHelper.GetTeamNameById(Arg.Is<long>(i => i == homeId)).Returns("Home Name");
            ticketHelper.GetTeamNameById(Arg.Is<long>(i => i == awayId)).Returns("Away Name");

            rtfHelper = new RTFHelper { RTFRenderer = new RtfTextRender() };
        }

        [Test]
        public void BaseNumberGameChoiceCN88_Always_InheritBaseChoiceCN88()
        {
            // Assert
            Assert.AreEqual("BaseChoiceCN88", typeof(BaseNumberGameChoiceCN88).BaseType.Name);
        }

        [Test]
        public void BuildMatch_NonLive_HideLiveScore()
        {
            // Arrange
            ticket.IsLive = false;

            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.False(choice.Template.Match.LiveScore.Visible);
        }

        [Test]
        public void BuildMatch_Live_ShowLiveScore()
        {
            // Arrange
            ticket.IsLive = true;

            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.True(choice.Template.Match.LiveScore.Visible);
        }

        [Test]
        public void BuildMatch_Live_RenderCorrectLiveScore()
        {
            // Arrange
            ticket.IsLive = true;
            ticket.BetId = 12;

            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.AreEqual("(12)", choice.Template.Match.LiveScore.liveScore);
        }

        [TestCase(false, "\nNumber Game No \n{choiceName} @ -")]
        [TestCase(true, "\nNumber Game No  (12)\n{choiceName} @ -")]
        public void BuildMatchRtf_Always_ReturnCorrectValue(bool isLive, string expectedText)
        {
            // Arrange
            var ticketData = new List<ITicketData>();
            ticket.LiveHomeScore = 1;
            ticket.LiveAwayScore = 2;
            ticket.IsLive = isLive;
            ticket.BetId = 12;

            // Act
            var actualResult = choice.RenderRTF(ticket, ticketHelper, ticketData, rtfHelper)[0].ToString();

            // Assert
            Assert.AreEqual(expectedText, actualResult);
        }
    }
}
