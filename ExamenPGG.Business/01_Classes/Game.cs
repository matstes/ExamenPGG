using ExamenPGG.Business._00_Interfaces;

namespace ExamenPGG.Business._01_Classes
{
    internal class Game : IGame
    {
        public List<IPlayer> PlayerList { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IPlayer CurrentPlayer { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IPlayer WinningPlayer { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime StartTime { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime EndTime { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int RoundNumber { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IGameBoard GameBoard { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ILogger Logger { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IDice Dice { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool CanPlayerMove()
        {
            throw new NotImplementedException();
        }

        public void ChangeCurrentPlayer()
        {
            throw new NotImplementedException();
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
