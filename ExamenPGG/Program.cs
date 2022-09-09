//using ExamenPGG.Business.Bootup;
//using ExamenPGG.Business.GameObject;
//using Microsoft.Extensions.DependencyInjection;
//using ExamenPGG.Business.Logging;
//using ExamenPGG.Business;
//using ExamenPGG.Business.PlayerObject;
//using ExamenPGG.Business.Squares;
//using ExamenPGG.Business.LeaderBoard;
//using ExamenPGG.Business.Squares.Factory;

//ServiceCollection services = new ServiceCollection();
//RegisterServices(services);

//ServiceProvider provider = services.BuildServiceProvider();
//var foo = provider.GetService<Bootstrapper>();
//provider.GetService<IBootstrapper>().Run();

//void RegisterServices(ServiceCollection services)
//{
//    // ADD SERVICES HERE
//    services.AddTransient<ILogger, Logger>();
//    services.AddTransient<IBootstrapper, Bootstrapper>();
//    services.AddTransient<IBootup, Bootup>();
//    services.AddTransient<IDice, Dice>();  // TODO INCORRECT!
//    services.AddTransient<ILeaderBoard, LeaderBoard>();
//    services.AddTransient<ISquareFactory, SquareFactory>();
//    services.AddTransient<IPlayerFactory, PlayerFactory>();

//    services.AddSingleton<IGameBoard, GameBoard>();
//}

namespace ExamenPGG
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}

