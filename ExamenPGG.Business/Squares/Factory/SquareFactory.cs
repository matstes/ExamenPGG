namespace ExamenPGG.Business.Squares
{
    public class SquareFactory : ISquareFactory
    {
        public ISquare CreateSquare(int id, SquareType SquareType)
        {
            switch (SquareType)
            {
                case SquareType.Start:
                    return new StartSquare(id);

                case SquareType.Final:
                    return new FinalSquare(id);

                case SquareType.Standard:
                    return new StandardSquare(id);

                default:
                    throw new ArgumentOutOfRangeException($"No valid square type: {nameof(SquareType)}");
            }
        }
    }
}