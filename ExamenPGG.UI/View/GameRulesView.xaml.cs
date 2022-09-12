using ExamenPGG.UI.ViewModel;

namespace ExamenPGG.UI.View;

public partial class GameRulesView : ContentPage
{

	public GameRulesView(GameRulesViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}