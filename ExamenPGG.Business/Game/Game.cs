using ExamenPGG.Business.DiceObject;
using ExamenPGG.Business.Factory;
using ExamenPGG.Business.Logging;
using ExamenPGG.Business.PlayerObject;
using ExamenPGG.Business.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ExamenPGG.Business.GameObject
{
    public class Game : IGame, INotifyPropertyChanged
    {
        public List<IPlayer> PlayerList { get; set; }
        public IPlayer CurrentPlayer { get; set; }
        public IPlayer WinningPlayer { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public List<IDice> DiceBag { get; set; }
        public int DiceAmount { get; set; } = 2;
        public int RoundNumber { get; set; }
        public int CurrentplayerID { get; private set; }

        private ILogger _logger;
        private IDiceFactory _diceFactory;
        private IGameService _gameService;

        private bool isDiceButtonEnabled = false;
        public bool IsDiceButtonEnabled 
        { 
            get
            {
                return isDiceButtonEnabled;
            }
            set
            {
                isDiceButtonEnabled=value;
                RaisePropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public Game(ILogger logger, IDiceFactory diceFactory, IGameService service)
        {
            _logger = logger;
            _diceFactory = diceFactory;
            _gameService = service;
            DiceBag = new List<IDice>();
            FillDiceBag();
        }

        private void FillDiceBag()
        {
            for (int i = 0; i < DiceAmount; i++)
            {
                DiceBag.Add(_diceFactory.CreateDice());
            }
        }

        public void InitializeNewGame(List<IPlayer> playerList)
        {
            PlayerList = playerList;
            CurrentPlayer = PlayerList[0];
            StartTime = DateTime.Now;
            RoundNumber = 1;
            CurrentplayerID = 0;
        }

        public void StartGame()
        {
            //some start logic?
            if (PlayerList is null)
            {
                return;
            }

            IncrementScore();
        }

        public void IncrementScore()
        {
            CurrentPlayer.TurnAmount++;
            CurrentPlayer.Direction = 1;
            _logger.LogPlayerTurn(CurrentPlayer);
            CanPlayerMove();
        }

        public void CanPlayerMove() //removed the currentplayer parameter since this is available inside the game class
        {
            if (CurrentPlayer.InActiveTurns == 0)
            {
                IsHumanCheck();
            }
            else
            {
                CurrentPlayer.InActiveTurns -= 1;
                _logger.LogSkipTurn(CurrentPlayer);
                ChangeCurrentPlayer();
            }
        }

        private void IsHumanCheck()
        {
            if (CurrentPlayer.IsHuman)
            {
                EnableDiceButton();
            }
            else
            {
                ExecuteDiceRoll();
            }
        }

        private void EnableDiceButton()
        {
            IsDiceButtonEnabled = true;
        }

        public void ExecuteDiceRoll()
        {
            IsDiceButtonEnabled = false;

            List<int> rollAmount = new();
            foreach (var dice in DiceBag)
            {
                rollAmount.Add(dice.RollDice());
            }
            CurrentPlayer.LastThrow = rollAmount.Sum();
            _logger.LogDiceRoll(CurrentPlayer, rollAmount.Sum());
            CheckRoll(rollAmount);
            HasReachedEnd();
        }

        private void CheckRoll(List<int> rollAmount)
        {
            if (CurrentPlayer.CurrentSquare.SquareType is Squares.SquareType.Start)
            {
                if ((rollAmount.Contains(4)) & (rollAmount.Contains(5)))
                {
                    _logger.LogMessage("Wow, special case: go straight to square 28!");
                    CurrentPlayer.MoveToSquare(28);
                }
                else if ((rollAmount.Contains(6)) & (rollAmount.Contains(3)))
                {
                    _logger.LogMessage("Wow, special case: go straight to square 52!");
                    CurrentPlayer.MoveToSquare(52);
                }
                else
                {
                    CurrentPlayer.MovePlayer(rollAmount.Sum());
                }
            }
            else
            {
                CurrentPlayer.MovePlayer(rollAmount.Sum());
            }
        }

        private void HasReachedEnd()
        {
            if (CurrentPlayer.CurrentSquare.ID == 63)
            {
                EndGame();
            }
            else
            {
                ChangeCurrentPlayer();
            }
        }

        public void ChangeCurrentPlayer()
        {
            CurrentplayerID++;
            if (CurrentplayerID == PlayerList.Count)
            {
                CurrentplayerID = 0;
                RoundNumber++;
            }
            CurrentPlayer = PlayerList[CurrentplayerID];
            IncrementScore();
        }

        public void EndGame()
        {
            WinningPlayer = CurrentPlayer;
            EndTime = DateTime.Now;
            _logger.LogGameEnd(this);
            _gameService.LogGameToDB(this);
        }

        private void RaisePropertyChanged([CallerMemberName]string? propertyName=null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}