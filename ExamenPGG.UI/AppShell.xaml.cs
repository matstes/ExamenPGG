using ExamenPGG.UI.View;

namespace ExamenPGG.UI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(GameBoardView), typeof(GameBoardView));
        }
    }
}