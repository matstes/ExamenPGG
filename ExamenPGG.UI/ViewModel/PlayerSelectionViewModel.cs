using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExamenPGG.Business.GameObject;
using ExamenPGG.Business.PlayerObject;
using ExamenPGG.Business.Factory;
using ExamenPGG.UI.Model;
using System.Collections.ObjectModel;

namespace ExamenPGG.UI.ViewModel
{
    public partial class PlayerSelectionViewModel : ObservableObject
    {
        [ObservableProperty]
        private int playerCount = 1;

        [ObservableProperty]
        private string errorMessage = string.Empty;

        public ObservableCollection<PlayerChoice> PlayerChoices { get; set; } = new();
        public IList<String> IconList { get; set; }

        private IPlayerFactory _playerFactory;
        private IGame _game;

        public PlayerSelectionViewModel(IGame game, IPlayerFactory playerFactory)
        {
            _playerFactory = playerFactory;
            _game = game;

            IconList = new List<string>()
            {
                "villager1.png",
                "villager2.png",
                "villager3.png",
                "villager4.png",
                "villager5.png"
            };
            PlayerChoices.Add(new PlayerChoice("Player 1", IconList));
        }

        [RelayCommand]
        private void AddPlayer()
        {
            if (PlayerCount < 5)
            {
                PlayerCount++;
                PlayerChoices.Add(new PlayerChoice($"Player {playerCount}", IconList));
            }
        }

        [RelayCommand]
        private void RemovePlayer()
        {
            if (PlayerCount > 1)
            {
                PlayerCount--;
                PlayerChoices.RemoveAt(PlayerCount);
            }
        }

        [RelayCommand]
        private async Task StartGame()
        {
            List<IPlayer> playerList = GetPlayerList();
            if (playerList is null)
            {
                return;
            }

            _game.InitializeNewGame(playerList);

            _game.StartGame();
            await GoToMainViewAsync();
        }

        private async Task GoToMainViewAsync()
        {
            await Shell.Current.GoToAsync($"{nameof(MainPage)}");
        }

        private List<IPlayer> GetPlayerList()
        {
            //generate playerlist
            List<IPlayer> playerList = new();

            foreach (var choice in PlayerChoices)
            {
                if ((string.IsNullOrEmpty(choice.Name)) || (choice.Name.Count() > 17))
                {
                    ErrorMessage = "Please enter a name between 1 and 17 characters long for every player";
                    return null;
                }
                else
                {
                    IPlayer newPlayer = _playerFactory.CreatePlayer(choice.Name, choice.Icon, !choice.IsBot);
                    playerList.Add(newPlayer);
                }
            }
            ErrorMessage = string.Empty;
            return playerList;
        }
    }
}