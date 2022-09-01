using ExamenPGG.UI.ViewModel;

namespace ExamenPGG.UI.View;

public partial class PlayerSelectionView : ContentPage
{
	public PlayerSelectionView(PlayerSelectionViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}