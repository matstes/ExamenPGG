using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExamenPGG.UI.View;

namespace ExamenPGG.UI.ViewModel
{
    public partial class StartupViewModel : ObservableObject
    {
        [RelayCommand]
        private async Task GoToLeaderBoardAsync()
        {
            await Shell.Current.GoToAsync($"{nameof(LeaderBoardView)}");
        }

        [RelayCommand]
        private async Task GoToPlayerSelectionAsync()
        {
            await Shell.Current.GoToAsync($"{nameof(PlayerSelectionView)}");
        }
    }
}