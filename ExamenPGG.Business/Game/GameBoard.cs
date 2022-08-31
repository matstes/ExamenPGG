using ExamenPGG.Business.Squares;

namespace ExamenPGG.Business.GameObject
{
    public class GameBoard : IGameBoard
    {
        private static GameBoard _instance;

        private IDice MysteryDice;

        private GameBoard()
        {
            MysteryDice = new Dice();
            _squareFactory = new SquareFactory(MysteryDice);
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

        private IList<ISquare> FillBoard(int gameBoardLength)
        {
            SquareType[] gameBoardSquareTypes = new SquareType[gameBoardLength];

            // Fill array with standard squares
            for (int i = 0; i < gameBoardLength; i++)
            {
                gameBoardSquareTypes[i] = SquareType.Standard;
            }

            // Start and Final square
            gameBoardSquareTypes[0] = SquareType.Start;
            gameBoardSquareTypes[gameBoardLength-1] = SquareType.Final;

            // Other Squares
            int[] batSquares = {5,9,18,27,36,45,54,59};
            int[] cobWebSquares = { 3, 38, 57 };
            int[] mysterySquares = { 10, 17, 44 };
            int[] ladderSquares = { 21, 26, 34, 53 };
            int[] fallTrapSquares = {42,51,60};

            foreach (int i in batSquares)
            {
                gameBoardSquareTypes[i] = SquareType.Bat;
            }
            foreach (int i in cobWebSquares)
            {
                gameBoardSquareTypes[i] = SquareType.Cobweb;
            }
            foreach (int i in mysterySquares)
            {
                gameBoardSquareTypes[i] = SquareType.Mystery;
            }
            foreach (int i in ladderSquares )
            {
                gameBoardSquareTypes[i] = SquareType.Ladder;
            }
            foreach (int i in fallTrapSquares)
            {
                gameBoardSquareTypes[i] = SquareType.FallTrap;
            }

            //Get Squares from Factory
            for (int i = 0; i < gameBoardSquareTypes.Length; i++)
            {
                Squares.Add(_squareFactory.CreateSquare(i, gameBoardSquareTypes[i]));
            }

            return Squares;
        }

        public ISquare GetSquare(int id)
        {
            return Squares[id];
        }
    }
}