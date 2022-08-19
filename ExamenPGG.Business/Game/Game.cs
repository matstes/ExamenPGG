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
            HasNewRoundStarted();
        }

        public void HasNewRoundStarted()
        {
            //new round started logic
            IncrementScore();
        }

        public void IncrementScore()
        {
            CurrentPlayer.TurnAmount++;
            CanPlayerMove();
        }

        public void CanPlayerMove() //removed the currentplayer parameter since this is available inside the game class
        {
            if (CurrentPlayer.InActiveTurns == 0)
            {
                IsHumanCheck();
            }
            ChangeCurrentPlayer();
        }

        private void IsHumanCheck()
        {
            if (CurrentPlayer.IsHuman)
            {
                EnableDiceButton();
            }
            ExecuteDiceRoll();
        }

        private void EnableDiceButton()
        {
            IsDiceButtonEnabled = true;
        }

        private void ExecuteDiceRoll()
        {
            IsDiceButtonEnabled = false;
            int rollAmount = Dice.RollDice(2);
            Logger.LogDiceRoll(CurrentPlayer, rollAmount);
            CurrentPlayer.MovePlayer(rollAmount);
        }

        public void ChangeCurrentPlayer()   //removed the playerlist parameter since this is available inside the game class
        {
            IPlayer temp = PlayerList[0];

            PlayerList.Remove(PlayerList[0]);
            PlayerList.Insert(PlayerList.Count, temp);

            CurrentPlayer = this.PlayerList[0];
        }

        public void EndGame()
        {
            throw new NotImplementedException();
        }

        public void GameLoop()
        {
            //split the game loop into more methods and jump from method to method:

            //implement a check to see if the playerlist has been cycled => roundnumber +1

            //always increment the current players turn count

            //is the player allowed to go?  no? change currentplayer
            //                              yes? IsHumanCheck

            //is the player human? no? go to ExecuteDiceRoll
            //                     yes? EnableDiceButton

            //  Button will also go to ExecuteDiceRoll method.

            //move player forward by the result of dice roll
            //player class + square classes should handle this entirely

            //check if the player reached 63? or can we do this in the finalSquare class

            //change current player + back to the first method
        }

        public void PerformTurn()
        {
            throw new NotImplementedException();
        }
    }
}