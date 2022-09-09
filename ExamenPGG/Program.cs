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

using ExamenPGG.Data.Entities;
using ExamenPGG.Data.Repository;

namespace ExamenPGG
{
    class Program
    {
        static async Task Main(string[] args)
        {
            if (!File.Exists("GameOfBatsDB"))
            {
                File.Create("GameOfBatsDB");
            }

            DBGameRepo _dBGameRepo = new();
            DBPlayerRepo _dBPlayerRepo = new();

            List<DBPlayer> dbList = new List<DBPlayer>();

                dbList.Add(new DBPlayer()
                {
                    Name =  "Jef",
                    IconPath = "Whocares"
                });

            dbList.Add(new DBPlayer()
            {
                Name = "Jof",
                IconPath = "Whocares"
            });

            dbList.Add(new DBPlayer()
            {
                Name = "Jaf",
                IconPath = "Whocares"
            });

            DBPlayer winner = dbList[1];

            var game = new DBGame()
            {
                StartTime = DateTime.Now,
                EndTime = DateTime.Now,
                ThrowsToWin = 12
            };

            await _dBGameRepo.AddGame(game);

            foreach (var player in dbList)
            {
                await _dBPlayerRepo.AddPlayer(player);
            }

            game.Player = dbList[1];
            game.PlayerList = dbList;

            _dBGameRepo.UpdateGame(game);
        }
    }
}

