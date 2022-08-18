using ExamenPGG.Business.Squares;

namespace ExamenPGG.Business.GameObject
{
    public interface IGameBoard
    {
        IList<ISquare> Squares { get; }

        ISquare GetSquare(int id);
    }
}