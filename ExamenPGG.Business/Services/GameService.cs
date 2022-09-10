using AutoMapper;
using ExamenPGG.Business.GameObject;
using ExamenPGG.Business.LeaderBoard;
using ExamenPGG.Business.PlayerObject;
using ExamenPGG.Data.Entities;
using ExamenPGG.Data.Repository;

namespace ExamenPGG.Business.Services
{
    public class GameService : IGameService
    {
        private IDBGameRepo _dBGameRepo;
        private IDBPlayerRepo _dbPlayerRepo;
        private Mapper gameToDBMapper;
        private Mapper PlayerToDBMapper;

        public GameService(IDBGameRepo repo, IDBPlayerRepo dbPlayerRepo)
        {
            _dBGameRepo = repo;
            _dbPlayerRepo = dbPlayerRepo;
            ConfigureGameToDB();
            ConfigurePlayerToDB();
        }

        private void ConfigurePlayerToDB()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Player, DBPlayer>());
            PlayerToDBMapper = new Mapper(config);
        }

        private void ConfigureGameToDB()
        {
            var config = new MapperConfiguration(cfg =>
                            cfg.CreateMap<Game, DBGame>()
                            .ForMember(dest => dest.ThrowsToWin, act => act.MapFrom(src => src.RoundNumber)));
            gameToDBMapper = new Mapper(config);
        }

        public async Task LogGameToDB(IGame game)
        {
            DBGame dbGame = new DBGame()
            {
                StartTime = game.StartTime,
                EndTime = game.EndTime,
                ThrowsToWin = game.RoundNumber
            };

            List<DBPlayer> dbPlayers = new List<DBPlayer>();

            foreach (var player in game.PlayerList)
            {
                dbPlayers.Add(PlayerToDBMapper.Map<DBPlayer>(player));
            }

            await _dBGameRepo.AddGame(dbGame);
            await _dbPlayerRepo.AddPlayerRangeAsync(dbPlayers);

            dbGame.PlayerList = dbPlayers;
            dbGame.Player = dbPlayers[game.CurrentplayerID];
            await _dBGameRepo.UpdateGame(dbGame);
        }

        public Task<List<ILeaderBoardPlayer>> GetTop10()
        {
            throw new NotImplementedException();
        }
    }
}