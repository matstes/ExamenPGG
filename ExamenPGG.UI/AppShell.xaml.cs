using ExamenPGG.UI.View;

namespace ExamenPGG.UI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(MainPage           ), typeof(MainPage           ));
            Routing.RegisterRoute(nameof(GameRulesView      ), typeof(GameRulesView      ));
            Routing.RegisterRoute(nameof(EndGameView        ), typeof(EndGameView        ));
            Routing.RegisterRoute(nameof(PlayerSelectionView), typeof(PlayerSelectionView));
            Routing.RegisterRoute(nameof(LeaderBoardView    ), typeof(LeaderBoardView    ));
        }
    }
}