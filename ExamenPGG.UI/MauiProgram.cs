using ExamenPGG.Business.Bootup;
using ExamenPGG.Business.GameObject;
using ExamenPGG.Business.LeaderBoard;
using ExamenPGG.Business.Squares.Factory;
using ExamenPGG.Business.Squares;
using ExamenPGG.Business;
using ExamenPGG.UI.View;
using ExamenPGG.UI.ViewModel;
using ExamenPGG.Business.Logging;

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

            builder.Services.AddTransient<ILogger, Logger>();
            builder.Services.AddTransient<IBootstrapper, Bootstrapper>();
            builder.Services.AddTransient<IBootup, Bootup>();
            builder.Services.AddTransient<IDice, Dice>();  // TODO INCORRECT!
            builder.Services.AddTransient<ILeaderBoard, LeaderBoard>();
            builder.Services.AddTransient<ISquareFactory, SquareFactory>();
            builder.Services.AddTransient<IPlayerFactory, PlayerFactory>();

            builder.Services.AddSingleton<IGameBoard, GameBoard>();

            builder.Services.AddSingleton<PlayerSelectionView>();
            builder.Services.AddSingleton<PlayerSelectionViewModel>();

            builder.Services.AddTransient<MainPage>();
            return builder.Build();
        }
    }
}