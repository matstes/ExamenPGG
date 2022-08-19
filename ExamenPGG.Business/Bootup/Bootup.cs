using ExamenPGG.Business.GameObject;
using ExamenPGG.Business.Logging;
using ExamenPGG.Business.PlayerObject;

namespace ExamenPGG.Business.Bootup
{
    public class Bootup : IBootup
    {
        public List<string> activePlayers = new List<string>();
        public bool isReady = false;

        public int playerNumber = -1;
        private string computerName = "Computer";
        private string inputPlayerNumber = "0";
        private string wrongInput = "Please input correct numbers only.";

        public string AskPlayerNumber()
        {
            string askPlayerNumber = "How many players? (0-5) 0 = simulate game";
            return askPlayerNumber;
        }
        public void InitialPlayerNumber()
        {
            playerNumber = -1;

            try
            {
                inputPlayerNumber = Console.ReadLine();
                playerNumber = Convert.ToInt32(inputPlayerNumber);
                if (playerNumber < 0 || playerNumber > 5)
                {
                    Console.Clear();
                    Console.WriteLine(wrongInput);
                    AskPlayerNumber();
                }
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine(wrongInput);
                AskPlayerNumber();
            }
        }
        public string AskPlayerNames()
        {
            string askPlayerName = "";
            if (playerNumber == 0)
            {
                askPlayerName = $"Simulated game. Player is named {computerName}.";
                activePlayers.Add(computerName);
                isReady = true;
            }
            else
            {
                askPlayerName = $"Input names for players:";
            }
            return askPlayerName;
        }

        public void InputPlayerNames()
        {
            for (int i = 0; i < playerNumber; i++)
            {
                Console.WriteLine($"Input name for player {i + 1}:");
                activePlayers.Add(Console.ReadLine());
            }
            Console.WriteLine("Setup complete. Press ANY KEY to start game.");

            Console.ReadKey();

            isReady = true;
        }

        public IGame CreateGame(List<IPlayer> inputList)
        {
            while (isReady == false)
            {
                //Input player number
                Console.WriteLine(AskPlayerNumber());
                InitialPlayerNumber();

                //Input player names or simulate Computer name
                while (playerNumber >= 0 && playerNumber <= 5 && isReady == false)
                {
                    //TODO: This does not yet include a choice for player icons! Player NAME input ONLY for now!
                    Console.WriteLine(AskPlayerNames());
                    InputPlayerNames();
                    //boot.activePlayers list (strings) is now created: List of player names ("Computer" or 1-5 real names)
                    //boot.isReady is true if all input it complete: Continue to final part of boot sequence
                }
            }
            //Finalize boot sequence and create game instance:
            bool isHumans = true;
            if (playerNumber == 0)
            {
                isHumans = false;
            }
            for (int i = 0; i < activePlayers.Count; i++)
            {
                //Create list of player instances from the bootlist of player names:
                string newPlayerName = activePlayers[i];
                Player newPlayer = new Player(isHumans);
                newPlayer.Name = newPlayerName;
                inputList.Add(newPlayer);
            }
            DateTime currentTime = new DateTime();
            IGameBoard newGameBoard = GameBoard.GetInstance();
            ILogger gameLogger = new Logger();
            Dice gameDice = new Dice();

            return new Game(inputList, inputList[0], currentTime, 1, newGameBoard, gameLogger, gameDice);
        }
    }
}