using ExamenPGG.Business.Game;
using ExamenPGG.Business.Logging;
using ExamenPGG.Business.Player;

namespace ExamenPGG.Business._01_Classes
{
    internal class Game : IGame
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

        public bool CanPlayerMove(IPlayer currentPlayer)
        {
            if (currentPlayer.InActiveTurns == 0)
            {
                return true;
            }
            return false;
        }

        public void ChangeCurrentPlayer(List<IPlayer> playerList)
        {
            IPlayer temp = playerList[0];

            playerList.Remove(playerList[0]);
            playerList.Insert(playerList.Count, temp);

            CurrentPlayer = PlayerList[0];
        }

        public void EndGame()
        {
            throw new NotImplementedException();
        }

        public void GameLoop()
        {
            throw new NotImplementedException();
        }

        public void IncrementScore()
        {
            throw new NotImplementedException();
        }

        public void PerformTurn()
        {
            throw new NotImplementedException();
        }

        public bool StartGame()
        {
            throw new NotImplementedException();
        }
    }
}
