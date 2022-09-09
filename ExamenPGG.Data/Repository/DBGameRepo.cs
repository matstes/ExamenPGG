using ExamenPGG.Data.Data;
using ExamenPGG.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExamenPGG.Data.Repository
{
    public class DBGameRepo : IDBGameRepo
    {
        private GameOfBatsContext dbContext;
        public DBGameRepo()
        {
            dbContext = new GameOfBatsContext();
        }

        public async Task AddGame(DBGame game)
        {
            await dbContext.AddAsync(game);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteGame(int id)
        {
            Task<DBGame> gameTask = GetGame(id);
            DBGame game = await gameTask;
            dbContext.Games.Remove(game);
            await dbContext.SaveChangesAsync();
        }

        public async Task<DBGame> GetGame(int id)
        {
            var game = await dbContext.Games.FindAsync(id);
            return game;
        }

        public async Task<List<DBGame>> GetTop10()
        {
            var top10 = new List<DBGame>();
            top10 = await dbContext.Games
                          .OrderBy(p => p.ThrowsToWin)
                          .Take(10).ToListAsync();
            return top10;
        }
    }
}
