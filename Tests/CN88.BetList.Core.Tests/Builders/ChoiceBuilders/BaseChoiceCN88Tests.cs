namespace CN88.BetList.Core.Tests.Builders.ChoiceBuilders
{
    using System.Collections.Generic;
    using CN88.BetList.Core.Builders.ChoiceBuilders;
    using Fanex.BetList.Core.Entities;
    using Fanex.BetList.Core.Utils;
    using NSubstitute;
    using NUnit.Framework;

    public class BaseChoiceCN88Tests
    {
        private BaseChoiceCN88 _choice;
        private ITicket _ticket;
        private ITicketHelper _ticketHelper;
        private List<ITicketData> _ticketData;

        [SetUp]
        public void Setup()
        {
            const int homeId = 1;
            const int awayId = 2;

            _choice = new BaseChoiceCN88();
            _ticket = Substitute.For<ITicket>();
            _ticket.HomeId = homeId;
            _ticket.AwayId = awayId;

            _ticketHelper = Substitute.For<ITicketHelper>();
            _ticketHelper.GetLeagueNameById(Arg.Any<int>()).Returns("LeagueName");
            _ticketHelper.GetTeamNameById(Arg.Is<long>(i => i == homeId)).Returns("Home Name");
            _ticketHelper.GetTeamNameById(Arg.Is<long>(i => i == awayId)).Returns("Away Name");

            _ticketData = new List<ITicketData>();
        }

        [Test]
        public void Render_Always_HideUnusedBlocks()
        {
            // Act
            _choice.Render(_ticket, _ticketHelper, _ticketData);

            // Assert
            Assert.True(!_choice.Template.MixParlay.Visible && !_choice.Template.MoreInfo.Visible);
        }

        [TestCase(null, 0, "-")]
        [TestCase("", 0, "-")]
        [TestCase("81", 0, "-")]
        [TestCase("81", 0, "-")]
        [TestCase("81", 1, "1")]
        [TestCase("81", -1, "<font color='#B50000'>-1</font>")]
        public void Render_Always_BuildOdds(string oddsType, decimal odds, string expectedText)
        {
            // Arrange
            _ticket.OddsType = oddsType;
            _ticket.Odds = odds;

            // Act
            _choice.Render(_ticket, _ticketHelper, _ticketData);

            // Assert
            Assert.AreEqual(expectedText, _choice.Template.BetChoice.Odds.odds);
        }

        [Test]
        public void Render_Always_BuildLeague()
        {
            // Act
            _choice.Render(_ticket, _ticketHelper, _ticketData);

            // Assert
            Assert.AreEqual("LeagueName", _choice.Template.League.LeagueName.leagueName);
        }

        [TestCase(false)]
        [TestCase(true)]
        public void Render_Always_ShowHideLiveScore(bool isLive)
        {
            // Arrange
            _ticket.IsLive = isLive;

            // Act
            _choice.Render(_ticket, _ticketHelper, _ticketData);

            // Assert
            Assert.AreEqual(isLive, _choice.Template.Match.LiveScore.Visible);
        }

        [TestCase(0)]
        [TestCase(100)]
        [TestCase(1)]
        public void Render_NotShowLiveText_ShowCorrectLiveScore(int sportTypeId)
        {
            // Arrange
            _ticket.IsLive = true;
            _ticket.SportTypeId = sportTypeId;
            _ticket.LiveHomeScore = 1;
            _ticket.LiveAwayScore = 2;

            // Act
            _choice.Render(_ticket, _ticketHelper, _ticketData);

            // Assert
            Assert.AreEqual("(1-2)", _choice.Template.Match.LiveScore.liveScore);
        }

        [TestCase("<p16 in=\"1\" />", "", "<span class=\"cn88-live-text\">[In-Play]</span>")]
        [TestCase("<p16 in=\"0\" />", "", "<span class=\"cn88-live-text\">[Live]</span>")]
        [TestCase("<p16 out=\"1\" />", "", "<span class=\"cn88-live-text\">[Live]</span>")]
        [TestCase("<p16 out=\"1\" />", "<p16 in=\"1\" />", "<span class=\"cn88-live-text\">[In-Play]</span>")]
        [TestCase("<p16 out=\"1\" />", "<p16 out=\"1\" />", "<span class=\"cn88-live-text\">[Live]</span>")]
        public void Render_ESports_ShowCorrectLiveScore(string extraInfo, string transDesc, string expectedText)
        {
            // Arrange
            _ticket.IsLive = true;
            _ticket.SportTypeId = 43;
            _ticket.LiveHomeScore = 1;
            _ticket.LiveAwayScore = 2;
            _ticket.ExtraInfo = extraInfo;
            _ticket.TransDesc = transDesc;

            // Act
            _choice.Render(_ticket, _ticketHelper, _ticketData);

            // Assert
            Assert.AreEqual(expectedText, _choice.Template.Match.LiveScore.liveScore);
        }

        [Test]
        public void Render_NotESports_ShowCorrectLiveScore()
        {
            // Arrange
            _ticket.IsLive = true;
            _ticket.SportTypeId = 42;

            // Act
            _choice.Render(_ticket, _ticketHelper, _ticketData);

            // Assert
            Assert.False(_choice.Template.Match.LiveScore.Visible);
        }

        [Test]
        public void Render_Always_HideBetChoiceMoreInfo()
        {
            // Act
            _choice.Render(_ticket, _ticketHelper, _ticketData);

            // Assert
            Assert.True(!_choice.Template.BetChoiceMoreInfo.Visible
                && !_choice.Template.BetChoice.ChoiceValue.Visible);
        }

        [TestCase(null, "Away Name")]
        [TestCase("h", "Home Name")]
        [TestCase("H", "Home Name")]
        [TestCase("a", "Away Name")]
        [TestCase("A", "Away Name")]
        public void Render_Always_ShowCorrectTeamName(string betTeam, string expectedChoiceName)
        {
            // Arrange 
            _ticket.BetTeam = betTeam;

            // Act
            _choice.Render(_ticket, _ticketHelper, _ticketData);

            // Assert
            Assert.AreEqual(expectedChoiceName, _choice.Template.BetChoice.ChoiceName.choiceName);
        }

        [Test]
        public void Render_Always_HideMatchHandicap()
        {
            // Act
            _choice.Render(_ticket, _ticketHelper, _ticketData);

            // Assert
            Assert.True(!_choice.Template.Match.Handicap.Visible);
        }

        [TestCase(false, "Home Name")]
        [TestCase(true, "Home Name (N)")]
        public void Render_Always_ShowCorrectMatchInfo(bool isNeutral, string expectedHomeName)
        {
            // Arrange
            _ticket.IsNeutral = isNeutral;

            // Act
            _choice.Render(_ticket, _ticketHelper, _ticketData);

            // Assert
            Assert.True(
                _choice.Template.Match.homeTeam == expectedHomeName &&
                _choice.Template.Match.awayTeam == "Away Name" &&
                _choice.Template.MatchByTeamId.homeTeamId == "[1]" &&
                _choice.Template.MatchByTeamId.awayTeamId == "[2]");
        }

        [Test]
        public void Render_Always_HideKickOffTime()
        {
            // Act
            _choice.Render(_ticket, _ticketHelper, _ticketData);

            // Assert
            Assert.True(!_choice.Template.KickOffTime.Visible);
        }

        [Test]
        public void RenderRTF_Always_ReturnCorrectValue()
        {
            // Arrange
            var ticketData = new List<ITicketData>();
            var rtfHelper = new RTFHelper { RTFRenderer = new RtfTextRender() };

            // Act
            var actualResult = _choice.RenderRTF(_ticket, _ticketHelper, ticketData, rtfHelper)[0].ToString();

            // Assert
            Assert.AreEqual("LeagueName\n[1] vs [2]\nHome Name v. Away Name \nAway Name @ -", actualResult);
        }
    }
}
