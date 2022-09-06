using ExamenPGG.Business.Squares;

namespace ExamenPGG.Business.Factory
{
    public interface ISquareFactory
    {
        ISquare CreateSquare(int ID, SquareType SquareType);
    }
}