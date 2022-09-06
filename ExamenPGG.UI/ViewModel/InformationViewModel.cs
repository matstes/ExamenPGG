using CommunityToolkit.Mvvm.ComponentModel;
using ExamenPGG.Business.GameObject;
using ExamenPGG.Business.PlayerObject;

namespace ExamenPGG.UI.ViewModel
{
    public class InformationViewModel : ObservableObject
    {
        public IGame Game { get; set; }
        public InformationViewModel(IGame game)
        {
            Game = game;

        }
    }
}
