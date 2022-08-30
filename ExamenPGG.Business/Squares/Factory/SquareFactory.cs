namespace ExamenPGG.Business.Squares
{
    public class SquareFactory : ISquareFactory
    {
        public ISquare CreateSquare(int id, SquareType SquareType)
        {
            switch (SquareType)
            {
                case SquareType.Start:
                    return new Start(id);

                case SquareType.Final:
                    return new Final(id);

                case SquareType.Standard:
                    return new Standard(id);

                case SquareType.Cobweb:
                    return new Cobweb(id);

                case SquareType.Ladder:
                    return new Ladder(id);

                case SquareType.FallTrap:
                    return new FallTrap(id);

                case SquareType.Mystery:
                    return new Mystery(id);

                case SquareType.Bat:
                    return new Bat(id);

                default:
                    throw new ArgumentOutOfRangeException($"No valid square type: {nameof(SquareType)}");
            }
        }
    }
}