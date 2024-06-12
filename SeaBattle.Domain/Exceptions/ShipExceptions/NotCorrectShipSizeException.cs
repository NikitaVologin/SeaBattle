namespace SeaBattle.Domain.Exceptions.ShipExceptions
{
    public class NotCorrectShipSizeException : Exception
    {
        public NotCorrectShipSizeException(string? message) : base(message) {  }
    }
}
