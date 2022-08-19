using ExamenPGG.Business.PlayerObject;

namespace ExamenPGG.Business.Squares
{
    public class Maze : BaseSquare, ISquare
    {
        public Maze(int id) : base(id)
        {
            ID = id;
            SquareType = SquareType.Maze;
        }

        public override void HandlePlayer(IPlayer player)
        {
            player.MoveToSquare(39);
        }
    }
}