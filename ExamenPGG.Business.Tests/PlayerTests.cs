using ExamenPGG.Business.GameObject;
using ExamenPGG.Business.PlayerObject;
using ExamenPGG.Business.Squares;

namespace ExamenPGG.Business.Tests
{
    public class PlayerTests
    {
        private IPlayer player;
        private IGameBoard notABoringBoard;

        [SetUp]
        public void Setup()
        {
            player = new Player();
            notABoringBoard = GameBoard.GetInstance();
        }

        [TestCase(5, 5, 10)]
        [TestCase(45, 5, 50)]
        [TestCase(37, 1, 38)]
        [TestCase(11, 24, 35)]
        [TestCase(58, 8, 60)]
        public void MovePlayerAsync_EqualTest(int startPosition, int moveAmount, int expectedResult)
        {
            // Arrange
            player.MoveToSquare(startPosition);

            // Act
            ISquare square = player.MovePlayer(moveAmount);

            // Assert
            Assert.That(square.ID, Is.EqualTo(expectedResult));
        }

        [TestCase(5, 12, 7)]
        [TestCase(45, 7, 46)]
        [TestCase(37, 1, 42)]
        [TestCase(58, 8, 66)]
        [TestCase(54, 10, 64)]
        public void MovePlayerAsync_NotEqualTest(int startPosition, int moveAmount, int expectedResult)
        {
            // Arrange
            player.MoveToSquare(startPosition);

            // Act
            ISquare square = player.MovePlayer(moveAmount);

            // Assert
            Assert.That(square.ID, Is.Not.EqualTo(expectedResult));
        }

        [Test]
        public void MovePlayer_WhenPlayerStopsOnMaze_SendBackPlayer3Squares()
        {
            //arrange
            player.MoveToSquare(38);

            //act
            ISquare square = player.MovePlayer(4);

            //Assert
            Assert.That(square.ID, Is.EqualTo(39));
            Assert.That(player.CurrentSquare.ID, Is.EqualTo(39));
            Assert.That(player.PreviousSquare, Is.InstanceOf<MazeSquare>());
        }
    }
}