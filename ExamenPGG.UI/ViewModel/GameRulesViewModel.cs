using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ExamenPGG.UI.ViewModel
{
    public partial class GameRulesViewModel : ObservableObject
    {
        [RelayCommand]
        private async Task GoBackAsync()
        {
            await Shell.Current.GoToAsync($"..");
        }
    }
}