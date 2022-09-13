using CommunityToolkit.Mvvm.ComponentModel;

namespace ExamenPGG.UI.Model
{
    public partial class PlayerChoice : ObservableObject
    {
        public PlayerChoice(string name, IList<String> iconList)
        {
            Name = name;
            IconList = iconList;
            Icon = IconList[0];
        }

        [ObservableProperty]
        public string name;

        [ObservableProperty]
        public string icon;

        [ObservableProperty]
        public bool isBot;

        public IList<String> IconList { get; set; }
    }
}