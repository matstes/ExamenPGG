using ExamenPGG.Business.Squares;

namespace ExamenPGG.Business.Game
{
    public class GameBoard : IGameBoard
    {
        private static GameBoard _instance;

        private GameBoard()
        {
            _squareFactory = new SquareFactory();
            FillBoard(64);
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

        private IList<ISquare> FillBoard(int gameBoardLength = 16)
        {
            for (int i = 0; i < gameBoardLength; i++)
            {
                if (i == 0)
                {
                    Squares.Add(_squareFactory.CreateSquare(i, SquareType.Start));
                }
                else if (i == gameBoardLength - 1)
                {
                    Squares.Add(_squareFactory.CreateSquare(i, SquareType.Final));
                }
                else if (i == 42)
                {
                    Squares.Add(_squareFactory.CreateSquare(i, SquareType.Maze));
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