using ExamenPGG.Business.Game;
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
            Assert.That(squares[0], Is.InstanceOf<StartSquare>());
            Assert.That(squares[24], Is.InstanceOf<StandardSquare>());
            Assert.That(squares[42], Is.InstanceOf<MazeSquare>());
            Assert.That(squares[63], Is.InstanceOf<FinalSquare>());
        }
    }
}