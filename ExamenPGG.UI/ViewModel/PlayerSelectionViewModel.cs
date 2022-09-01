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

        public PlayerSelectionViewModel()
        {
            PlayerChoices.Add(new PlayerChoice("Player 1"));
        }

        [RelayCommand]
        public void AddPlayer()
        {
            if (PlayerCount < 5)
            {
                PlayerCount++;
                PlayerChoices.Add(new PlayerChoice($"Player {playerCount}"));
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
