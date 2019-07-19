namespace CN88.BetList.Lottery.Tests.Builders.ChoiceBuilders
{
    using System.Collections.Generic;
    using CN88.BetList.Core.Builders.ChoiceBuilders;
    using Fanex.BetList.Core.Entities;
    using Fanex.BetList.Core.Utils;
    using NSubstitute;
    using NUnit.Framework;

    public class ChoiceCN1037Tests
    {
        private ChoiceCN1037 choice;
        private ITicket ticket;
        private ITicketHelper ticketHelper;

        [SetUp]
        public void Setup()
        {
            ticket = Substitute.For<ITicket>();
            choice = new ChoiceCN1037();
            ticketHelper = Substitute.For<ITicketHelper>();
        }

        [Test]
        public void ChoiceCN1037_Always_InheritChoiceCN1031()
        {
            // Assert
            Assert.AreEqual("ChoiceCN1031", typeof(ChoiceCN1037).BaseType.Name);
        }

        [TestCase("betChoice=1,101;")]
        [TestCase("betChoice=1,102;")]
        [TestCase("betChoice=1,103;")]
        [TestCase("betChoice=1,104;")]
        [TestCase("betChoice=1,105;")]
        [TestCase("betChoice=1,106;")]
        public void BuildBetChoice_ChoiceIdFrom101To106_HideOdds(string transDesc)
        {
            // Arrange
            ticket.TransDesc = transDesc;

            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.True(!choice.Template.BetChoice.BetChoiceSplitChar.Visible &&
                !choice.Template.BetChoice.Odds.Visible);
        }

        [TestCase("betChoice=1,100;")]
        [TestCase("betChoice=1,107;")]
        [TestCase("betChoice=1,a;")]
        public void BuildBetChoice_ChoiceIdNotFrom101To106_HideOdds(string transDesc)
        {
            // Arrange
            ticket.TransDesc = transDesc;

            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.True(choice.Template.BetChoice.BetChoiceSplitChar.Visible &&
                choice.Template.BetChoice.Odds.Visible);
        }

        [TestCase("betChoice=1,101;", " [1]\n")]
        [TestCase("betChoice=1,102;", " [1]\n")]
        [TestCase("betChoice=1,103;", " [1]\n")]
        [TestCase("betChoice=1,104;", " [1]\n")]
        [TestCase("betChoice=1,105;", " [1]\n")]
        [TestCase("betChoice=1,106;", " [1]\n")]
        [TestCase("betChoice=1,100;", " [1]\n @ 1")]
        [TestCase("betChoice=1,107;", " [1]\n @ 1")]
        [TestCase("betChoice=1,a;", " [1]\n @ 1")]
        public void RenderRTF_Always_ReturnCorrectValue(string transDesc, string expectedText)
        {
            // Arrange
            var ticketData = new List<ITicketData>();
            var rtfHelper = new RTFHelper { RTFRenderer = new RtfTextRender() };
            ticket.TransDesc = transDesc;
            ticket.Odds = 1;

            // Act
            var actualResult = choice.RenderRTF(ticket, ticketHelper, ticketData, rtfHelper)[0].ToString();

            // Assert
            Assert.AreEqual(expectedText, actualResult);
        }
    }
}
