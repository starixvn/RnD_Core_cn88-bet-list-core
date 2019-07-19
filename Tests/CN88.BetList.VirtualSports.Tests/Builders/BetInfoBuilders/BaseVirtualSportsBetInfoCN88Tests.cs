namespace CN88.BetList.VirtualSports.Tests.Builders.BetInfoBuilders
{
    using System;
    using CN88.BetList.Core.Builders.BetInfoBuilders;
    using Fanex.BetList.Core.Entities;
    using NSubstitute;
    using NUnit.Framework;

    public class BaseVirtualSportsBetInfoCN88Tests
    {
        private BaseVirtualSportsBetInfoCN88 betInfo;
        private ITicket ticket;
        private ITicketHelper ticketHelper;

        [SetUp]
        public void Setup()
        {
            betInfo = new BaseVirtualSportsBetInfoCN88();
            ticket = Substitute.For<ITicket>();
            ticketHelper = Substitute.For<ITicketHelper>();
        }

        [Test]
        public void BaseVirtualSportsBetInfoCN88_Always_InheritBaseBetInfoCN88()
        {
            // Assert
            Assert.AreEqual("BaseBetInfoCN88", typeof(BaseVirtualSportsBetInfoCN88).BaseType.Name);
        }

        [Test]
        public void RenderBetTypeName_Always_ReturnCorrectText()
        {
            // Arrange 
            var expectedText = "BetTypeName";
            ticketHelper.GetBetTypeNameById(Arg.Any<object>(), Arg.Any<object>())
                .Returns(expectedText);

            // Act
            var actualValue = betInfo.RenderBetTypeName(ticket, ticketHelper);

            // Assert
            Assert.AreEqual(expectedText, actualValue);
        }

        [Test]
        public void GetBetTypeName_Always_ReturnCorrectText()
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
