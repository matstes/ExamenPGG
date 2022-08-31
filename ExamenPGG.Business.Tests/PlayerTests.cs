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
            // TODO FOR MICHIEL Fix these poor tests ;(
            player = new Player(false);
            notABoringBoard = GameBoard.GetInstance();
        }

        [TestCase(4, 7, 11)]
        public void WhenMovePlayerIsCalled_MoveForwardByMoveAmount(int startPosition, int moveAmount, int expectedResult)
        {
            // Arrange
            player.MoveToSquare(startPosition);
            player.LastThrow = moveAmount;

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
            Assert.That(square.ID, Is.EqualTo(42));
            Assert.That(player.CurrentSquare.ID, Is.EqualTo(42));
            Assert.That(player.PreviousSquare, Is.InstanceOf<Cobweb>());
            Assert.That(player.CurrentSquare, Is.InstanceOf<FallTrap>());
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

        [Test]
        public void WhenThorwing9FromStart_MoveToFinish()
        {
            //arrange
            player.LastThrow = 9;

            //act
            ISquare square = player.MovePlayer(9);

            //Assert
            Assert.That(square.ID, Is.EqualTo(63));
            Assert.That(player.CurrentSquare.ID, Is.EqualTo(63));
            Assert.That(player.PreviousSquare, Is.InstanceOf<Bat>());
            Assert.That(player.CurrentSquare, Is.InstanceOf<Final>());
        }

        [Test]
        public void MovePlayer_WhenStopsOnCobweb_SkipTurn()
        {
            //arrange

            //act
            ISquare square = player.MovePlayer(3);

            //Assert
            Assert.That(square.ID, Is.EqualTo(3));
            Assert.That(player.CurrentSquare.ID, Is.EqualTo(3));
            Assert.That(player.PreviousSquare, Is.InstanceOf<Start>());
            Assert.That(player.CurrentSquare, Is.InstanceOf<Cobweb>());
            Assert.That(player.InActiveTurns, Is.EqualTo(1));
        }
    }
}