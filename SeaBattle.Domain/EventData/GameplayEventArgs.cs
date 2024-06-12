using SeaBattle.Domain.Views;
namespace SeaBattle.Domain.EventData
{
    public class GameplayEventArgs : EventArgs
    {
        public List<ShipView> Ships { get; set; }

        public CellView[,] Map { get; set; }
    }
}
