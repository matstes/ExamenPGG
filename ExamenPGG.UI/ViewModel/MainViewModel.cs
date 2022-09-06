using ExamenPGG.UI.View;
using CommunityToolkit.Mvvm.ComponentModel;
using ExamenPGG.Business.GameObject;

namespace ExamenPGG.UI.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        Game game;

        public InformationView InformationView { get; set; }
        public GameBoardView GameBoardView { get; set; }
        public GameControlView GameControlView { get; set; }
        public MainViewModel(GameControlView gameControlView, InformationView informationView, GameBoardView gameBoardView)
        {
            GameControlView = gameControlView;
            InformationView = informationView;
            GameBoardView = gameBoardView;
        }
    }
}
