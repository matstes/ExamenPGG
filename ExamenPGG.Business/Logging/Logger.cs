using ExamenPGG.Business.GameObject;
using ExamenPGG.Business.PlayerObject;
using ExamenPGG.Business.Squares;

namespace ExamenPGG.Business.Logging
{
    public class Logger : ILogger
    {
        public void LogDiceRoll(IPlayer player, int rollAmount)
        {
            Console.WriteLine($"{DateTime.Now}: {player.Name} rolled the dice and got {rollAmount}!");
        }

        public void LogGameEnd(IGame game)
        {
            LogNewLine();
            Console.WriteLine("----------------------------------");
            Console.WriteLine($"The game that started on {game.StartTime} has ended on {game.EndTime}");
            Console.WriteLine($"The winner of this game is {game.WinningPlayer.Name} and they won in {game.WinningPlayer.TurnAmount} turns");
            Console.WriteLine("----------------------------------");
        }

        public void LogMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void LogNewLine()
        {
            Console.WriteLine();
        }

        public void LogPlayerTurn(IPlayer player)
        {
            LogNewLine();
            Console.WriteLine($"{DateTime.Now}: New turn started for {player.Name}, turn: {player.TurnAmount}, pos: {player.CurrentSquare.ID}");
        }

        public void LogSkipTurn(IPlayer player)
        {
            Console.WriteLine($"{DateTime.Now}: Unfortunatly {player.Name} you are stuck, skip this turn");
        }

        public void LogSpecialSquare(ISquare squareHit, IPlayer player)
        {
            Console.WriteLine($"{DateTime.Now}: Player {player.Name} entered squareID: {squareHit.ID}, {squareHit.SquareType}");
        }
    }
}