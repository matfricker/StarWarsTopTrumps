using SharpTrooper.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StarWarsTopTrumps.Engine
{
    public class StarShipCard : Card
    {
        public StarShipCard() { }

        public string Name { get; set; }

        public decimal CostOfCredits { get; set; }

        public decimal CargoCapacity { get; set; }

        public decimal TopSpeed { get; set; }

        public decimal HyperDriveRating { get; set; }

        public decimal MGLT { get; set; }

        public decimal NumberOfFilms { get; set; }

        public decimal CrewRequired { get; set; }

        public override List<StarShipCard> PopulateAllCards()
        {
            List<StarShipCard> starShipCards = new ();
            SharpTrooperCore core = new ();

            var totalStarShips = Convert.ToDecimal(core.GetAllStarships().count);
            var pages = Convert.ToInt32(Math.Ceiling(totalStarShips / 10m));

            for (var i = 1; i <= pages; i++)
            {
                foreach (var starship in core.GetAllStarships(i.ToString()).results)
                {
                    var starShipCard = new StarShipCard
                    {
                        Name = starship.name,
                        CostOfCredits = HandleValue(starship.cost_in_credits),
                        CargoCapacity = HandleValue(starship.cargo_capacity),
                        TopSpeed = HandleValue(starship.max_atmosphering_speed),
                        HyperDriveRating = HandleValue(starship.hyperdrive_rating),
                        MGLT = HandleValue(starship.MGLT),
                        NumberOfFilms = starship.films.Count,
                        CrewRequired = HandleCrewValue(starship.crew)
                    };

                    starShipCards.Add(starShipCard);
                }
            }

            return starShipCards;
        }

        private static decimal HandleValue(string value)
        {
            if (string.IsNullOrEmpty(value) || value == "unknown" || value == "n/a")
            {
                return 0;
            }

            if (value.Contains("km"))
            {
                value = value.Replace("km", "");
            }

            return Convert.ToDecimal(value);
        }

        private static decimal HandleCrewValue(string value)
        {
            // need to handle a range
            if (value.Contains("-"))
                return GetValueFromRange(value);

            return 0;
        }

        private static int GetValueFromRange(string value, bool returnMax = true)
        {
            int max = 0;
            int min = 0;
            if (value.Contains('-'))
            {
                var range = value.Split('-');
                List<int> values = new();
                foreach (var item in range)
                {
                    values.Add(int.Parse(item));
                }

                max = values.Max();
                min = values.Min();
            }

            if (returnMax)
                return max;
            else
                return min;
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
    }
}
