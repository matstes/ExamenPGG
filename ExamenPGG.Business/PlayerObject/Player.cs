using ExamenPGG.Business.GameObject;
using ExamenPGG.Business.Squares;

namespace ExamenPGG.Business.PlayerObject
{
    public class Player : IPlayer
    {
        public string Name { get; set; }
        public string IconPath { get; set; }
        public ISquare PreviousSquare { get; set; }

        public ISquare CurrentSquare { get; private set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public int TurnAmount { get; set; }
        public int InActiveTurns { get; set; }
        public bool IsHuman { get; private set; }
        public int LastThrow { get; set; } = 0;

        private int direction = 1;

        private IGameBoard _gameBoard;

        public Player(string name,string iconPath, bool isHuman, IGameBoard gameBoard)
        {
            Name = name;
            IconPath = iconPath;
            IsHuman = isHuman;
            _gameBoard = gameBoard;
            CurrentSquare = _gameBoard.GetSquare(0);
        }

        public int Direction
        {
            get { return direction; }
            set
            {
                if (value <= -1)
                {
                    direction = -1;
                }
                else
                {
                    direction = 1;
                }
            }
        }

        private int destination;



        public ISquare MovePlayer(int moveAmount)
        {
            destination += moveAmount;
            if (destination > 63)
            {
                int squaresOverFinish = destination - 63;
                destination = 63 - squaresOverFinish;
                Direction = -1;
            }
            return HandlePlayer(destination);
        }

        public ISquare MoveToSquare(int squareID)
        {
            destination = squareID;
            return HandlePlayer(destination);
        }

        private ISquare GetSquare(int position)
        {
            var square = _gameBoard.GetSquare(position);

            return square;
        }

        private ISquare HandlePlayer(int destination)
        {
            PreviousSquare = CurrentSquare;
            CurrentSquare = GetSquare(destination);
            CurrentSquare.HandlePlayer(this);

            return CurrentSquare;
        }
    }
}