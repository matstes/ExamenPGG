using ExamenPGG.UI.ViewModel;
namespace ExamenPGG.UI.View;

public partial class GameBoardView : ContentPage
{
    public GameBoardView(GameBoardViewModel gbVM)
    {
        InitializeComponent();
        BindingContext = gbVM;
    }
}