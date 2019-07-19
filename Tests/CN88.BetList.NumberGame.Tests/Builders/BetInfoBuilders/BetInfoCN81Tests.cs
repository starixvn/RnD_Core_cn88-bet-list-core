namespace CN88.BetList.NumberGame.Tests.Builders.BetInfoBuilders
{
    using System;
    using CN88.BetList.Core.Builders.BetInfoBuilders;
    using Fanex.BetList.Core.Entities;
    using NSubstitute;
    using NUnit.Framework;

    public class BetInfoCN81Tests
    {
        private BetInfoCN81 betInfo;
        private ITicket ticket;
        private ITicketHelper ticketHelper;

        [SetUp]
        public void Setup()
        {
            betInfo = new BetInfoCN81();
            ticket = Substitute.For<ITicket>();
            ticketHelper = Substitute.For<ITicketHelper>();
        }

        [Test]
        public void BetInfoCN81_Always_InheritBaseBetInfoCN88()
        {
            // Assert
            Assert.AreEqual("BaseBetInfoCN88", typeof(BetInfoCN81).BaseType.Name);
        }

        [Test]
        public void BuildBetTypeName_Always_RenderCorrectText()
        {
            // Arrange 
            var expectedText = "BetTypeName";
            ticketHelper.GetBetTypeNameById(Arg.Any<object>(), Arg.Any<object>())
                .Returns(expectedText);
            Func<object, string> getOddsTypeName = (_) => "OddsTypeName";

            // Act
            betInfo.Render(ticket, ticketHelper, getOddsTypeName);

            // Assert
            Assert.AreEqual(expectedText, betInfo.Template.BetType.BetTypeName.betTypeName);
        }
    }
}
