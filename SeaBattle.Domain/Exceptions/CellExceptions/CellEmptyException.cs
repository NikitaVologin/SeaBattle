namespace SeaBattle.Domain.Exceptions.CellExceptions
{
    public class CellEmptyException : Exception
    {
        public CellEmptyException(string? message) : base(message) { }
    }
}
