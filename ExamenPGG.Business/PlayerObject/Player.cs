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
        private int direction;
        public int LastThrow { get; set; }

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



        public Player(bool isHuman)
        {
            IsHuman = isHuman;
            CurrentSquare = GameBoard.GetInstance().GetSquare(0);
        }

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
            var square = GameBoard.GetInstance().GetSquare(position);

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