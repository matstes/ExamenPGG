using ExamenPGG.Business.PlayerObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenPGG.Business.Squares.Types
{
    public class Bat : Standard, ISquare
    {
        public Bat(int id) : base(id)
        {
            ID = id;
            SquareType = SquareType.Bat;
        }

        public override void HandlePlayer(IPlayer player)
        {
            Console.WriteLine($"Player {player.Name} entered squareID: {ID}");
        }
    }
}
