namespace ExamenPGG.Data.Entities
{
    public class Game
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int ThrowsToWin { get; set; }
        public Player Winner { get; set; }
        public IList<Player> PlayerList { get; set; }

    }
}
