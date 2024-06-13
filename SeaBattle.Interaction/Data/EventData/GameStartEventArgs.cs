using SeaBattle.Interaction.Data.TransportObjects;

namespace SeaBattle.Interaction.Data.EventData
{
    public class GameStartEventArgs: EventArgs
    {
        public List<ShipInformation> Ships { get; set; }
    }
}