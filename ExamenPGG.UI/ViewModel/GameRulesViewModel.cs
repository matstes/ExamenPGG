using CommunityToolkit.Mvvm.Input;

namespace ExamenPGG.UI.ViewModel
{
    public partial class GameRulesViewModel
    {
        [RelayCommand]
        async Task GoBack()
        {
            await Shell.Current.GoToAsync($"..");
        }
    }
}
