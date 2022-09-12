using ExamenPGG.Business.DiceObject;
using ExamenPGG.Business.Logging;
using ExamenPGG.Business.PlayerObject;

namespace ExamenPGG.Business.GameObject
{
    public interface IGame
    {
        List<IPlayer> PlayerList { get; set; }
        IPlayer CurrentPlayer { get; set; }
        IPlayer WinningPlayer { get; set; }
        DateTime StartTime { get; set; }
        DateTime EndTime { get; set; }
        public int RoundNumber { get; set; }
        List<IDice> DiceBag { get; set; }
        public bool IsDiceButtonEnabled { get; }
        public int CurrentplayerID { get; }

        void InitializeNewGame(List<IPlayer> playerList);
        Task StartGame();

        Task CanPlayerMove();

        Task ChangeCurrentPlayer();

        Task IncrementScore();

        void EndGame();

        Task ExecuteDiceRoll();
    }
}