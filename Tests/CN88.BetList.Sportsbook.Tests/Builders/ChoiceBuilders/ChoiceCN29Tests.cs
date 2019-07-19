namespace CN88.BetList.Sportsbook.Tests.Builders.ChoiceBuilders
{
    using System.Collections.Generic;
    using CN88.BetList.Core.Builders.ChoiceBuilders;
    using Fanex.BetList.Core.Entities;
    using Fanex.BetList.Core.Utils;
    using NSubstitute;
    using NUnit.Framework;

    public class ChoiceCN29Tests
    {
        private ChoiceCN29 choice;
        private ITicket ticket;
        private ITicketHelper ticketHelper;

        [SetUp]
        public void Setup()
        {
            ticket = Substitute.For<ITicket>();
            ticketHelper = Substitute.For<ITicketHelper>();
            choice = new ChoiceCN29();
        }

        [Test]
        public void ChoiceCN29_Always_InheritBaseChoiceCN88()
        {
            // Assert
            Assert.AreEqual("BaseChoiceCN88", typeof(ChoiceCN29).BaseType.Name);
        }

        [Test]
        public void BuildChoice_Always_HideMatchInfo()
        {
            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.True(!choice.Template.League.Visible &&
                !choice.Template.Match.Visible &&
                !choice.Template.MatchByTeamId.Visible &&
                !choice.Template.BetChoice.Visible &&
                !choice.Template.BetChoiceMoreInfo.Visible &&
                !choice.Template.KickOffTime.Visible);
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

        [Test]
        public void BuildChoice_NotShowDetailLink_HideDetailLink()
        {
            // Arrange
            ticketHelper.ShowSystemParlayDetail = false;

            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.False(choice.Template.MoreInfo.Visible);
        }

        [Test]
        public void BuildChoice_NotAcceptedTicket_HideDetailLink()
        {
            // Arrange
            ticket.Status = "Refund";

            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.False(choice.Template.MoreInfo.Visible);
        }

        [TestCase("Running")]
        [TestCase("Won")]
        [TestCase("Lose")]
        [TestCase("Draw")]
        public void BuildChoice_ShowDetailLinkAndAcceptedTicket_ShowDetailLink(string status)
        {
            // Arrange
            ticketHelper.ShowSystemParlayDetail = true;
            ticket.Status = status;

            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.True(choice.Template.MoreInfo.Visible);
        }

        [TestCase("Function", "Function")]
        [TestCase(null, "showCombMPDetail('', '01/01/0001 00:00:00', 0, '', 0, '', this)")]
        [TestCase("", "showCombMPDetail('', '01/01/0001 00:00:00', 0, '', 0, '', this)")]
        [TestCase(" ", "showCombMPDetail('', '01/01/0001 00:00:00', 0, '', 0, '', this)")]
        [TestCase("  ", "showCombMPDetail('', '01/01/0001 00:00:00', 0, '', 0, '', this)")]
        public void BuildChoice_ShowDetailLinkAndAcceptedTicket_RenderCorrectMoreInfo(
            string clientDetailSystemParlayFunction,
            string expectedText)
        {
            // Arrange
            ticketHelper.ClientDetailSystemParlayFunction = clientDetailSystemParlayFunction;
            ticketHelper.ShowSystemParlayDetail = true;
            ticket.Status = "Won";

            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.AreEqual(expectedText, choice.Template.MoreInfo.moreInfoFunction);
        }

        [Test]
        public void RenderRTF_Always_ReturnCorrectValue()
        {
            // Arrange
            ticketHelper.ShowSystemParlayDetail = true;
            ticketHelper.GetCombinationMPOfferNameList(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<decimal>(), Arg.Any<decimal>()).Returns(new List<string> { "Name 1" });
            ticket.Status = "Won";
            var rtfHelper = new RTFHelper
            {
                RTFRenderer = new RtfTextRender()
            };

            // Act
            var actualResult = choice.RenderRTF(ticket, ticketHelper, null, rtfHelper)[0].ToString();

            // Assert
            Assert.AreEqual("Name 1", actualResult);
        }
    }
}
