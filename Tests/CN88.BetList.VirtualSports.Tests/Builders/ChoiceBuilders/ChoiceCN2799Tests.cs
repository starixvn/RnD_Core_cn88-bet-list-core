namespace CN88.BetList.VirtualSports.Tests.Builders.ChoiceBuilders
{
    using System.Collections.Generic;
    using CN88.BetList.Core.Builders.ChoiceBuilders;
    using Fanex.BetList.Core.Entities;
    using Fanex.BetList.Core.Utils;
    using NSubstitute;
    using NUnit.Framework;

    public class ChoiceCN2799Tests
    {
        private ChoiceCN2799 choice;
        private ITicket ticket;
        private ITicketHelper ticketHelper;

        [SetUp]
        public void Setup()
        {
            ticket = Substitute.For<ITicket>();
            ticketHelper = Substitute.For<ITicketHelper>();
            choice = new ChoiceCN2799();
        }

        [Test]
        public void ChoiceCN29_Always_InheritBaseChoiceCN88()
        {
            // Assert
            Assert.AreEqual("BaseVirtualSportsChoiceCN88", typeof(ChoiceCN2799).BaseType.Name);
        }

        [Test]
        public void BuildChoice_Always_HideCorrectElements()
        {
            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.True(!choice.Template.League.Visible &&
                !choice.Template.Match.Visible &&
                !choice.Template.MatchByTeamId.Visible &&
                !choice.Template.BetChoice.Visible &&
                !choice.Template.BetChoiceMoreInfo.Visible &&
                !choice.Template.MoreInfo.Visible &&
                !choice.Template.KickOffTime.Visible);
        }

        [TestCase(null, 0)]
        [TestCase(1, 0)]
        [TestCase(1, 1)]
        [TestCase(112, 0)]
        public void BuildOdds_NotShowOdds_RenderCorrectText(int? statusId, decimal masterOdds)
        {
            // Arrange
            ticket.StatusId = statusId;
            ticket.MasterOdds = masterOdds;

            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.AreEqual("-", choice.Template.BetChoice.Odds.odds);
        }

        [TestCase("Won")]
        [TestCase("Lose")]
        public void BuildOdds_ShowOdds_RenderCorrectText(string status)
        {
            // Arrange
            ticket.Status = status;
            ticket.StatusId = 112;
            ticket.MasterOdds = 1;

            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.AreEqual("1.0000", choice.Template.BetChoice.Odds.odds);
        }

        [Test]
        public void RenderRTF_Always_ReturnCorrectValue()
        {
            // Arrange
            ticketHelper.ShowSystemParlayDetail = true;
            ticketHelper.GetCombinationMPOfferNameList(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<decimal>(), Arg.Any<decimal>()).Returns(new List<string> { "Name 1" });
            ticket.Status = "Won";
            var rtfHelper = new RTFHelper { RTFRenderer = new RtfTextRender() };

            // Act
            var actualResult = choice.RenderRTF(ticket, ticketHelper, null, rtfHelper)[0].ToString();

            // Assert
            Assert.AreEqual("Name 1", actualResult);
        }

        [Test]
        public void BuildChoice_EmptyOfferName_RenderOfferNames()
        {
            // Arrange
            ticketHelper.GetCombinationMPOfferNameList(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<decimal>(), Arg.Any<decimal>()).Returns((IList<string>)null);

            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.AreEqual("", choice.Template.MixParlay.OfferNames.offerNames);
        }

        [Test]
        public void BuildChoice_HasOfferName_RenderCorrectOfferInfo()
        {
            // Arrange
            ticketHelper.GetCombinationMPOfferNameList(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<decimal>(), Arg.Any<decimal>()).Returns(new List<string> { "Name 1" });

            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.True(
                choice.Template.MixParlay.OfferNames.offerNamesId == "0-0" &&
                choice.Template.MixParlay.OfferNames.offerNames == "<div>Name 1</div>" &&
                choice.Template.MixParlay.SubTickets.subTicketsId == "0-0");
        }

        [TestCase("", "showParlaySubBetsCN88(0, 0, '', 0, 0, '', '', 0, this)")]
        [TestCase("Function", "Function")]
        public void BuildChoice_Always_RenderCorrectMixparlayFunction(
            string clientSystemParlaySubbetsDetailFunction,
            string expectedText)
        {
            // Arrange
            ticketHelper.ClientSystemParlaySubbetsDetailFunction = clientSystemParlaySubbetsDetailFunction;

            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.AreEqual(expectedText, choice.Template.MixParlay.mixparlayFunction);
        }

        [Test]
        public void BuildChoice_Always_RenderCorrectTitle()
        {
            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.AreEqual("Mix Parlay", choice.Template.MixParlay.mixParlayTitle);
        }
    }
}
