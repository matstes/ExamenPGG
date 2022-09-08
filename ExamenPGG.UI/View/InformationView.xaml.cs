using ExamenPGG.UI.ViewModel;

namespace ExamenPGG.UI.View;

public partial class InformationView : ContentView
{
	public InformationView(InformationViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
    }
}