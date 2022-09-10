using ExamenPGG.Data.Data;
using ExamenPGG.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExamenPGG.Data.Repository
{
    public class DBPlayerRepo : IDBPlayerRepo
    {
        private GameOfBatsContext dbContext;
        public DBPlayerRepo()
        {
            dbContext = new();
            dbContext.Database.Migrate();
        }

        public async Task AddPlayer(DBPlayer player)
        {
            await dbContext.Players.AddAsync(player);
            await dbContext.SaveChangesAsync();
        }
    }
}
