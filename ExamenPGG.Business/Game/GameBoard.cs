using ExamenPGG.Business.Squares;

namespace ExamenPGG.Business.Game
{
    public class GameBoard : IGameBoard
    {
        public IList<ISquare> Squares { get; private set; } = new List<ISquare>();
        private  ISquareFactory _squareFactory { get; set; }

        public GameBoard(ISquareFactory squareFactory)
        {
            _squareFactory = squareFactory;
            FillBoard(64);
        }

        private IList<ISquare> FillBoard(int gameBoardLength = 16)
        {
            for (int i = 0; i <= gameBoardLength; i++)
            {
                if (i == 0)
                {
                    Squares.Add(_squareFactory.CreateSquare(i, SquareType.Start));
                }
                else if (i == gameBoardLength)
                {
                    Squares.Add(_squareFactory.CreateSquare(i, SquareType.Final));
                }
                else
                {
                    Squares.Add(_squareFactory.CreateSquare(i, SquareType.Standard));
                }
                //TODO Add new squares and enum here - Switch
            }
            return Squares;
        }

        public ISquare GetSquare(int id)
        {
            return Squares[id];
        }
    }
}