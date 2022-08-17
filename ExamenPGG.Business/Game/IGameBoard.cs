using ExamenPGG.Business.Squares;

namespace ExamenPGG.Business.Game
{
    public interface IGameBoard
    {
        List<ISquare> Squares { get; set; }

        ISquareFactory SquareFactory { get; set; }

        List<ISquare> FillBoard();
    }
}