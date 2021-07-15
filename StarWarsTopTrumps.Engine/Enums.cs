﻿using System;
using System.Collections.Generic;
using System.Text;

namespace StarWarsTopTrumps.Engine
{
    public enum HandResult
    {
        None,
        Win,
        Lose,
        Draw
    }

    public enum HandState
    {
        Visible,
        Hidden
    }

    public enum StarShipAttributes
    {
        CostOfCredits,
        HyperDriveRating,
        TopSpeed,
        NumberOfFilms,
        CrewRequired
    }
}
