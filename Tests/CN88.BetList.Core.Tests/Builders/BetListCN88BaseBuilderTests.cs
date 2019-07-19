namespace CN88.BetList.Core.Tests.Builders
{
    using CN88.BetList.Core.Builders;
    using NUnit.Framework;

    public class BetListCN88BaseBuilderTests
    {
        private BetListCN88BaseBuilder builder;

        [SetUp]
        public void Setup()
        {
            builder = new BetListCN88BaseBuilder();
        }

        [TestCase(1, "BaseChoiceCN88")]
        public void CreateChoiceBuilder_Always_ReturnsCorrectChoiceBuilder(int betType, string expectedTypeName)
        {
            // Act
            var actualValue = builder.CreateChoiceBuilder(betType);

            // Assert
            Assert.AreEqual(expectedTypeName, actualValue.GetType().Name);
        }
    }
}
