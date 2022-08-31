using ExamenPGG.Business.Logging;
using ExamenPGG.Business.PlayerObject;

namespace ExamenPGG.Business.GameObject
{
    public class Game : IGame
    {
        public List<IPlayer> PlayerList { get; set; }
        public IPlayer CurrentPlayer { get; set; }
        public IPlayer WinningPlayer { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int RoundNumber { get; set; }
        public IGameBoard GameBoard { get; set; }
        public ILogger Logger { get; set; }
        public IDice Dice { get; set; }
        public bool IsDiceButtonEnabled { get; private set; } = false;
        public int CurrentplayerID { get; private set; }

        public Game(List<IPlayer> playerList, IPlayer currentPlayer, DateTime startTime, int roundNumber, IGameBoard gameBoard, ILogger logger, IDice dice)
        {
            PlayerList = playerList;
            CurrentPlayer = PlayerList[0];
            StartTime = DateTime.Now;
            RoundNumber = 1;
            GameBoard = gameBoard;
            Logger = logger;
            Dice = dice;
        }

        public void StartGame()
        {
            //some start logic?
            IncrementScore();
        }

        public void IncrementScore()
        {
            CurrentPlayer.TurnAmount++;
            CurrentPlayer.Direction = 1;
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
            Console.WriteLine("Press any key to roll.");
            Console.ReadKey(); //must become wpf button.
            ExecuteDiceRoll(); // remove after wpf button
        }

        private void ExecuteDiceRoll()
        {
            IsDiceButtonEnabled = false;
            int rollAmount = Dice.RollDice(2);
            CurrentPlayer.LastThrow = rollAmount;
            Logger.LogDiceRoll(CurrentPlayer, rollAmount);
            CurrentPlayer.MovePlayer(rollAmount);
            HasReachedEnd();
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
            Console.WriteLine("YOU WON YIPIE");
        }
    }
}