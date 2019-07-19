namespace CN88.BetList.Core.Tests.Builders
{
    using System;
    using System.Collections.Generic;
    using CN88.BetList.Core.Builders;
    using Fanex.BetList.Core.Entities;
    using NSubstitute;
    using NUnit.Framework;

    public class BetListCN88HtmlBuilderTests
    {
        private BetListCN88HtmlBuilder builder;
        private ITicket ticket;
        private ITicketHelper ticketHelper;
        private List<ITicketData> ticketData;

        [SetUp]
        public void Setup()
        {
            builder = new BetListCN88HtmlBuilder();
            ticket = Substitute.For<ITicket>();
            ticketHelper = Substitute.For<ITicketHelper>();
            ticketData = new List<ITicketData>();
        }

        [Test]
        public void GetBetList_Always_ReturnsCorrectValue()
        {
            // Arrange 
            var expectedValue = "TestHtml";
            builder.Append(expectedValue);

            // Act
            var actualValue = builder.GetBetList();

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void Append_Always_AppendCorrectValue()
        {
            // Arrange 
            var expectedValue = "AppendedHtml";

            // Act
            builder.Append(expectedValue);
            var actualValue = builder.GetBetList();

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestCase(false, "<div class='cn88-bet-item'><div class=\"cn88-teamid\"><span class=\"cn88-home-team-id\">[0]</span><span> vs </span><span class=\"cn88-away-team-id\">[0]</span></div><div class=\"cn88-match\"><span class=\"cn88-home-team-name\"></span><span> v. </span><span class=\"cn88-away-team-name\"></span></div><div class=\"cn88-bet-choice\"><span class=\"cn88-choice-name\"></span><span> @ </span><span class=\"cn88-odds\">-</span></div></div>")]
        [TestCase(true, "<div class='cn88-bet-item'><div class=\"cn88-league\"><span class=\"cn88-league-name\"></span></div><div class=\"cn88-teamid\"><span class=\"cn88-home-team-id\">[0]</span><span> vs </span><span class=\"cn88-away-team-id\">[0]</span></div><div class=\"cn88-match\"><span class=\"cn88-home-team-name\"></span><span> v. </span><span class=\"cn88-away-team-name\"></span></div><div class=\"cn88-bet-choice\"><span class=\"cn88-choice-name\"></span><span> @ </span><span class=\"cn88-odds\">-</span></div></div>")]
        public void AddChoice_Always_AppendCorrectValue(bool showLeague, string expectedValue)
        {
            // Arrange 
            ticketHelper.ShowLeague = showLeague;

            // Act
            builder.AddChoice(ticket, ticketHelper, ticketData, "", "", false);
            var actualValue = builder.GetBetList();

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestCase(false, "<div class='cn88-bet-item'><div class=\"cn88-teamid\"><span class=\"cn88-home-team-id\">[0]</span><span> vs </span><span class=\"cn88-away-team-id\">[0]</span></div><div class=\"cn88-match\"><span class=\"cn88-home-team-name\"></span><span> v. </span><span class=\"cn88-away-team-name\"></span></div><div class=\"cn88-bet-choice\"><span class=\"cn88-choice-name\"></span><span> @ </span><span class=\"cn88-odds\">-</span></div></div>")]
        [TestCase(true, "<div class='cn88-bet-item'><div class=\"cn88-league\"><span class=\"cn88-league-name\"></span></div><div class=\"cn88-teamid\"><span class=\"cn88-home-team-id\">[0]</span><span> vs </span><span class=\"cn88-away-team-id\">[0]</span></div><div class=\"cn88-match\"><span class=\"cn88-home-team-name\"></span><span> v. </span><span class=\"cn88-away-team-name\"></span></div><div class=\"cn88-bet-choice\"><span class=\"cn88-choice-name\"></span><span> @ </span><span class=\"cn88-odds\">-</span></div></div>")]
        public void BuildChoice_Always_ReturnCorrectValue(bool showLeague, string expectedValue)
        {
            // Arrange 
            ticketHelper.ShowLeague = showLeague;

            // Act
            var actualValue = builder.BuildChoice(ticket, ticketHelper, ticketData);

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestCase(false)]
        [TestCase(true)]
        public void BuildChoiceBlock_Always_ReturnCorrectValue(bool showLeague)
        {
            // Arrange 
            var expectedValue = "<div class='cn88-bet-item'><div class=\"cn88-league\"><span class=\"cn88-league-name\"></span></div><div class=\"cn88-teamid\"><span class=\"cn88-home-team-id\">[0]</span><span> vs </span><span class=\"cn88-away-team-id\">[0]</span></div><div class=\"cn88-match\"><span class=\"cn88-home-team-name\"></span><span> v. </span><span class=\"cn88-away-team-name\"></span></div><div class=\"cn88-bet-choice\"><span class=\"cn88-choice-name\"></span><span> @ </span><span class=\"cn88-odds\">-</span></div></div>";
            ticketHelper.ShowLeague = showLeague;

            // Act
            var actualValue = builder.BuildChoiceBlock(ticket, ticketHelper, ticketData).ToString();

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void AddBetInfo_Always_AppendCorrectValue()
        {
            // Arrange 
            var expectedValue = "<div class='cn88-bet-info-item'><div class=\"cn88-oddstype-betid\"><span class=\"cn88-odds-type\">OddsTypeName </span><span class=\"cn88-bet-id\">0</span></div><div class=\"cn88-sporttype\"><span class=\"cn88-sporttype-name\"></span></div><div class=\"cn88-sporttype\"><span class=\"cn88-bettype-name\"></span></div></div>";
            Func<object, string> getOddsTypeName = (_) => "OddsTypeName";

            // Act
            builder.AddBetInfo(ticket, ticketHelper, getOddsTypeName, "", "");
            var actualValue = builder.GetBetList();

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void BuildBetInfo_Always_ReturnCorrectValue()
        {
            // Arrange 
            var expectedValue = "<div class='cn88-bet-info-item'><div class=\"cn88-oddstype-betid\"><span class=\"cn88-odds-type\">OddsTypeName </span><span class=\"cn88-bet-id\">0</span></div><div class=\"cn88-sporttype\"><span class=\"cn88-sporttype-name\"></span></div><div class=\"cn88-sporttype\"><span class=\"cn88-bettype-name\"></span></div></div>";
            Func<object, string> getOddsTypeName = (_) => "OddsTypeName";

            // Act
            var actualValue = builder.BuildBetInfo(ticket, ticketHelper, getOddsTypeName);

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void BuildBetInfoBlock_Always_ReturnCorrectValue()
        {
            // Arrange 
            var expectedValue = "<div class='cn88-bet-info-item'><div class=\"cn88-oddstype-betid\"><span class=\"cn88-odds-type\">OddsTypeName </span><span class=\"cn88-bet-id\">0</span></div><div class=\"cn88-sporttype\"><span class=\"cn88-sporttype-name\"></span></div><div class=\"cn88-sporttype\"><span class=\"cn88-bettype-name\"></span></div></div>";
            Func<object, string> getOddsTypeName = (_) => "OddsTypeName";

            // Act
            var actualValue = builder.BuildBetInfoBlock(ticket, ticketHelper, getOddsTypeName).ToString();

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }
    }
}
