using ExamenPGG.UI.ViewModel;

namespace ExamenPGG.UI
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
    }
}