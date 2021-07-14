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
            Player player1 = new ();
            player1.ChoosePlayerToStart(player1);

            Assert.IsTrue(player1.ToStart);
        }

        [TestMethod]
        public void ChooseComputerToStart()
        {
            Player player1 = new ();
            var player2 = new Player { IsComputer = true };

            player1.ChoosePlayerToStart(player2);

            Assert.IsTrue(player2.ToStart && player2.IsComputer);
        }

        [TestMethod]
        public void CheckAllCardsReturned()
        {
            StarShipCard starShipCards = new ();
            var cards = starShipCards.PopulateAllCards();

            SharpTrooperCore core = new ();

            Assert.IsTrue(cards.Count == core.GetAllStarships().count);
        }

        [TestMethod]
        [Ignore]
        public void AllCardsHaveBeenDealt()
        {
            Player player1 = new ();
            Player player2 = new () { IsComputer = true };

            StarShipCard starshipCards = new ();
            var cards = starshipCards.PopulateAllCards();

            StarShipCard cardsToDeal = new ();
            cardsToDeal.Deal(player1, player2);

            var totalCardsDealt = player1.StarShipCardHand.Count + player2.StarShipCardHand.Count;

            Assert.IsTrue(cards.Count == totalCardsDealt);
        }

    }
}
