using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpTrooper.Core;
using StarWarsTopTrumps.Engine;
using System.Collections.Generic;

namespace StarWarsTopTrumps.Tests
{
    [TestClass]
    public class GeneralTests
    {
        [TestMethod]
        public void ChoosePlayerToStart()
        {
            Player player1 = new Player();
            player1.ChoosePlayerToStart(player1);

            Assert.IsTrue(player1.ToStart);
        }

        [TestMethod]
        public void ChooseComputerToStart()
        {
            Player player1 = new Player();

            Player player2 = new Player
            {
                IsComputer = true
            };

            player1.ChoosePlayerToStart(player2);

            Assert.IsTrue(player2.ToStart && player2.IsComputer);
        }

        [TestMethod]
        public void CheckAllCardsReturned()
        {
            StarShipCard starShipCards = new StarShipCard();
            List<StarShipCard> cards = starShipCards.PopulateAllCards();

            SharpTrooperCore core = new SharpTrooperCore();

            Assert.IsTrue(cards.Count == core.GetAllStarships().count);
        }

        [TestMethod]
        [Ignore]
        public void AllCardsHaveBeenDealt()
        {
            Player player1 = new Player();
            Player player2 = new Player()
            {
                IsComputer = true
            };

            StarShipCard starshipCards = new StarShipCard();
            List<StarShipCard> cards = starshipCards.PopulateAllCards();

            StarShipCard cardsToDeal = new StarShipCard();
            cardsToDeal.Deal(player1, player2);

            int totalCardsDealt = player1.StarShipCardHand.Count + player2.StarShipCardHand.Count;

            Assert.IsTrue(cards.Count == totalCardsDealt);
        }

    }
}
