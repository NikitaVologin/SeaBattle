namespace SeaBattle.Interaction.Data.EventData
{
    public class MoveResultEventArgs: EventArgs
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsShipCell { get; set; }    

        public bool IsShipDestroyed { get; set; }
    }
}