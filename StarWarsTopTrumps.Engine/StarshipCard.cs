using SharpTrooper.Core;
using SharpTrooper.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StarWarsTopTrumps.Engine
{
    public class StarShipCard : Card
    {
        public StarShipCard() { }

        public string Name { get; set; }

        public string CostOfCredits { get; set; }

        public string HyperDriveRating { get; set; }

        public string TopSpeed { get; set; }

        public string NumberOfFilms { get; set; }

        public string CrewRequired { get; set; }

        public override List<StarShipCard> PopulateAllCards()
        {
            List<StarShipCard> starShipCards = new ();

            SharpTrooperCore core = new ();

            var totalStarShips = Convert.ToDecimal(core.GetAllStarships().count);
            var pages = Convert.ToInt32(Math.Ceiling(totalStarShips / 10m));

            for (var i = 1; i <= pages; i++)
            {
                foreach (var starShip in core.GetAllStarships(i.ToString()).results)
                {
                    var starShipCard = new StarShipCard
                    {
                        Name = starShip.name,
                        CostOfCredits = starShip.cost_in_credits,
                        HyperDriveRating = starShip.hyperdrive_rating,
                        TopSpeed = starShip.MGLT,
                        NumberOfFilms = starShip.films.Count.ToString(),
                        CrewRequired = starShip.crew
                    };

                    starShipCards.Add(starShipCard);
                }
            }

            return starShipCards;
        }

        public override void Deal(Player player1, Player player2)
        {
            var skip = false;
            var cards = PopulateAllCards();
            var shuffleCards = ShuffleCards(cards);

            player1.StarShipCardHand = new List<StarShipCard>();
            player2.StarShipCardHand = new List<StarShipCard>();

            foreach (var card in shuffleCards)
            {
                if (skip)
                {
                    player1.StarShipCardHand.Add(card);
                    skip = false;
                }
                else
                {
                    player2.StarShipCardHand.Add(card);
                    skip = true;
                }
            }
        }

        public override List<StarShipCard> ShuffleCards(List<StarShipCard> cards)
        {
            var random = new Random();
            return cards.OrderBy(item => random.Next()).ToList();
        }

        public HandResult CompareAttributes(string playerValue, string computerValue, StarShipAttributes attribute)
        {
            if (playerValue == "unknown" && computerValue != "unknown")
            {
                return HandResult.Lose;
            }

            if (playerValue != "unknown" && computerValue == "unknown")
            {
                return HandResult.Win;
            }

            if (playerValue == "unknown" && computerValue == "unknown")
            {
                return HandResult.Draw;
            }

            switch (attribute)
            {
                case StarShipAttributes.CostOfCredits:
                case StarShipAttributes.TopSpeed:
                case StarShipAttributes.NumberOfFilms:
                case StarShipAttributes.CrewRequired:

                    if (Convert.ToInt32(playerValue) == Convert.ToInt32(computerValue))
                        return HandResult.Draw;
                    else if (Convert.ToInt32(playerValue) > Convert.ToInt32(computerValue))
                        return HandResult.Win;
                    else
                        return HandResult.Lose;

                case StarShipAttributes.HyperDriveRating:

                    if (Convert.ToDecimal(playerValue) == Convert.ToDecimal(computerValue))
                        return HandResult.Draw;
                    else if (Convert.ToDecimal(playerValue) > Convert.ToDecimal(computerValue))
                        return HandResult.Win;
                    else
                        return HandResult.Lose;

                default:
                    throw new Exception("Invalid attribute");
            }

        }
    }
}
