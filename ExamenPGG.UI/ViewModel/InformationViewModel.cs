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

        //[RelayCommand]
        //async Task GoToRules()
        //{
        //    add rules page to be able to nav to it.
        //    await Shell.Current.GoToAsync($"{nameof(RulesView)}");
        //}

        [RelayCommand]
        async Task GoBack()
        {
            await Shell.Current.GoToAsync($"..");
        }
    }
}
