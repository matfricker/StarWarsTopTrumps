using System;
using StarWarsTopTrumps.Engine;
using Microsoft.AspNetCore.Components.Web;
using StarWarsTopTrumps.Engine.libraries;
using System.Linq;
using System.Collections.Generic;

namespace StarWarsTopTrumps.UI.Pages
{
    public partial class Play
    {
        private bool _loading;
        private GameData GameData { get; set; }
        private Player Player1 { get; set; }
        private Player Player2 { get; set; }

        protected override void OnInitialized()
        {
            _loading = true;

            Player1 = new Player { Name = "Player" };
            Player2 = new Player { Name = "Computer", IsComputer = true };

            GameData = new GameData()
            {
                Player1 = Player1,
                Player2 = Player2,
                Hand = new Hand()
            };

            GameData.Player1.ToStart = true;

            StarShipCard cards = new();
            cards.Deal(GameData.Player1, GameData.Player2);
            GameData.CardsDealt = true;

            _loading = false;
        }

        private void CompareAttributes(MouseEventArgs e, string attribute)
        {
            var playerOneHand = GameData.Player1.StarShipCardHand[0];
            var playerTwoHand = GameData.Player2.StarShipCardHand[0];

            switch (Enum.Parse<StarShipAttributes>(attribute))
            {
                case StarShipAttributes.CostOfCredits:
                    CompareValues(playerOneHand.CostOfCredits, playerTwoHand.CostOfCredits);
                    break;
                case StarShipAttributes.CargoCapacity:
                    CompareValues(playerOneHand.CargoCapacity, playerTwoHand.CargoCapacity);
                    break;
                case StarShipAttributes.TopSpeed:
                    CompareValues(playerOneHand.TopSpeed, playerTwoHand.TopSpeed);
                    break;
                case StarShipAttributes.NumberOfFilms:
                    CompareValues(playerOneHand.NumberOfFilms, playerTwoHand.NumberOfFilms);
                    break;
                case StarShipAttributes.CrewRequired:
                    CompareValues(playerOneHand.CrewRequired, playerTwoHand.CrewRequired);
                    break;
            }
        }

        private void NextCards(MouseEventArgs e)
        {
            GameData.Hand.HandResult = HandResult.None;
            GameData.Hand.Message = string.Empty;

            if (GameData.Player1.StarShipCardHand.Count > 1 && GameData.Player2.StarShipCardHand.Count > 1)
            {
                GameData.Player1.StarShipCardHand.RemoveAt(0);
                GameData.Player2.StarShipCardHand.RemoveAt(0);
            }
            else
            {
                string result;
                if (GameData.Player1.Score == GameData.Player2.Score)
                {
                    result = "It's a draw.";
                }
                else if (GameData.Player1.Score > GameData.Player2.Score)
                {
                    result = "Winner.";
                }
                else
                {
                    result = "You Lost.";
                }

                _navigationManager.NavigateTo($"/endgame/{result}");
            }
        }

        private void CompareValues(string playerValue, string computerValue)
        {
            playerValue = playerValue.Replace("km", "");
            playerValue = playerValue.Replace(",", "");

            if (playerValue == "unknown" || playerValue == "n/a")
            {
                playerValue = "0";
            }
            
            computerValue = computerValue.Replace("km", "");
            computerValue = computerValue.Replace(",", "");
            
            if (computerValue == "unknown" || computerValue == "n/a")
            {
                computerValue = "0";
            }

            // 30-165
            if (playerValue.Contains('-'))
            {
                playerValue = GetMaxOrMinValue(playerValue).ToString();
            }

            if (computerValue.Contains('-'))
            {
                computerValue = GetMaxOrMinValue(computerValue).ToString();
            }

            GameData.Hand.Player1Value = long.Parse(playerValue);
            GameData.Hand.Player2Value = long.Parse(computerValue);

            if (GameData.Hand.Player1Value == GameData.Hand.Player2Value)
            {
                GameData.Hand.HandResult = HandResult.Draw;
                GameData.Hand.Message = nameof(HandResult.Draw);
            }
            else if (GameData.Hand.Player1Value > GameData.Hand.Player2Value)
            {
                GameData.Hand.HandResult = HandResult.Win;
                GameData.Hand.Message = nameof(HandResult.Win);
                GameData.Player1.Score += 1;
            }
            else
            {
                GameData.Hand.HandResult = HandResult.Lose;
                GameData.Hand.Message = nameof(HandResult.Lose);
                GameData.Player2.Score += 1;
            }
        }

        private static int GetMaxOrMinValue(string value, bool returnMax = true)
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
    }
}
