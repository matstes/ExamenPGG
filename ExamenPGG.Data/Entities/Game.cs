using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamenPGG.Data.Entities
{
    public class Game
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

        [ForeignKey("WinnerId")]
        public Player Player { get; set; }

        [Required]
        public IList<Player> PlayerList { get; set; }
    }
}