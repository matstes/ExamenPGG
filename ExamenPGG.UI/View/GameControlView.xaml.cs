using ExamenPGG.UI.ViewModel;
using Microsoft.Maui.Controls;

namespace ExamenPGG.UI.View;

public partial class GameControlView : ContentView
{
	public GameControlView(GameControlViewModel gcVM)
	{
		InitializeComponent();
		BindingContext = gcVM;
	}

	private void ScrollView_SizeChanged(object sender, EventArgs e)
	{
		logScreenScrollView.ScrollToAsync(0, 10000, true);
	}
}