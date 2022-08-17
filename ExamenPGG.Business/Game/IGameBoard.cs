using ExamenPGG.Business.Squares;

namespace ExamenPGG.Business.Game
{
    public interface IGameBoard
    {
        IList<ISquare> Squares { get; }

        ISquare GetSquare(int id);
    }
}