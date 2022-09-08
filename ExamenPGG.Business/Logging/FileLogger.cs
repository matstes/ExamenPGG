using ExamenPGG.Business.GameObject;
using ExamenPGG.Business.PlayerObject;
using ExamenPGG.Business.Squares;
using System.Text;

namespace ExamenPGG.Business.Logging
{
    public class FileLogger : ILogger
    {
        public FileLogger()
        {
            Sb = new StringBuilder();
        }

        private StringBuilder sb;

        public StringBuilder Sb
        {
            get { return sb; }
            set { sb = value; }
        }

        public void LogDiceRoll(IPlayer player, int rollAmount)
        {
            sb.AppendLine($"{DateTime.Now}: {player.Name} rolled the dice and got {rollAmount}!");
            logForInterface = sb.ToString();

        }

        public void LogGameEnd(IGame game)
        {
            sb.AppendLine();
            sb.AppendLine("----------------------------------");
            sb.AppendLine($"The game that started on {game.StartTime} has ended on {game.EndTime}");
            sb.AppendLine($"The winner of this game is {game.WinningPlayer.Name} and they won in {game.WinningPlayer.TurnAmount} turns");
            sb.AppendLine("----------------------------------");

            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string fileName = "GameData" + DateTime.Now.ToString("yyyy-dd-M-HH-mm") + ".txt";

            using (StreamWriter StreamWriter = new StreamWriter(filePath + fileName))
            {
                StreamWriter.Write(sb.ToString());
            }
        }

        public void LogMessage(string message)
        {
            sb.Append(message);
        }

        public void LogNewLine()
        {
            sb.AppendLine();
        }

        public void LogPlayerTurn(IPlayer player)
        {
            sb.AppendLine();
            sb.AppendLine($"{DateTime.Now}: New turn started for {player.Name}, turn: {player.TurnAmount}, pos: {player.CurrentSquare.ID}");
        }

        public void LogSkipTurn(IPlayer player)
        {
            sb.AppendLine($"{DateTime.Now}: Unfortunatly {player.Name} you are stuck, skip this turn");
        }

        public void LogSpecialSquare(ISquare squareHit, IPlayer player)
        {
            sb.AppendLine($"{DateTime.Now}: Player {player.Name} entered squareID: {squareHit.ID}, {squareHit.SquareType}");
        }
    }
}