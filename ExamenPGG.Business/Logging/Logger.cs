using ExamenPGG.Business.GameObject;
using ExamenPGG.Business.PlayerObject;
using ExamenPGG.Business.Squares;

namespace ExamenPGG.Business.Logging
{
    public class Logger : ILogger
    {
        public void LogDiceRoll(IPlayer player, int rollAmount)
        {
            Console.WriteLine($"{DateTime.Now} {player.Name} rolled the dice and got {rollAmount}!");
        }

        public void LogGame(IGame game)
        {
        }

        public void LogMessage(string message)
        {
        }

        public void LogSpecialSquare(ISquare squareHit, IPlayer player)
        {
            Console.WriteLine($"{DateTime.Now} Player {player.Name} entered squareID: {squareHit.ID}, {squareHit.SquareType}");
        }
    }
}