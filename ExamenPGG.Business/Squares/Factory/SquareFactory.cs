using ExamenPGG.Business.Squares.Types;

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

                case SquareType.Maze:
                    return new Maze(id);

                case SquareType.Temp1:
                    return new Temp1(id);

                case SquareType.Temp2:
                    return new Temp2(id);

                case SquareType.Temp3:
                    return new Temp3(id);

                default:
                    throw new ArgumentOutOfRangeException($"No valid square type: {nameof(SquareType)}");
            }
        }
    }
}