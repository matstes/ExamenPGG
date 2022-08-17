using ExamenPGG.Business.Game;
using ExamenPGG.Business.Squares;

namespace ExamenPGG.Business.Logging
{
    public interface ILogger
    {
        void LogGame(IGame game);
        void LogSpecialSquare(ISquare squareHit);
        void LogMessage(string message);
    }
}