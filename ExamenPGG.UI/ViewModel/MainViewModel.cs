using ExamenPGG.UI.View;

namespace ExamenPGG.UI.ViewModel
{
    public class MainViewModel
    {
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
