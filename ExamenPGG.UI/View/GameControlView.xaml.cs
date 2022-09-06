using ExamenPGG.UI.ViewModel;

namespace ExamenPGG.UI.View;

public partial class GameControlView : ContentView
{
	public GameControlView(GameControlViewModel gcVM)
	{
		InitializeComponent();
		BindingContext = gcVM;
	}
}