using ExamenPGG.Business.GameObject;
using ExamenPGG.Business.PlayerObject;
using ExamenPGG.Business.Squares;

namespace ExamenPGG.Business.Logging
{
    public class Logger : ILogger
    {
        public void LogDiceRoll(IPlayer player, int rollAmount)
        {
            Console.WriteLine($"{player.Name} rolled the dice and got {rollAmount}!");
        }

        public void LogGame(IGame game)
        {
        }

        public void LogMessage(string message)
        {
        }

        public void LogSpecialSquare(ISquare squareHit)
        {
        }
    }
}