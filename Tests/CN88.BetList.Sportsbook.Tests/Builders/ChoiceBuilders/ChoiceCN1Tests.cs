namespace CN88.BetList.Sportsbook.Tests.Builders.ChoiceBuilders
{
    using CN88.BetList.Core.Builders.ChoiceBuilders;
    using Fanex.BetList.Core.Entities;
    using Fanex.BetList.Core.Utils;
    using NSubstitute;
    using NUnit.Framework;

    public class ChoiceCN1Tests
    {
        private ChoiceCN1 choice;
        private ITicket ticket;
        private ITicketHelper ticketHelper;

        [SetUp]
        public void Setup()
        {
            const int homeId = 1;
            const int awayId = 2;

            ticket = Substitute.For<ITicket>();
            ticket.HomeId = homeId;
            ticket.AwayId = awayId;

            ticketHelper = Substitute.For<ITicketHelper>();
            ticketHelper.GetTeamNameById(Arg.Is<long>(i => i == homeId)).Returns("Home Name");
            ticketHelper.GetTeamNameById(Arg.Is<long>(i => i == awayId)).Returns("Away Name");

            choice = new ChoiceCN1();
        }

        [Test]
        public void ChoiceCN1_Always_InheritBaseChoiceCN88()
        {
            // Assert
            Assert.AreEqual("BaseChoiceCN88", typeof(ChoiceCN1).BaseType.Name);
        }

        [Test]
        public void BuildMatch_Always_HideCorrectElements()
        {
            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.True(!choice.Template.Match.VS.Visible &&
                !choice.Template.BetChoice.ChoiceValue.Visible);
        }

        [Test]
        public void BuildMatch_Always_ShowHandicap()
        {
            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.True(choice.Template.Match.Handicap.Visible);
        }

        [TestCase(0, 0, "0")]
        [TestCase(1, 0, "1")]
        [TestCase(1.25, 0, "1 / 1.5")]
        [TestCase(1.5, 0, "1.5")]
        [TestCase(1.75, 0, "1.5 / 2")]
        [TestCase(2, 0, "2")]
        [TestCase(1, 2, "2")]
        [TestCase(1, 2.25, "2 / 2.5")]
        [TestCase(1, 2.5, "2.5")]
        [TestCase(1, 2.75, "2.5 / 3")]
        [TestCase(1, 3, "3")]
        public void SetHandicap_Always_RenderCorrectText(decimal hdp1, decimal hdp2, string expectedText)
        {
            // Arrange
            ticket.Handicap1 = hdp1;
            ticket.Handicap2 = hdp2;

            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.AreEqual(expectedText, choice.Template.Match.Handicap.handicap);
        }

        [Test]
        public void RenderRTF_Always_ReturnCorrectValue()
        {
            // Arrange
            ticket.BetdaqId = 1;
            ticket.BetTypeId = 1;
            ticket.IsLive = true;
            var rtfHelper = new RTFHelper { RTFRenderer = new RtfTextRender() };

            // Act
            var actualResult = choice.RenderRTF(ticket, ticketHelper, null, rtfHelper);

            // Assert
            Assert.AreEqual("\n[1] vs [2]\nHome Name 0 Away Name (0-0)\nAway Name @ -", actualResult[0].ToString());
        }
    }
}
