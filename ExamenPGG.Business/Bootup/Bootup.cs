﻿using ExamenPGG.Business.GameObject;
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
        private string wrongInput = "Please input correct numbers only.";

        public string AskPlayerNumber()
        {
            string askPlayerNumber = "How many players? (0-5) 0 = simulate game";
            Console.Clear();
            return askPlayerNumber;
        }

        public void InitialPlayerNumber()
        {
            bool isPlayersInLimit = true;
            while (isPlayersInLimit)
            {
                Console.WriteLine("How many players? (0-5) 0 = simulate game");
                try
                {
                    playerNumber = Convert.ToInt32(Console.ReadLine());
                    if (playerNumber < 0 || playerNumber > 5)
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                    else
                    {
                        Console.Clear();
                        isPlayersInLimit = false;
                    }
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine(wrongInput);
                }
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
                InitialPlayerNumber();
                Console.WriteLine(AskPlayerNames());
                InputPlayerNames();

                //TODO: This does not yet include a choice for player icons! Player NAME input ONLY for now!
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