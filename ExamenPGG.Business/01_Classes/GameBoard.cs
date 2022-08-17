using ExamenPGG.Business._00_Interfaces;
using ExamenPGG.Business._03_Enums;

namespace ExamenPGG.Business._01_Classes
{
    public class GameBoard : IGameBoard
    {
        public List<ISquare> Squares { get; set; }
        public ISquareFactory SquareFactory { get; set; }

        public GameBoard(ISquareFactory squareFactory)
        {
            SquareFactory = squareFactory;
            Squares = new List<ISquare>();
        }

        public List<ISquare> FillBoard()
        {
            int gameBoardLength = 16;

            for (int i = 0; i <= gameBoardLength; i++)
            {
                if (i == 0)
                {
                    Squares.Add(SquareFactory.CreateSquare(i, SquareType.StartSquare));
                }
                else if (i == gameBoardLength)
                {
                    Squares.Add(SquareFactory.CreateSquare(i, SquareType.FinalSquare));
                }
                else 
                {
                    Squares.Add(SquareFactory.CreateSquare(i, SquareType.StandardSquare));
                }
            }
            return Squares;
        }
    }
}
