using System.Collections.Generic;

namespace StarWarsTopTrumps.Engine
{
    public abstract class Card
    {
        public abstract List<StarShipCard> PopulateAllCards();

        public abstract void Deal(Player player1, Player player2);

        public abstract List<StarShipCard> ShuffleCards(List<StarShipCard> cards);
    }
}
