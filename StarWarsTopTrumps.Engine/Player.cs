using System.Collections.Generic;

namespace StarWarsTopTrumps.Engine
{
    public class Player
    {
        public Player() { }

        public string Name { get; set; }

        public bool IsComputer { get; set; }

        public bool ToStart { get; set; }

        public List<StarShipCard> StarShipCardHand { get; set; }

        public Player ChoosePlayerToStart(Player player)
        {
            player.ToStart = true;
            return player;
        }
    }
}
