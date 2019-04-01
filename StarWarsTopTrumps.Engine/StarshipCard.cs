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
            List<StarShipCard> starShipCards = new List<StarShipCard>();

            SharpTrooperCore core = new SharpTrooperCore();

            decimal totalStarships = Convert.ToDecimal(core.GetAllStarships().count);
            int pages = Convert.ToInt32(Math.Ceiling(totalStarships / 10m));

            for (int i = 1; i <= pages; i++)
            {
                foreach (Starship starship in core.GetAllStarships(i.ToString()).results)
                {
                    StarShipCard starShipCard = new StarShipCard
                    {
                        Name = starship.name,
                        CostOfCredits = starship.cost_in_credits,
                        HyperDriveRating = starship.hyperdrive_rating,
                        TopSpeed = starship.MGLT,
                        NumberOfFilms = starship.films.Count.ToString(),
                        CrewRequired = starship.crew
                    };

                    starShipCards.Add(starShipCard);
                }
            }

            return starShipCards;
        }

        public override void Deal(Player player1, Player player2)
        {
            bool skip = false;
            List<StarShipCard> cards = PopulateAllCards();
            List<StarShipCard> shuffledcards = ShuffleCards(cards);

            player1.StarShipCardHand = new List<StarShipCard>();
            player2.StarShipCardHand = new List<StarShipCard>();

            foreach (StarShipCard card in shuffledcards)
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
            Random random = new Random();
            return cards.OrderBy(item => random.Next()).ToList();
        }

        public HandResult CompareAttributes(string playerValue, string computerValue, StarshipAttributes attribute)
        {
            if (playerValue == "unknown" && computerValue != "unknown")
            {
                return HandResult.Win;
            }

            if (playerValue != "unknown" && computerValue == "unknown")
            {
                return HandResult.Lose;
            }

            if (playerValue == "unknown" && computerValue == "unknown")
            {
                return HandResult.Draw;
            }

            switch (attribute)
            {
                case StarshipAttributes.CostOfCredits:
                case StarshipAttributes.TopSpeed:
                case StarshipAttributes.NumberOfFilms:
                case StarshipAttributes.CrewRequired:

                    if (Convert.ToInt32(playerValue) == Convert.ToInt32(computerValue))
                        return HandResult.Draw;
                    else if (Convert.ToInt32(playerValue) > Convert.ToInt32(computerValue))
                        return HandResult.Win;
                    else
                        return HandResult.Lose;

                case StarshipAttributes.HyperDriveRating:

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
