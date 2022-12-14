using ExamenPGG.Business.GameObject;
using ExamenPGG.Business.PlayerObject;
using ExamenPGG.Business.Squares;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace ExamenPGG.Business.Logging
{
    public class FileLogger : ILogger, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private StringBuilder sb;

        public FileLogger()
        {
            sb = new StringBuilder();
        }

        private string logData = "";

        public string LogData
        {
            get { return logData; }
            set
            {
                logData = value;
                LogDataLength = logData.Length;
                RaisePropertyChanged();
            }
        }

        private int logDataLength;

        public int LogDataLength
        {
            get { return logDataLength; }
            set
            {
                logDataLength = value;
                RaisePropertyChanged();
            }
        }

        public StringBuilder Sb { get; set; }

        private void RaisePropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void LogDiceRoll(IPlayer player, List<int> rollAmount)
        {
            sb.AppendLine($"{DateTime.Now}: {player.Name} rolled the dice and got {rollAmount[0]} + {rollAmount[1]}, for a total of: {rollAmount.Sum()}!");
            LogData = sb.ToString();
        }

        public void LogGameEnd(IGame game)
        {
            sb.AppendLine();
            sb.AppendLine("----------------------------------");
            sb.AppendLine($"The game that started on {game.StartTime} has ended on {game.EndTime}");
            sb.AppendLine($"The winner of this game is {game.WinningPlayer.Name} and they won in {game.WinningPlayer.TurnAmount} turns");
            sb.AppendLine("----------------------------------");
            LogData = sb.ToString();

            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string fileName = "GameData" + DateTime.Now.ToString("yyyy-dd-M-HH-mm") + ".txt";

            using (StreamWriter StreamWriter = new StreamWriter(filePath + fileName))
            {
                StreamWriter.Write(sb.ToString());
            }
        }

        public void LogMessage(string message)
        {
            sb.AppendLine($"{DateTime.Now}: " + message);
            LogData = sb.ToString();
        }

        public void LogNewLine()
        {
            sb.AppendLine();
            LogData = sb.ToString();
        }

        public void LogPlayerTurn(IPlayer player)
        {
            sb.AppendLine();
            sb.AppendLine($"{DateTime.Now}: New turn started for {player.Name}, turn: {player.TurnAmount}, pos: {player.CurrentSquare.ID}");
            LogData = sb.ToString();
        }

        public void LogSkipTurn(IPlayer player)
        {
            sb.AppendLine($"{DateTime.Now}: Unfortunatly {player.Name} you are stuck, skip this turn");
            LogData = sb.ToString();
        }

        public void LogSpecialSquare(ISquare squareHit, IPlayer player)
        {
            sb.AppendLine($"{DateTime.Now}: Player {player.Name} entered squareID: {squareHit.ID}, {squareHit.SquareType}");
            LogData = sb.ToString();
        }

        public void LogMysteryDeath(IPlayer player)
        {
            sb.AppendLine($"{DateTime.Now}: Player {player.Name} has died! Go back to square 0.");
            LogData = sb.ToString();
        }

        public void LogMysteryMove(IPlayer player, int rollAmount)
        {
            sb.AppendLine($"{DateTime.Now}: Player {player.Name} gets an extra dice roll! You got {rollAmount}");
            LogData = sb.ToString();
        }

        public void LogGameStart(DateTime startTime, List<IPlayer> playerlist)
        {
            sb.Clear();
            sb.AppendLine("----------------------------------");
            sb.AppendLine($"A new game has started on {startTime} with the following players:");
            int i = 1;
            foreach (var player in playerlist)
            {
                sb.AppendLine($"\t{i}) {player.Name}");
                i++;
            }
            sb.AppendLine("----------------------------------");
            LogData = sb.ToString();
        }
    }
}