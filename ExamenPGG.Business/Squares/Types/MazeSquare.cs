using ExamenPGG.Business.PlayerObject;

namespace ExamenPGG.Business.Squares
{
    public class MazeSquare : ISquare
    {
        public int ID { get; set; }
        public SquareType SquareType { get; set; }

        public MazeSquare(int id)
        {
            ID = id;
            SquareType = SquareType.Maze;
        }

        public void HandlePlayer(IPlayer player)
        {
            player.MoveToSquare(39);
        }
    }
}