using ExamenPGG.Business.GameObject;
using ExamenPGG.Business.Squares;

namespace ExamenPGG.Business.Tests
{
    public class GameBoardTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void FillBoard_ShouldReturnSquareList()
        {
            //Arrange
            GameBoard gameBoard = GameBoard.GetInstance();

            //Act
            IList<ISquare> squares = gameBoard.Squares;

            //Assert
            Assert.That(squares[0], Is.InstanceOf<Start>());
            Assert.That(squares[24], Is.InstanceOf<Standard>());
            Assert.That(squares[17], Is.InstanceOf<Mystery>());
            Assert.That(squares[34], Is.InstanceOf<Ladder>());
            Assert.That(squares[42], Is.InstanceOf<FallTrap>());
            Assert.That(squares[63], Is.InstanceOf<Final>());
        }
    }
}