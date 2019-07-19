namespace CN88.BetList.VirtualSports.Tests.Builders.ChoiceBuilders
{
    using System.Collections.Generic;
    using CN88.BetList.Core.Builders.ChoiceBuilders;
    using Fanex.BetList.Core.Entities;
    using Fanex.BetList.Core.Utils;
    using NSubstitute;
    using NUnit.Framework;

    public class BaseVirtualSportsChoiceCN88Tests
    {
        private BaseVirtualSportsChoiceCN88 choice;
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

            choice = new BaseVirtualSportsChoiceCN88();
            ticketHelper = Substitute.For<ITicketHelper>();
            ticketHelper.GetTeamNameById(Arg.Is<long>(i => i == homeId)).Returns("Home Name");
            ticketHelper.GetTeamNameById(Arg.Is<long>(i => i == awayId)).Returns("Away Name");

            rtfHelper = new RTFHelper { RTFRenderer = new RtfTextRender() };
        }

        [Test]
        public void BaseVirtualSportsChoiceCN88_Always_InheritBaseChoiceCN88()
        {
            // Assert
            Assert.AreEqual("BaseChoiceCN88", typeof(BaseVirtualSportsChoiceCN88).BaseType.Name);
        }

        [Test]
        public void BuildKickOffTime_Always_ShowKickOffTime()
        {
            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.True(choice.Template.KickOffTime.Visible);
        }

        [Test]
        public void BuildKickOffTime_Always_RenderCorrectText()
        {
            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.AreEqual("", choice.Template.KickOffTime.kickOffTime);
        }

        [Test]
        public void BuildKickOffTimeRtf_Always_ReturnCorrectValue()
        {
            // Arrange
            var ticketData = new List<ITicketData>();

            // Act
            var actualResult = choice.RenderRTF(ticket, ticketHelper, ticketData, rtfHelper)[0].ToString();

            // Assert
            Assert.AreEqual("\nHome Name v. Away Name \n\nAway Name @ -", actualResult);
        }

        [Test]
        public void BuildMatch_Always_HideHandicap()
        {
            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.False(choice.Template.Match.Handicap.Visible);
        }

        [TestCase(0, 0, "Home Name")]
        [TestCase(1, 0, "Home Name")]
        [TestCase(2, 1, "Home Name")]
        [TestCase(1, 2, "Away Name")]
        public void BuildMatch_Always_RenderCorrectHomeTeam(decimal hdp1, decimal hdp2, string expectedText)
        {
            // Arrange 
            ticket.Handicap1 = hdp1;
            ticket.Handicap2 = hdp2;

            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.AreEqual(expectedText, choice.Template.Match.homeTeam);
        }

        [TestCase(0, 0, "Away Name")]
        [TestCase(1, 0, "Away Name")]
        [TestCase(2, 1, "Away Name")]
        [TestCase(1, 2, "Home Name")]
        public void BuildMatch_Always_RenderCorrectAwayTeam(decimal hdp1, decimal hdp2, string expectedText)
        {
            // Arrange 
            ticket.Handicap1 = hdp1;
            ticket.Handicap2 = hdp2;

            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.AreEqual(expectedText, choice.Template.Match.awayTeam);
        }

        [TestCase(false)]
        [TestCase(true)]
        public void BuildScore_Always_LiveScoreDependToIsLive(bool isLive)
        {
            // Arrange
            ticket.IsLive = isLive;

            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.AreEqual(isLive, choice.Template.Match.LiveScore.Visible);
        }

        [TestCase(false, "{liveScore}")]
        [TestCase(true, "(1-2)")]
        public void BuildScore_Always_LiveScoreDependToIsLive(bool isLive, string expectedText)
        {
            // Arrange
            ticket.LiveHomeScore = 1;
            ticket.LiveAwayScore = 2;
            ticket.IsLive = isLive;

            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.AreEqual(expectedText, choice.Template.Match.LiveScore.liveScore);
        }

        [Test]
        public void BuildMatchRtf_Always_ReturnCorrectValue()
        {
            // Arrange
            var ticketData = new List<ITicketData>();
            ticket.LiveHomeScore = 1;
            ticket.LiveAwayScore = 2;
            ticket.IsLive = true;

            // Act
            var actualResult = choice.RenderRTF(ticket, ticketHelper, ticketData, rtfHelper)[0].ToString();

            // Assert
            Assert.AreEqual("\nHome Name v. Away Name (1-2)\n\nAway Name @ -", actualResult);
        }
    }
}
