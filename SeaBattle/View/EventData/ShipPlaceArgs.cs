using System;
using System.Collections.Generic;

namespace SeaBattle.View.EventData
{
    public class ShipPlaceArgs: EventArgs
    {
        public int ShipId { get; set; }

        public List<Tuple<int, int>> Coordinates { get; set; }
    }
}