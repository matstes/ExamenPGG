using ExamenPGG.Data.Entities;

namespace ExamenPGG.Data.Repository
{
    public interface IDBPlayerRepo
    {
        Task AddPlayerAsync(DBPlayer player);

        Task AddPlayerRangeAsync(List<DBPlayer> players);
    }
}