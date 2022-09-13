using ExamenPGG.UI.ViewModel;

namespace ExamenPGG.UI.View;

public partial class LeaderBoardView : ContentPage
{
    public LeaderBoardView(LeaderBoardViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}