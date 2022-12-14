using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExamenPGG.Business.GameObject;
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
        private async Task GoToRules()
        {
            await Shell.Current.GoToAsync($"{nameof(GameRulesView)}");
        }

        [RelayCommand]
        private async Task GoBack()
        {
            Game.SendPauseRequest();
            await Shell.Current.GoToAsync($"..");
        }

        [RelayCommand]
        private async Task GoToLeaderBoardAsync()
        {
            await Shell.Current.GoToAsync($"{nameof(LeaderBoardView)}");
        }
    }
}