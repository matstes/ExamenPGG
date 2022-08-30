using ExamenPGG.Business.GameObject;
using ExamenPGG.Business.PlayerObject;
using ExamenPGG.Business.Squares;

namespace ExamenPGG.Business.Logging
{
    public interface ILogger
    {
        void LogGame(IGame game);

        void LogSpecialSquare(ISquare squareHit, IPlayer player);

        void LogMessage(string message);

        void LogDiceRoll(IPlayer player, int rollAmount);
    }
}