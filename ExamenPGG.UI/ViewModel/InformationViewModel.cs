using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExamenPGG.Business.GameObject;
using ExamenPGG.Business.PlayerObject;
using ExamenPGG.UI.View;

namespace ExamenPGG.UI.ViewModel
{
    public partial class InformationViewModel : ObservableObject
    {
        [ObservableProperty]
        private IGame game;
        public InformationViewModel(IGame game)
        {
            Game = game;

        }
        [RelayCommand]
        private async Task GoToRulesAsync()
        {
            await Shell.Current.GoToAsync($"{nameof(MainPage)}");
        }

        [RelayCommand]
        private async Task GoToLeaderBoardAsync()
        {
            await Shell.Current.GoToAsync($"{nameof(LeaderBoardView)}");
        }
    }
}
