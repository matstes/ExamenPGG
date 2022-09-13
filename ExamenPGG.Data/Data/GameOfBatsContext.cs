using ExamenPGG.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExamenPGG.Data.Data
{
    public class GameOfBatsContext : DbContext
    {
        public DbSet<DBGame> Games { get; set; }
        public DbSet<DBPlayer> Players { get; set; }

        public GameOfBatsContext(DbContextOptions<GameOfBatsContext> options) : base(options)
        {
            this.Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}