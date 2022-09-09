using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamenPGG.Data.Entities
{
    public class DBGame
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int ThrowsToWin { get; set; }

        [ForeignKey("WinnerID")]
        public DBPlayer Player { get; set; }

        [Required]
        public IList<DBPlayer> PlayerList { get; set; }
    }
}