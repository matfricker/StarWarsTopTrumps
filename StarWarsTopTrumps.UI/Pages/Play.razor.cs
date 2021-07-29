using StarWarsTopTrumps.Engine;
using System.Threading.Tasks;

namespace StarWarsTopTrumps.UI.Pages
{
    public partial class Play
    {
        private bool Loading;
        private GameData GameData { get; set; }
        private Player Player1 { get; set; }
        private Player Player2 { get; set; }

        protected override void OnInitialized()
        {
            Loading = true;

            Player1 = new Player { Name = "Player 1" };
            Player2 = new Player { Name = "Player 2", IsComputer = true };

            GameData = new GameData()
            {
                Player1 = Player1,
                Player2 = Player2
            };

            GameData.Player1.ToStart = true;

            StarShipCard cards = new();
            cards.Deal(GameData.Player1, GameData.Player2);
            GameData.CardsDealt = true;

            Loading = false;
        }
    }
}
