using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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

        public PlayerSelectionViewModel()
        {
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
    }
}
