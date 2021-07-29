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
            Player player1 = new ()
            {
                Name = "Player 1"
            };

            var player2 = new Player
            {
                Name = "Player 2",
                IsComputer = true
            };

            var gameData = new GameData
            {
                Player1 = player1,
                Player2 = player2
            };

            TempData["GameData"] = JsonConvert.SerializeObject(gameData);

            return View(gameData);
        }

        public IActionResult Play(int player, string result, string message, bool nextCard = false)
        {
            var gameData = JsonConvert.DeserializeObject<GameData>(TempData["GameData"].ToString());

            if (nextCard)
            {
                gameData.HandMessage = string.Empty;
                gameData.HandResult = HandResult.None;
            }

            if (player != 0)
            {
                switch (player)
                {
                    case 1:
                        gameData.Player1.ToStart = true;
                        break;
                    case 2:
                        gameData.Player2.ToStart = true;
                        break;
                }

                if (nextCard)
                {
                    if (gameData.Player1.StarShipCardHand.Count > 1 && gameData.Player2.StarShipCardHand.Count > 1)
                    {
                        gameData.Player1.StarShipCardHand.RemoveAt(0);
                        gameData.Player2.StarShipCardHand.RemoveAt(0);
                    }
                    else
                    {
                        var draw = gameData.Player1.Score == gameData.Player2.Score;
                        var winner = false;
                        if (!draw)
                        {
                            winner = gameData.Player1.Score > gameData.Player2.Score;
                        }

                        return RedirectToAction("EndGame", new { winner, draw });
                    }
                }
                else
                {
                    StarShipCard cardsToDeal = new();
                    cardsToDeal.Deal(gameData.Player1, gameData.Player2);
                    gameData.CardsDealt = true;
                }
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
                        gameData.Player1.Score += 1;
                        break;
                    case "lose":
                        gameData.HandResult = HandResult.Lose;
                        gameData.Player2.Score += 1;
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

        public IActionResult EndGame(bool winner, bool draw)
        {
            if (draw)
                ViewBag.Message = "It's a draw.";
            else
                ViewBag.Message = winner ? "Player 1 Wins" : "Player 2 Wins";
            
            return View();
        }

        public IActionResult CompareAttributes(StarShipAttributes attribute)
        {
            var gameData = JsonConvert.DeserializeObject<GameData>(TempData["GameData"].ToString());
            string player1Value;
            string player2Value;
            string message;
            HandResult result;
            StarShipCard cards = new ();

            switch (attribute)
            {
                case StarShipAttributes.CostOfCredits:
                    player1Value = gameData.Player1.StarShipCardHand[0].CostOfCredits;
                    player2Value = gameData.Player2.StarShipCardHand[0].CostOfCredits;
                    result = cards.CompareAttributes(player1Value, player2Value, attribute);
                    message = GetResultMessage(result, "Played cost of credits, {0} beats {1}", player1Value, player2Value);
                    break;
                case StarShipAttributes.CargoCapacity:
                    player1Value = gameData.Player1.StarShipCardHand[0].CargoCapacity;
                    player2Value = gameData.Player2.StarShipCardHand[0].CargoCapacity;
                    result = cards.CompareAttributes(player1Value, player2Value, attribute);
                    message = GetResultMessage(result, "Played cargo-capacity rating, {0} beats {1}", player1Value, player2Value);
                    break;
                case StarShipAttributes.TopSpeed:
                    player1Value = gameData.Player1.StarShipCardHand[0].TopSpeed;
                    player2Value = gameData.Player2.StarShipCardHand[0].TopSpeed;
                    result = cards.CompareAttributes(player1Value, player2Value, attribute);
                    message = GetResultMessage(result, "Played top speed, {0} beats {1}", player1Value, player2Value);
                    break;
                case StarShipAttributes.NumberOfFilms:
                    player1Value = gameData.Player1.StarShipCardHand[0].NumberOfFilms;
                    player2Value = gameData.Player2.StarShipCardHand[0].NumberOfFilms;
                    result = cards.CompareAttributes(player1Value, player2Value, attribute);
                    message = GetResultMessage(result, "Played number of films, {0} beats {1}", player1Value, player2Value);
                    break;
                case StarShipAttributes.CrewRequired:
                    player1Value = gameData.Player1.StarShipCardHand[0].CrewRequired;
                    player2Value = gameData.Player2.StarShipCardHand[0].CrewRequired;
                    result = cards.CompareAttributes(player1Value, player2Value, attribute);
                    message = GetResultMessage(result, "Played crew required, {0} beats {1}", player1Value, player2Value);
                    break;
                default:
                    throw new Exception("Invalid attribute");
            }

            TempData["GameData"] = JsonConvert.SerializeObject(gameData);

            return RedirectToAction("play", new { result, message });
        }

        private static string GetResultMessage(HandResult result, string message, string player1Value, string player2Value)
        {
            switch (result)
            {
                case HandResult.Win:
                    return string.Format(message, player1Value, player2Value);
                case HandResult.Lose:
                    return string.Format(message, player2Value, player1Value);
                default:
                    return string.Empty;
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
