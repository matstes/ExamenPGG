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

        private bool isBusy = false;
        private bool pauseRequest = false;
        private bool _hasNoWinner = true;

        public bool HasNoWinner
        {
            get { 
                return _hasNoWinner;
            }
            set { 
                _hasNoWinner = value;
                RaisePropertyChanged();
            }
        }


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
                isDiceButtonEnabled = value;
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

        public async Task InitializeNewGame(List<IPlayer> playerList)
        {
            while (isBusy)
            {
                pauseRequest = true;
                await Task.Delay(100);
            }

            HasNoWinner = true;
            PlayerList = playerList;
            CurrentPlayer = PlayerList[0];
            StartTime = DateTime.Now;
            RoundNumber = 1;
            CurrentplayerID = 0;
        }

        public async Task StartGame()
        {
            if ((PlayerList is null) || (isBusy))
            {
                return;
            }
            _logger.LogGameStart(StartTime, PlayerList);
            isBusy = true;
            await IncrementScore();
        }

        public async Task IncrementScore()
        {
            if (pauseRequest)
            {
                InterruptGame();
            }
            else
            {
            CurrentPlayer.TurnAmount++;
            CurrentPlayer.Direction = 1;
            _logger.LogPlayerTurn(CurrentPlayer);
            await CanPlayerMove();
            }
        }

        private void InterruptGame()
        {
            pauseRequest = false;
            isBusy = false;
        }

        public async Task CanPlayerMove()
        {
            if (CurrentPlayer.InActiveTurns == 0)
            {
                await IsHumanCheck();
            }
            else
            {
                CurrentPlayer.InActiveTurns -= 1;
                _logger.LogSkipTurn(CurrentPlayer);
                await ChangeCurrentPlayer();
            }
        }

        private async Task IsHumanCheck()
        {
            if (CurrentPlayer.IsHuman)
            {
                EnableDiceButton();
            }
            else
            {
                await Task.Delay(1000);
                await ExecuteDiceRoll();
            }
        }

        private void EnableDiceButton()
        {
            IsDiceButtonEnabled = true;
            isBusy = false;
        }

        public async Task ExecuteDiceRoll()
        {
            isBusy = true;
            IsDiceButtonEnabled = false;

            List<int> rollAmount = new();
            foreach (var dice in DiceBag)
            {
                rollAmount.Add(dice.RollDice());
            }
            CurrentPlayer.LastThrow = rollAmount.Sum();
            _logger.LogDiceRoll(CurrentPlayer, rollAmount);
            await CheckRoll(rollAmount);
            await HasReachedEnd();
        }

        private async Task CheckRoll(List<int> rollAmount)
        {
            if (CurrentPlayer.CurrentSquare.SquareType is Squares.SquareType.Start)
            {
                if ((rollAmount.Contains(4)) & (rollAmount.Contains(5)))
                {
                    _logger.LogMessage("Wow, special case: go straight to square 28!");
                    await CurrentPlayer.MovePlayerVisualy(28);
                }
                else if ((rollAmount.Contains(6)) & (rollAmount.Contains(3)))
                {
                    _logger.LogMessage("Wow, special case: go straight to square 52!");
                    await CurrentPlayer.MovePlayerVisualy(52);
                }
                else
                {
                    await CurrentPlayer.MovePlayerVisualy(rollAmount.Sum());
                }
            }
            else
            {
                await CurrentPlayer.MovePlayerVisualy(rollAmount.Sum());
            }
        }

        private async Task HasReachedEnd()
        {
            if (CurrentPlayer.CurrentSquare.ID == 63)
            {
                await EndGame();
            }
            else
            {
                await ChangeCurrentPlayer();
            }
        }

        public async Task ChangeCurrentPlayer()
        {
            CurrentplayerID++;
            if (CurrentplayerID == PlayerList.Count)
            {
                CurrentplayerID = 0;
                RoundNumber++;
            }
            CurrentPlayer = PlayerList[CurrentplayerID];
            await IncrementScore();
        }

        public async Task EndGame()
        {
            WinningPlayer = CurrentPlayer;
            isBusy = false;
            HasNoWinner = false;
            EndTime = DateTime.Now;
            _logger.LogGameEnd(this);
            await _gameService.LogGameToDB(this);
        }

        public void SendPauseRequest()
        {
            if (isBusy)
            {
                pauseRequest = true;
            }
        }

        private void RaisePropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}