namespace SeaBattle.Domain.Exceptions.ShipExceptions
{
    public class NotCorrectShipPositionException : Exception
    {
        public NotCorrectShipPositionException(string? message) : base(message) { }
    }
}
