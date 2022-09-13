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

using ExamenPGG.Data.Data;
using ExamenPGG.Data.Entities;
using ExamenPGG.Data.Repository;
using Microsoft.EntityFrameworkCore;

namespace ExamenPGG
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            DbContextOptions<GameOfBatsContext> options = new DbContextOptions<GameOfBatsContext>();
            GameOfBatsContext context = new GameOfBatsContext(options);

            DBGameRepo _dBGameRepo = new(context);
            DBPlayerRepo _dBPlayerRepo = new(context);

            List<DBPlayer> dbList = new List<DBPlayer>();

            dbList.Add(new DBPlayer()
            {
                Name = "P1",
                IconPath = "Whocares"
            });

            dbList.Add(new DBPlayer()
            {
                Name = "P2",
                IconPath = "Whocares"
            });

            dbList.Add(new DBPlayer()
            {
                Name = "P3",
                IconPath = "Whocares"
            });

            dbList.Add(new DBPlayer()
            {
                Name = "P4",
                IconPath = "Whocares"
            });

            dbList.Add(new DBPlayer()
            {
                Name = "Jeffrey Beezos",
                IconPath = "Whocares"
            });

            var game = new DBGame()
            {
                StartTime = DateTime.Now,
                EndTime = DateTime.Now,
                ThrowsToWin = 4
            };

            await _dBGameRepo.AddGame(game);

            foreach (var player in dbList)
            {
                await _dBPlayerRepo.AddPlayerAsync(player);
            }

            game.Player = dbList[1];
            game.PlayerList = dbList;

            _dBGameRepo.UpdateGame(game);

            List<DBGame> top10 = _dBGameRepo.GetTop10().Result;
            Console.ReadKey();
        }
    }
}