using ExamenPGG.Data.Data;
using ExamenPGG.Data.Entities;

namespace ExamenPGG.Data.Repository
{
    public class DBPlayerRepo : IDBPlayerRepo
    {
        private GameOfBatsContext dbContext;
        public DBPlayerRepo()
        {
            dbContext = new();
        }

        public async Task AddPlayer(DBPlayer player)
        {
            await dbContext.Players.AddAsync(player);
            await dbContext.SaveChangesAsync();
        }
    }
}
