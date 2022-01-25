using System.Collections.Generic;

namespace StarWarsTopTrumps.Engine
{
    public class Player
    {
        public Player() { }

        public string Name { get; set; }

        public int Score { get; set; }

        public bool IsComputer { get; set; }

        public bool ToStart { get; set; }

        public List<StarShipCard> StarShipCardHand { get; set; }
    }
}
