using ExamenPGG.Business.GameObject;
using ExamenPGG.Business.Squares;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ExamenPGG.Business.PlayerObject
{
    public class Player : IPlayer, INotifyPropertyChanged
    {

        public string Name { get; set; }
        public string IconPath { get; set; }
        public ISquare PreviousSquare { get; set; }
        public ISquare CurrentSquare { get; private set; }
        public int TurnAmount { get; set; }
        public int InActiveTurns { get; set; }
        public bool IsHuman { get; private set; }
        public int LastThrow { get; set; } = 0;

        private int direction = 1;

        private IGameBoard _gameBoard;

        private int positionX = 0;
        public int PositionX 
        {
            get { return positionX; }
            set 
            {
                positionX = value;
                RaisePropertyChanged();
            }
        }
        private int positionY = 7;
        public int PositionY
        {
            get { return positionY; }
            set
            {
                positionY = value;
                RaisePropertyChanged();
            }
        }

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

        public event PropertyChangedEventHandler? PropertyChanged;

        private void RaisePropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
            var square = _gameBoard.GetSquare(position);
            return square;
        }

        private int GetYPosition()
        {

            double yY = 8.0 - (double)((CurrentSquare.ID + 1.0) / 8.0);
            return (int)yY;
            
        }
        private int GetXPosition(int yy)
        {
            int xX;
            int id = CurrentSquare.ID;
            if (yy % 2 == 0)
            {
                while (id >= 8)
                {
                    id -= 8;
                }
                xX = 7 - id;
            }
            else
            {
                while (id >= 8)
                {
                    id -= 8;
                }
                xX = id;
            }

            return xX;
        }

        private ISquare HandlePlayer(int destination)
        {
            PreviousSquare = CurrentSquare;
            CurrentSquare = GetSquare(destination);
            PositionY = GetYPosition();
            PositionX = GetXPosition(PositionY);
            CurrentSquare.HandlePlayer(this);

            return CurrentSquare;
        }
    }
}