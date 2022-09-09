using ExamenPGG.Data.Entities;

namespace ExamenPGG.Data.Repository
{
    public interface IDBGameRepo
    {
        Task AddGame(DBGame game);
        Task DeleteGame(int id);
        Task<DBGame> GetGame(int id);
        Task<List<DBGame>> GetTop10();
        void UpdateGame(DBGame game);
    }
}
