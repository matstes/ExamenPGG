using ExamenPGG.Data.Entities;
using System.Data.Common;

namespace ExamenPGG.Data.Repository
{
    public interface IDBPlayerRepo
    {
        Task AddPlayerAsync(DBPlayer player);
        Task AddPlayerRangeAsync(List<DBPlayer> players);
    }
}
