using ExamenPGG.UI.ViewModel;

namespace ExamenPGG.UI.View;

public partial class GameBoardView : ContentView
{
    public GameBoardView(GameBoardViewModel gbVM)
    {
        InitializeComponent();
        BindingContext = gbVM;
    }
}