namespace CN88.BetList.VirtualSports.Tests.Builders.ChoiceBuilders
{
    using CN88.BetList.Core.Builders.ChoiceBuilders;
    using CN88.BetList.Core.Templates;
    using Fanex.BetList.Core.Entities;
    using NSubstitute;
    using NUnit.Framework;

    public class CN88VirtualSportsChoiceUtilsTests
    {
        [Test]
        public void ParseKickOffTime_IncorrectShowTime_ReturnTicketShowTime()
        {
            // Arrange
            var ticket = Substitute.For<ITicket>();
            ticket.ShowTime = "ShowTime";

            // Act
            var actualValue = CN88VirtualSportsChoiceUtils.ParseKickOffTime(ticket);

            // Assert
            Assert.AreEqual("ShowTime", actualValue);
        }

        [Test]
        public void ParseKickOffTime_CorrectShowTime_ReturnFormattedTicketShowTime()
        {
            // Arrange
            var ticket = Substitute.For<ITicket>();
            ticket.ShowTime = "2019-08-02 1:12:20 pm";

            // Act
            var actualValue = CN88VirtualSportsChoiceUtils.ParseKickOffTime(ticket);

            // Assert
            Assert.AreEqual("2019-08-02 13:12", actualValue);
        }

        [TestCase(null, "Empty")]
        [TestCase("", "Empty")]
        [TestCase("a=\"1\"", "Empty")]
        [TestCase("m=\"1\"", "Match code: 1")]
        public void ParseMatchInfo_Always_ReturnFormattedTicketShowTime(string transDesc, string expectedText)
        {
            // Arrange
            var ticket = Substitute.For<ITicket>();
            ticket.ShowTime = "2019-08-02 1:12:20 pm";
            var ticketHelper = Substitute.For<ITicketHelper>();
            ticketHelper.GetBetRadarMatchCodeFormat(Arg.Is<string>(s => s == "")).Returns("Empty");
            ticketHelper.GetBetRadarMatchCodeFormat(Arg.Is<string>(s => s == "1")).Returns("Match code: 1");

            // Act
            var actualValue = CN88VirtualSportsChoiceUtils.ParseMatchInfo(transDesc, ticketHelper);

            // Assert
            Assert.AreEqual(expectedText, actualValue);
        }

        [Test]
        public void AppendMatchOrRoundInfo_Always_AppendInfoToMatch()
        {
            // Arrange
            var ticket = Substitute.For<ITicket>();
            ticket.ShowTime = "2019-08-02 1:12:20 pm";
            var template = new ChoiceCN88_Template();
            var expectetText = "<div class=\"cn88-match\"><span class=\"cn88-home-team-name\">{homeTeam}</span><span> v. </span><span class=\"cn88-handicap\"> {handicap} </span><span class=\"cn88-away-team-name\">{awayTeam}</span><span class=\"cn88-live-score\"> {liveScore} </span></div><div class=\"match\">MatchRoundInfo</div>";

            // Act
            CN88VirtualSportsChoiceUtils.AppendMatchOrRoundInfo(template, "MatchRoundInfo");

            // Assert
            Assert.AreEqual(expectetText, template.Match.ToString());
        }

        [TestCase(null, "")]
        [TestCase("", "")]
        [TestCase("a=\"1\"", "")]
        [TestCase("s=\"1\"", "1")]
        public void ParseExcludingScoresInfo_Always_ReturnFormattedTicketShowTime(string transDesc, string expectedText)
        {
            // Act
            var actualValue = CN88VirtualSportsChoiceUtils.ParseExcludingScoresInfo(transDesc);

            // Assert
            Assert.AreEqual(expectedText, actualValue);
        }
    }
}
