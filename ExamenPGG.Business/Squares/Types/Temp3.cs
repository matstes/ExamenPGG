﻿using ExamenPGG.Business.PlayerObject;

namespace ExamenPGG.Business.Squares.Types
{
    public class Temp3 : Standard, ISquare
    {
        public Temp3(int id) : base(id)
        {
            ID = id;
            SquareType = SquareType.Temp3;
        }

        public override void HandlePlayer(IPlayer player)
        {
            Console.WriteLine($"Player {player.Name} entered squareID: {ID}");
        }
    }
}