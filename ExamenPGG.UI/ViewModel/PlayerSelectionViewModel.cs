using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExamenPGG.Business;
using ExamenPGG.Business.GameObject;
using ExamenPGG.Business.Logging;
using ExamenPGG.Business.PlayerObject;
using ExamenPGG.Business.Squares.Factory;
using ExamenPGG.UI.Model;
using System.Collections.ObjectModel;

namespace ExamenPGG.UI.ViewModel
{
    public partial class PlayerSelectionViewModel: ObservableObject
    {
        [ObservableProperty]
        private int playerCount = 1;
        public ObservableCollection<PlayerChoice> PlayerChoices { get; set; } = new();
        public IList<String> IconList { get; set; }

        private IGameBoard _gameBoard;
        private ILogger _logger;
        private IPlayerFactory _playerFactory;
        private IDice _dice;

        public PlayerSelectionViewModel(IGameBoard gameBoard, IPlayerFactory playerFactory, ILogger logger, IDice dice)
        {
            _gameBoard = gameBoard;
            _logger = logger;
            _playerFactory = playerFactory;
            _dice = dice;

            IconList = new List<string>()
            {
                "testicon1.png",
                "testicon2.png",
                "testicon3.png",
                "testicon4.png",
                "testicon5.png"
            };
            PlayerChoices.Add(new PlayerChoice("Player 1", IconList));
        }

        [RelayCommand]
        public void AddPlayer()
        {
            if (PlayerCount < 5)
            {
                PlayerCount++;
                PlayerChoices.Add(new PlayerChoice($"Player {playerCount}", IconList));
            }
        }

        [RelayCommand]
        public void RemovePlayer()
        {
            if (PlayerCount > 1)
            {
                PlayerCount--;
                PlayerChoices.RemoveAt(PlayerCount);
            }
        }

        [RelayCommand]
        async Task StartGame()
        {
            List<IPlayer> playerList = GetPlayerList();
            if (playerList is null)
            {
                return;
            }

            var currentTime = DateTime.Now;
            IGame game = new Game(playerList, playerList[0], currentTime, 1, _gameBoard, _logger, _dice);

            //create the game object
            await GoToMainViewAsync(game);
        }

        async Task GoToMainViewAsync(IGame game)
        {
            await Shell.Current.GoToAsync($"{nameof(MainPage)}", true,
                new Dictionary<string, object>()
                {
                    {"Game", game }
                }) ;
        }

        private List<IPlayer> GetPlayerList()
        {
            //generate playerlist
            List<IPlayer> playerList = new();

            foreach (var choice in PlayerChoices)
            {
                if (string.IsNullOrEmpty(choice.Name))
                {
                    return null;
                }
                else
                {
                    IPlayer newPlayer = _playerFactory.CreatePlayer(choice.Name, choice.Icon, !choice.IsBot);
                    playerList.Add(newPlayer);
                }
            }
            return playerList;
        }
    }
}
