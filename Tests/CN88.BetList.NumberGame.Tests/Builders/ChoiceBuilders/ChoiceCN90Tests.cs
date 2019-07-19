namespace CN88.BetList.NumberGame.Tests.Builders.ChoiceBuilders
{
    using CN88.BetList.Core.Builders.ChoiceBuilders;
    using Fanex.BetList.Core.Entities;
    using NSubstitute;
    using NUnit.Framework;

    public class ChoiceCN90Tests
    {
        private ChoiceCN90 choice;
        private ITicket ticket;
        private ITicketHelper ticketHelper;

        [SetUp]
        public void Setup()
        {
            ticket = Substitute.For<ITicket>();
            ticketHelper = Substitute.For<ITicketHelper>();
            choice = new ChoiceCN90();
        }

        [Test]
        public void ChoiceCN90_Always_InheritBaseNumberGameChoiceCN88()
        {
            // Assert
            Assert.AreEqual("BaseNumberGameChoiceCN88", typeof(ChoiceCN90).BaseType.Name);
        }

        [Test]
        public void BuildChoiceName_Always_ChoiceValueIsNull()
        {
            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.IsNull(choice.Template.BetChoice.ChoiceValue);
        }

        [TestCase(1, "1", "1~5")]
        [TestCase(1, "2", "6~10")]
        [TestCase(1, "3", "11~15")]
        [TestCase(1, "4", "16~20")]
        [TestCase(1, "5", "21~25")]
        [TestCase(1, "6", "26~30")]
        [TestCase(1, "7", "31~35")]
        [TestCase(1, "8", "36~40")]
        [TestCase(1, "9", "41~45")]
        [TestCase(1, "10", "46~50")]
        [TestCase(1, "11", "51~55")]
        [TestCase(1, "12", "56~60")]
        [TestCase(1, "13", "61~65")]
        [TestCase(1, "14", "66~70")]
        [TestCase(1, "15", "71~75")]
        [TestCase(2, "1", "1~15")]
        [TestCase(2, "2", "16~30")]
        [TestCase(2, "3", "31~45")]
        [TestCase(2, "4", "46~60")]
        [TestCase(2, "5", "61~75")]
        [TestCase(3, "1", "1~25")]
        [TestCase(3, "2", "26~50")]
        [TestCase(3, "3", "51~75")]
        [TestCase(4, "1", "1,6,11,16,21,26,31,36,41,46,51,56,61,66,71")]
        [TestCase(4, "2", "2,7,12,17,22,27,32,37,42,47,52,57,62,67,72")]
        [TestCase(4, "3", "3,8,13,18,23,28,33,38,43,48,53,58,63,68,73")]
        [TestCase(4, "4", "4,9,14,19,24,29,34,39,44,49,54,59,64,69,74")]
        [TestCase(4, "5", "5,10,15,20,25,30,35,40,45,50,55,60,65,70,75")]
        [TestCase(5, "1", "1")]
        [TestCase(5, "2", "2")]
        [TestCase(5, "3", "3")]
        [TestCase(5, "4", "4")]
        [TestCase(5, "5", "5")]
        [TestCase(5, "6", "6")]
        [TestCase(5, "7", "7")]
        [TestCase(5, "8", "8")]
        [TestCase(5, "9", "9")]
        [TestCase(5, "10", "10")]
        [TestCase(5, "11", "11")]
        [TestCase(5, "12", "12")]
        [TestCase(5, "13", "13")]
        [TestCase(5, "14", "14")]
        [TestCase(5, "15", "15")]
        [TestCase(5, "16", "16")]
        [TestCase(5, "17", "17")]
        [TestCase(5, "18", "18")]
        [TestCase(5, "19", "19")]
        [TestCase(5, "20", "20")]
        [TestCase(5, "21", "21")]
        [TestCase(5, "22", "22")]
        [TestCase(5, "23", "23")]
        [TestCase(5, "24", "24")]
        [TestCase(5, "25", "25")]
        [TestCase(5, "26", "26")]
        [TestCase(5, "27", "27")]
        [TestCase(5, "28", "28")]
        [TestCase(5, "29", "29")]
        [TestCase(5, "30", "30")]
        [TestCase(5, "31", "31")]
        [TestCase(5, "32", "32")]
        [TestCase(5, "33", "33")]
        [TestCase(5, "34", "34")]
        [TestCase(5, "35", "35")]
        [TestCase(5, "36", "36")]
        [TestCase(5, "37", "37")]
        [TestCase(5, "38", "38")]
        [TestCase(5, "39", "39")]
        [TestCase(5, "40", "40")]
        [TestCase(5, "41", "41")]
        [TestCase(5, "42", "42")]
        [TestCase(5, "43", "43")]
        [TestCase(5, "44", "44")]
        [TestCase(5, "45", "45")]
        [TestCase(5, "46", "46")]
        [TestCase(5, "47", "47")]
        [TestCase(5, "48", "48")]
        [TestCase(5, "49", "49")]
        [TestCase(5, "50", "50")]
        [TestCase(5, "51", "51")]
        [TestCase(5, "52", "52")]
        [TestCase(5, "53", "53")]
        [TestCase(5, "54", "54")]
        [TestCase(5, "55", "55")]
        [TestCase(5, "56", "56")]
        [TestCase(5, "57", "57")]
        [TestCase(5, "58", "58")]
        [TestCase(5, "59", "59")]
        [TestCase(5, "60", "60")]
        [TestCase(5, "61", "61")]
        [TestCase(5, "62", "62")]
        [TestCase(5, "63", "63")]
        [TestCase(5, "64", "64")]
        [TestCase(5, "65", "65")]
        [TestCase(5, "66", "66")]
        [TestCase(5, "67", "67")]
        [TestCase(5, "68", "68")]
        [TestCase(5, "69", "69")]
        [TestCase(5, "70", "70")]
        [TestCase(5, "71", "71")]
        [TestCase(5, "72", "72")]
        [TestCase(5, "73", "73")]
        [TestCase(5, "74", "74")]
        [TestCase(5, "75", "75")]
        public void BuildChoiceName_Always_RenderCorrectText(
            int handicap1, string betTeam, string expectedText)
        {
            // Arrange
            ticket.Handicap1 = handicap1;
            ticket.BetTeam = betTeam;

            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.AreEqual(expectedText, choice.Template.BetChoice.ChoiceName.choiceName);
        }
    }
}
