namespace ExamenPGG.Business.Tests
{
    public class DiceTests
    {
        private IDice dice;

        [SetUp]
        public void Setup()
        {
            dice = new Dice();
        }

        [TestCase(1, 1, 6)]
        [TestCase(1, 1, 6)]
        [TestCase(1, 1, 6)]
        [TestCase(2, 2, 12)]
        [TestCase(2, 2, 12)]
        [TestCase(2, 2, 12)]
        [TestCase(3, 3, 18)]
        [TestCase(3, 3, 18)]
        [TestCase(3, 3, 18)]
        public void RollDice_InRangeTest(int rollAmount, int expectedRangeMin, int expectedRangeMax)
        {
            // Arrange

            // Act
            int result = dice.RollDice(rollAmount);

            // Assert
            Assert.That(result, Is.InRange(expectedRangeMin, expectedRangeMax));
        }
    }
}