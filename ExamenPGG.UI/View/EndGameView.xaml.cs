using ExamenPGG.UI.ViewModel;

namespace ExamenPGG.UI.View;

public partial class EndGameView : ContentPage
{
    public EndGameView(EndGameViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}