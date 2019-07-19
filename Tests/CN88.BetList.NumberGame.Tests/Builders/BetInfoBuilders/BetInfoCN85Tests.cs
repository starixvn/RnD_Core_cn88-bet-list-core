namespace CN88.BetList.NumberGame.Tests.Builders.BetInfoBuilders
{
    using System;
    using CN88.BetList.Core.Builders.BetInfoBuilders;
    using Fanex.BetList.Core.Entities;
    using NSubstitute;
    using NUnit.Framework;

    public class BetInfoCN85Tests
    {
        private BetInfoCN85 betInfo;
        private ITicket ticket;
        private ITicketHelper ticketHelper;

        [SetUp]
        public void Setup()
        {
            betInfo = new BetInfoCN85();
            ticket = Substitute.For<ITicket>();
            ticketHelper = Substitute.For<ITicketHelper>();
        }

        [Test]
        public void BetInfoCN85_Always_InheritBetInfoCN81()
        {
            // Assert
            Assert.AreEqual("BetInfoCN81", typeof(BetInfoCN85).BaseType.Name);
        }

        [TestCase(false, "FT. BetTypeName")]
        [TestCase(true, "Next&nbsp;BetTypeName")]
        public void BuildBetTypeName_NonliveTicket_RenderCorrectText(bool isLive, string expectedText)
        {
            // Arrange 
            ticket.IsLive = isLive;
            ticketHelper.GetBetTypeNameById(Arg.Any<object>(), Arg.Any<object>())
                .Returns("BetTypeName");
            Func<object, string> getOddsTypeName = (_) => "OddsTypeName";

            // Act
            betInfo.Render(ticket, ticketHelper, getOddsTypeName);

            // Assert
            Assert.AreEqual(expectedText, betInfo.Template.BetType.BetTypeName.betTypeName);
        }
    }
}
