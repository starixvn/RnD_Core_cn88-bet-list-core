namespace CN88.BetList.VirtualSports.Tests.Builders.ChoiceBuilders
{
    using System.Collections.Generic;
    using CN88.BetList.Core.Builders.ChoiceBuilders;
    using Fanex.BetList.Core.Entities;
    using Fanex.BetList.Core.Utils;
    using NSubstitute;
    using NUnit.Framework;

    public class ChoiceCN1201Tests
    {
        private ChoiceCN1201 choice;
        private ITicket ticket;
        private ITicketHelper ticketHelper;

        [SetUp]
        public void Setup()
        {
            ticket = Substitute.For<ITicket>();
            choice = new ChoiceCN1201();
            ticketHelper = Substitute.For<ITicketHelper>();
        }

        [Test]
        public void ChoiceCN1201_Always_InheritBaseVirtualSportsChoiceCN88()
        {
            // Assert
            Assert.AreEqual("BaseVirtualSportsChoiceCN88", typeof(ChoiceCN1201).BaseType.Name);
        }

        [Test]
        public void BuildBetChoice_Always_HideCorrectElements()
        {
            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.True(!choice.Template.Match.VS.Visible
                && !choice.Template.BetChoiceMoreInfo.Visible
                && !choice.Template.BetChoice.ChoiceValue.Visible);
        }

        [Test]
        public void BuildBetChoice_Always_ShowHandicap()
        {
            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.True(choice.Template.Match.Handicap.Visible);
        }

        [TestCase(2, 1, "2")]
        [TestCase(0, 0, "0")]
        [TestCase(0, 1, "1")]
        [TestCase(0, 2, "2")]
        [TestCase(2.5, 1, "2.5")]
        [TestCase(2.25, 1, "2 / 2.5")]
        [TestCase(0, 1.5, "1.5")]
        [TestCase(0, 1.25, "1 / 1.5")]
        public void BuildBetChoice_Always_ShowHandicap(decimal hdp1, decimal hdp2, string expectedText)
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
            var ticketData = new List<ITicketData>();
            var rtfHelper = new RTFHelper { RTFRenderer = new RtfTextRender() };

            // Act
            var actualResult = choice.RenderRTF(ticket, ticketHelper, ticketData, rtfHelper)[0].ToString();

            // Assert
            Assert.AreEqual("\n 0  \n\n @ -", actualResult);
        }
    }
}
