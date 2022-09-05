using CommunityToolkit.Mvvm.ComponentModel;
using ExamenPGG.Business.GameObject;

namespace ExamenPGG.UI.ViewModel
{
     [QueryProperty("Game", "Game")]
    public partial class MainViewModel: ObservableObject
    {
        [ObservableProperty]
        Game game;

        public MainViewModel()
        {

        }
    }
}
