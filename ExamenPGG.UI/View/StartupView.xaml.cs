using ExamenPGG.UI.ViewModel;

namespace ExamenPGG.UI.View;

public partial class StartupView : ContentPage
{
    public StartupView(StartupViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}