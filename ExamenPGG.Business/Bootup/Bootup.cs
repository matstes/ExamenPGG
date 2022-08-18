
namespace ExamenPGG.Business.Bootup
{
    public class Bootup : IBootup
    {
        public bool isReady = false;

        public int playerNumber = -1;
        private string inputPlayerNumber = "0";
        private string computerName = "Computer";
        private string wrongInput = "Please input correct numbers only.";

        public List<string> activePlayers = new List<string>();

        public string AskPlayerNumber()
        {
            string askPlayerNumber = "How many players? (0-5) 0 = simulate game";
            return askPlayerNumber;
        }

        public void InitialPlayerNumber()
        {
            playerNumber = -1;
            inputPlayerNumber = Console.ReadLine();
            if      (inputPlayerNumber == "0") { playerNumber = 0; }
            else if (inputPlayerNumber == "1") { playerNumber = 1; }
            else if (inputPlayerNumber == "2") { playerNumber = 2; }
            else if (inputPlayerNumber == "3") { playerNumber = 3; }
            else if (inputPlayerNumber == "4") { playerNumber = 4; }
            else if (inputPlayerNumber == "5") { playerNumber = 5; }
            else
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
                Console.WriteLine($"Input name for player {i+1}:");
                activePlayers.Add(Console.ReadLine());
            }
            Console.WriteLine("Setup complete. Press ANY KEY to start game.");

            Console.ReadKey();

            isReady = true;

        }

        public void CreateGame()
        {

        }
    }
}