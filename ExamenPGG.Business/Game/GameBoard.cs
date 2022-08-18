using ExamenPGG.Business.Squares;

namespace ExamenPGG.Business.Game
{
    public class GameBoard : IGameBoard
    {
        private static GameBoard _instance;

        private GameBoard()
        {
            _squareFactory = new SquareFactory();
            FillBoard(63);
        }

        public static GameBoard GetInstance()
        {
            if (_instance == null)
            {
                _instance = new GameBoard();
            }

            return _instance;
        }

        public IList<ISquare> Squares { get; private set; } = new List<ISquare>();
        private ISquareFactory _squareFactory { get; set; }

        private IList<ISquare> FillBoard(int gameBoardLength)
        {
            for (int i = 0; i <= gameBoardLength; i++)
            {
                switch (i)
                {
                    case 0:
                        Squares.Add(_squareFactory.CreateSquare(i, SquareType.Start));
                        break;

                    case 42:
                        Squares.Add(_squareFactory.CreateSquare(i, SquareType.Maze));
                        break;

                    case 63:
                        Squares.Add(_squareFactory.CreateSquare(i, SquareType.Final));
                        break;

                    default:
                        Squares.Add(_squareFactory.CreateSquare(i, SquareType.Standard));
                        break;
                }
            }
            return Squares;
        }

        public ISquare GetSquare(int id)
        {
            return Squares[id];
        }
    }
}