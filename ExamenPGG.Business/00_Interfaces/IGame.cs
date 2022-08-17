namespace ExamenPGG.Business._00_Interfaces
{
    public interface IGame
    {
        List<IPlayer> PlayerList { get; set; }
        IPlayer CurrentPlayer { get; set; }
        IPlayer WinningPlayer { get; set; }
        DateTime StartTime { get; set; }
        DateTime EndTime { get; set; }
        public int RoundNumber { get; set; }
        IGameBoard GameBoard { get; set; }
        ILogger Logger { get; set; }
        public IDice Dice { get; set; }

        bool StartGame();

        void GameLoop();

        void PerformTurn();

        bool CanPlayerMove();

        void ChangeCurrentPlayer();

        void IncrementScore();

        void EndGame();
    }
}