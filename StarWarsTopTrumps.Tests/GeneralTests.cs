using SharpTrooper.Core;
using StarWarsTopTrumps.Engine;
using Xunit;

namespace StarWarsTopTrumps.Tests
{
    public class GeneralTests
    {
        [Fact]
        public void ChoosePlayerToStart()
        {
            Player player1 = new();
            player1.ChoosePlayerToStart(player1);

            Assert.True(player1.ToStart);
        }

        [Fact]
        public void ChooseComputerToStart()
        {
            Player player1 = new();
            var player2 = new Player { IsComputer = true };

            player1.ChoosePlayerToStart(player2);

            Assert.True(player2.ToStart && player2.IsComputer);
        }

        [Fact]
        public void CheckAllCardsReturned()
        {
            StarShipCard starShipCards = new();
            var cards = starShipCards.PopulateAllCards();

            SharpTrooperCore core = new();

            Assert.True(cards.Count == core.GetAllStarships().count);
        }

        [Fact]
        public void AllCardsHaveBeenDealt()
        {
            Player player1 = new();
            Player player2 = new() { IsComputer = true };

            StarShipCard starshipCards = new();
            var cards = starshipCards.PopulateAllCards();

            StarShipCard cardsToDeal = new();
            cardsToDeal.Deal(player1, player2);

            var totalCardsDealt = player1.StarShipCardHand.Count + player2.StarShipCardHand.Count;

            Assert.True(cards.Count == totalCardsDealt);
        }
    }
}
