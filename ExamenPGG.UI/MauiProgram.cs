using ExamenPGG.Business.Bootup;
using ExamenPGG.Business.Factory;
using ExamenPGG.Business.GameObject;
using ExamenPGG.Business.Logging;
using ExamenPGG.Business.Services;
using ExamenPGG.Data.Data;
using ExamenPGG.Data.Repository;
using ExamenPGG.UI.View;
using ExamenPGG.UI.ViewModel;
using Microsoft.EntityFrameworkCore;
using Plugin.Maui.Audio;

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
                    fonts.AddFont("Mistral.ttf", "Mistral");
                });

            //business layer dependencies
            builder.Services.AddSingleton<ILogger, FileLogger>();
            builder.Services.AddTransient<IBootstrapper, Bootstrapper>();
            builder.Services.AddTransient<IBootup, Bootup>();
            builder.Services.AddTransient<ISquareFactory, SquareFactory>();
            builder.Services.AddTransient<IPlayerFactory, PlayerFactory>();
            builder.Services.AddTransient<IDiceFactory, DiceFactory>();

            builder.Services.AddSingleton<IGameBoard, GameBoard>();
            builder.Services.AddSingleton<IGame, Game>();

            //Database
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "GameOfBatsDB.db");
            builder.Services.AddDbContext<GameOfBatsContext>(options => options.UseSqlite($"Filename={dbPath}"));
            builder.Services.AddTransient<IDBGameRepo, DBGameRepo>();
            builder.Services.AddTransient<IDBPlayerRepo, DBPlayerRepo>();
            builder.Services.AddTransient<IGameService, GameService>();

            //pages
            
            builder.Services.AddTransient<MainViewModel>();
            builder.Services.AddTransient<InformationViewModel>();
            builder.Services.AddTransient<GameControlViewModel>();
            builder.Services.AddTransient<GameBoardViewModel>();
            builder.Services.AddTransient<PlayerSelectionViewModel>();
            builder.Services.AddTransient<GameRulesViewModel>();
            builder.Services.AddTransient<EndGameViewModel>();
            builder.Services.AddTransient<LeaderBoardViewModel>();
            builder.Services.AddTransient<StartupViewModel>();
                                
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<InformationView>();
            builder.Services.AddTransient<GameControlView>();
            builder.Services.AddTransient<GameBoardView>();
            builder.Services.AddTransient<PlayerSelectionView>();
            builder.Services.AddTransient<GameRulesView>();
            builder.Services.AddTransient<EndGameView>();
            builder.Services.AddTransient<LeaderBoardView>();
            builder.Services.AddTransient<StartupView>();

            //audio
            builder.Services.AddSingleton(AudioManager.Current);

            return builder.Build();
        }
    }
}