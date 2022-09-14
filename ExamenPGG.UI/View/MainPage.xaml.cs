using ExamenPGG.UI.View;
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

        //private async void Label_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        //{
        //    if (!(sender as Label).IsVisible)
        //    {
        //    await GoToEndGameAsync();
        //    }
        //}

        private void Label_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (!(sender as Label).IsVisible)
            {
                GoToEndGameAsync();
            }
        }


        //private async Task GoToEndGameAsync()
        //{
        //    await Shell.Current.GoToAsync($"{nameof(EndGameView)}");
        //}

        private void GoToEndGameAsync()
        {
            // Async Navigation Causes Strange behaviour and crashes
            Shell.Current.GoToAsync($"{nameof(EndGameView)}");
        }



    }
}