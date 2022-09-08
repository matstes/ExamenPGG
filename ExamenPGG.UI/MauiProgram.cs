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
            builder.Services.AddSingleton<ILogger, FileLogger>();
            builder.Services.AddTransient<IBootstrapper, Bootstrapper>();
            builder.Services.AddTransient<IBootup, Bootup>();
            builder.Services.AddTransient<IDice, Dice>();  // TODO INCORRECT!
            builder.Services.AddTransient<ILeaderBoard, LeaderBoard>();
            builder.Services.AddTransient<ISquareFactory, SquareFactory>();
            builder.Services.AddTransient<IPlayerFactory, PlayerFactory>();

            builder.Services.AddSingleton<IGameBoard, GameBoard>();
            builder.Services.AddSingleton<IGame, Game>();

            //pages
            builder.Services.AddTransient<PlayerSelectionView>();
            builder.Services.AddTransient<PlayerSelectionViewModel>();

            builder.Services.AddSingleton<MainViewModel>();
            builder.Services.AddSingleton<InformationViewModel>();
            builder.Services.AddSingleton<GameControlViewModel>();
            builder.Services.AddSingleton<GameBoardViewModel>();

            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<InformationView>();
            builder.Services.AddSingleton<GameControlView>();
            builder.Services.AddSingleton<GameBoardView>();
            return builder.Build();
        }
    }
}