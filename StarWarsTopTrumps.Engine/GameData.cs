﻿namespace StarWarsTopTrumps.Engine
{
    public class GameData
    {
        public bool CardsDealt { get; set; }
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public string SelectedAttribute { get; set; }
        public Hand Hand { get; set; }
    }
}
