using ExamenPGG.Data.Data;
using ExamenPGG.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExamenPGG.Data.Repository
{
    public class DBPlayerRepo : IDBPlayerRepo
    {
        private GameOfBatsContext dbContext;
        public DBPlayerRepo(GameOfBatsContext context)
        {
            dbContext = context;
        }

        public async Task AddPlayerAsync(DBPlayer player)
        {
            await dbContext.Players.AddAsync(player);
            await dbContext.SaveChangesAsync();
        }

        public async Task AddPlayerRangeAsync(List<DBPlayer> players)
        {
            await dbContext.Players.AddRangeAsync(players);
            await dbContext.SaveChangesAsync();
        }
    }
}
