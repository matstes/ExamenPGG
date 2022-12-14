using ExamenPGG.Business.GameObject;
using ExamenPGG.Business.PlayerObject;
using ExamenPGG.Business.Squares;
using System.Text;

namespace ExamenPGG.Business.Logging
{
    public interface ILogger
    {
        public int LogDataLength { get; set; }
        public string LogData { get; set; }
        public StringBuilder Sb { get; set; }

        void LogGameEnd(IGame game);

        void LogGameStart(DateTime startTime, List<IPlayer> playerlist);

        void LogSpecialSquare(ISquare squareHit, IPlayer player);

        void LogMessage(string message);

        void LogDiceRoll(IPlayer player, List<int> rollAmount);

        void LogMysteryDeath(IPlayer player);

        void LogMysteryMove(IPlayer player, int rollAmount);

        void LogPlayerTurn(IPlayer player);

        void LogSkipTurn(IPlayer player);
    }
}