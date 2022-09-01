namespace ExamenPGG.UI.Model
{
    public class PlayerChoice
    {
        public PlayerChoice(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
        public int Icon { get; set; }
        public bool IsBot { get; set; }
    }
}
