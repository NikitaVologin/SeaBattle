using SeaBattle.Interaction.Data.TransportObjects;

namespace SeaBattle.Interaction.Data.EventData
{
    public class GameplayEventArgs : EventArgs
    {
        public List<ShipInformation> Ships { get; set; }

        public CellInformation[,] Map { get; set; }

        public CellInformation[,] EnemyMap { get; set; }

        public List<ShipInformation> EnemyShips { get; set; }

        public int MoveOrder { get; set; }
    }
}
