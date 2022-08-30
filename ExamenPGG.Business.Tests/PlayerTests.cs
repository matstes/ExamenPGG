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
            player = new Player(false);
            notABoringBoard = GameBoard.GetInstance();
        }

        [TestCase(5, 5, 10)]
        [TestCase(45, 5, 50)]
        [TestCase(37, 1, 38)]
        [TestCase(11, 24, 35)]
        [TestCase(58, 8, 60)]
        [TestCase(55, 8, 63)]
        public void WhenMovePlayerIsCalled_MoveForwardByMoveAmount(int startPosition, int moveAmount, int expectedResult)
        {
            // Arrange
            player.MoveToSquare(startPosition);

            // Act
            ISquare square = player.MovePlayer(moveAmount);

            // Assert
            Assert.That(square.ID, Is.EqualTo(expectedResult));
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
            Assert.That(player.PreviousSquare, Is.InstanceOf<Cobweb>());
        }

        [Test]
        public void MovePlayerPastFinish_WhenStopsOnBat_SendBackPlayer()
        {
            //arrange
            player.MoveToSquare(61);
            player.LastThrow = 6;

            //act
            ISquare square = player.MovePlayer(6);

            //Assert
            Assert.That(square.ID, Is.EqualTo(53));
            Assert.That(player.CurrentSquare.ID, Is.EqualTo(53));
            Assert.That(player.PreviousSquare, Is.InstanceOf<Standard>());
        }
    }
}