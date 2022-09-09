using ExamenPGG.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExamenPGG.Data.Data
{
    public class GameOfBatsContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(connectionString: "FileName=GameOfBatsDB");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
