using ExamenPGG.Business._00_Interfaces;
using ExamenPGG.Business._01_Classes._01_Squares;
using ExamenPGG.Business._03_Enums;

namespace ExamenPGG.Business._01_Classes
{
    public class SquareFactory : ISquareFactory
    {
        public ISquare CreateSquare(int id, SquareType SquareType)
        {
            switch (SquareType)
            {

                case SquareType.StartSquare:
                    return new StartSquare { ID = id };

                case SquareType.FinalSquare:
                    return new FinalSquare { ID = id };

                case SquareType.StandardSquare:
                    return new StandardSquare { ID = id };

                default:
                    throw new ArgumentOutOfRangeException($"No valid square type: {nameof(SquareType)}");

            }
        }
    }
}
