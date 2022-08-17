namespace ExamenPGG.Business.Squares
{
    public interface ISquareFactory
    {
        ISquare CreateSquare(int ID, SquareType SquareType);
    }
}