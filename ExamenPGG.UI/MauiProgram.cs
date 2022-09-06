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