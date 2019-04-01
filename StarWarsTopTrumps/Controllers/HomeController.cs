using Microsoft.AspNetCore.Mvc;
using StarWarsTopTrumps.Engine;
using StarWarsTopTrumps.Models;
using System.Diagnostics;
using Newtonsoft.Json;
using System;

namespace StarWarsTopTrumps.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            Player player1 = new Player()
            {
                Name = "Player 1"
            };

            Player player2 = new Player
            {
                Name = "Computer",
                IsComputer = true
            };

            GameData gameData = new GameData
            {
                Player1 = player1,
                Player2 = player2
            };

            TempData["GameData"] = JsonConvert.SerializeObject(gameData);

            return View(gameData);
        }

        public IActionResult Start(int player, string result, string message)
        {
            GameData gameData = JsonConvert.DeserializeObject<GameData>(TempData["GameData"].ToString());

            if (player != 0)
            {
                if (player == 1)
                {
                    gameData.Player1.ToStart = true;
                }

                if (player == 2)
                {
                    gameData.Player2.ToStart = true;
                }

                StarShipCard cardsToDeal = new StarShipCard();
                cardsToDeal.Deal(gameData.Player1, gameData.Player2);
                gameData.CardsDealt = true;

            }

            if (result != null)
            {
                switch(result.ToLower())
                {
                    case "draw":
                        gameData.HandResult = HandResult.Draw;
                        break;
                    case "win":
                        gameData.HandResult = HandResult.Win;
                        break;
                    case "lose":
                        gameData.HandResult = HandResult.Lose;
                        break;
                }
            }

            if (message != null)
            {
                gameData.HandMessage = message;
            }

            TempData["GameData"] = JsonConvert.SerializeObject(gameData);

            return View(gameData);
        }

        public IActionResult CompareAttributes(string attr)
        {
            GameData gameData = JsonConvert.DeserializeObject<GameData>(TempData["GameData"].ToString());

            string message = string.Empty;
            HandResult result;

            StarShipCard cards = new StarShipCard();

            switch (attr)
            {
                case "cost":
                    result = cards.CompareAttributes(gameData.Player1.StarShipCardHand[0].CostOfCredits,
                                                     gameData.Player2.StarShipCardHand[0].CostOfCredits,
                                                     StarshipAttributes.CostOfCredits);

                    if (result.Equals(HandResult.Win))
                    {
                        message = string.Format("Played cost of credits, {0} beats {1}", gameData.Player1.StarShipCardHand[0].CostOfCredits, gameData.Player2.StarShipCardHand[0].CostOfCredits);
                    }

                    if (result.Equals(HandResult.Lose))
                    {
                        message = string.Format("Played cost of credits, {0} beats {1}", gameData.Player2.StarShipCardHand[0].CostOfCredits, gameData.Player1.StarShipCardHand[0].CostOfCredits);
                    }

                        break;
                case "hyperdrive":
                    result = cards.CompareAttributes(gameData.Player1.StarShipCardHand[0].HyperDriveRating,
                                                     gameData.Player2.StarShipCardHand[0].HyperDriveRating,
                                                     StarshipAttributes.HyperDriveRating);

                    if (result.Equals(HandResult.Win))
                    {
                        message = string.Format("Played hyperdrive rating, {0} beats {1}", gameData.Player1.StarShipCardHand[0].HyperDriveRating, gameData.Player2.StarShipCardHand[0].HyperDriveRating);
                    }

                    if (result.Equals(HandResult.Lose))
                    {
                        message = string.Format("Played hyperdrive rating, {0} beats {1}", gameData.Player2.StarShipCardHand[0].HyperDriveRating, gameData.Player1.StarShipCardHand[0].HyperDriveRating);
                    }

                    break;
                case "speed":
                    result = cards.CompareAttributes(gameData.Player1.StarShipCardHand[0].TopSpeed,
                                                     gameData.Player2.StarShipCardHand[0].TopSpeed,
                                                     StarshipAttributes.TopSpeed);

                    if (result.Equals(HandResult.Win))
                    {
                        message = string.Format("Played top speed, {0} beats {1}", gameData.Player1.StarShipCardHand[0].TopSpeed, gameData.Player2.StarShipCardHand[0].TopSpeed);
                    }

                    if (result.Equals(HandResult.Lose))
                    {
                        message = string.Format("Played top speed, {0} beats {1}", gameData.Player2.StarShipCardHand[0].TopSpeed, gameData.Player1.StarShipCardHand[0].TopSpeed);
                    }

                    break;
                case "films":
                    result = cards.CompareAttributes(gameData.Player1.StarShipCardHand[0].NumberOfFilms,
                                                     gameData.Player2.StarShipCardHand[0].NumberOfFilms,
                                                     StarshipAttributes.NumberOfFilms);

                    if (result.Equals(HandResult.Win))
                    {
                        message = string.Format("Played number of films, {0} beats {1}", gameData.Player1.StarShipCardHand[0].NumberOfFilms, gameData.Player2.StarShipCardHand[0].NumberOfFilms);
                    }

                    if (result.Equals(HandResult.Lose))
                    {
                        message = string.Format("Played number of films, {0} beats {1}", gameData.Player2.StarShipCardHand[0].NumberOfFilms, gameData.Player1.StarShipCardHand[0].NumberOfFilms);
                    }

                    break;
                case "crew":

                    result = cards.CompareAttributes(gameData.Player1.StarShipCardHand[0].CrewRequired,
                                                     gameData.Player2.StarShipCardHand[0].CrewRequired,
                                                     StarshipAttributes.CrewRequired);

                    if (result.Equals(HandResult.Win))
                    {
                        message = string.Format("Played crew required, {0} beats {1}", gameData.Player1.StarShipCardHand[0].CrewRequired, gameData.Player2.StarShipCardHand[0].CrewRequired);
                    }

                    if (result.Equals(HandResult.Lose))
                    {
                        message = string.Format("Played crew required, {0} beats {1}", gameData.Player2.StarShipCardHand[0].CrewRequired, gameData.Player1.StarShipCardHand[0].CrewRequired);
                    }

                    break;
                default:
                    throw new Exception("Invalid attribute");
            }

            TempData["GameData"] = JsonConvert.SerializeObject(gameData);

            return RedirectToAction("start", new { result = result.ToString().ToLower(), message });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
