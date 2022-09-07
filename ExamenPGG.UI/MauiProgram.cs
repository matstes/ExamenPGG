using ExamenPGG.Business;
using ExamenPGG.Business.Bootup;
using ExamenPGG.Business.GameObject;
using ExamenPGG.Business.LeaderBoard;
using ExamenPGG.Business.Logging;
using ExamenPGG.Business.Factory;
using ExamenPGG.UI.View;
using ExamenPGG.UI.ViewModel;

namespace ExamenPGG.UI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            //business layer dependencies
            builder.Services.AddTransient<ILogger, Logger>();
            builder.Services.AddTransient<IBootstrapper, Bootstrapper>();
            builder.Services.AddTransient<IBootup, Bootup>();
            builder.Services.AddTransient<IDice, Dice>();  // TODO INCORRECT!
            builder.Services.AddTransient<ILeaderBoard, LeaderBoard>();
            builder.Services.AddTransient<ISquareFactory, SquareFactory>();
            builder.Services.AddTransient<IPlayerFactory, PlayerFactory>();

            builder.Services.AddSingleton<IGameBoard, GameBoard>();
            builder.Services.AddSingleton<IGame, Game>();

            //pages
            builder.Services.AddTransient<MainViewModel>();
            builder.Services.AddTransient<InformationViewModel>();
            builder.Services.AddTransient<GameControlViewModel>();
            builder.Services.AddTransient<GameBoardViewModel>();
            builder.Services.AddTransient<PlayerSelectionViewModel>();

            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<InformationView>();
            builder.Services.AddTransient<GameControlView>();
            builder.Services.AddTransient<GameBoardView>();
            builder.Services.AddTransient<PlayerSelectionView>();

            return builder.Build();
        }
    }
}