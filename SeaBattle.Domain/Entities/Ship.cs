using SeaBattle.Domain.Exceptions.ShipExceptions;

namespace SeaBattle.Domain.Entities
{
    public class Ship
    {
        static int ID;

        private List<Cell> _cells;
        public List<Cell> Cells
        {
            get => this._cells;
            set
            {
                if(value.Count > 4 || value.Count < 1)
                    throw new NotCorrectShipSizeException($"Incorrect ship size {value.Count}");
                if (!this.isCorrectPosition(value))
                    throw new NotCorrectShipPositionException($"Incorrect ship position");
                this._cells = new List<Cell>();
                for (int i = 0; i < value.Count; i++)
                    this._cells.Add(value[i]);
            }
        }

        public int Id { get; set; }

        public bool isDestroyed => 
            this._cells.All(cell => cell.IsAttacked);
     
        public int Size =>
            this._cells.Count;

        public Ship(ICollection<Cell> cells) =>
            this.Cells = cells.ToList();
        
        public Ship(int size)
        {
            if (size > 4 || size < 1)
                throw new NotCorrectShipSizeException($"Incorrect ship size {size}");
            
            _cells = new List<Cell>(size);
            for (int i = 0; i < size; i++)
                _cells.Add(Cell.Empty);

            Ship.ID += 1;
            this.Id = Ship.ID;
        }

        private bool isCorrectPosition(List<Cell> cells)
        {
            var xCoordinats = cells.Select(cell => cell.X);
            var yCoordinats = cells.Select(cell => cell.Y);

            if (xCoordinats.All(x => x == xCoordinats.First()))
                return yCoordinats.Sum() == (2 * yCoordinats.Min() + (yCoordinats.Count() - 1) * 1 ) * yCoordinats.Count() / 2 ;
            else if (yCoordinats.All(y => y == yCoordinats.First()))
                return xCoordinats.Sum() == (2 * xCoordinats.Min() + (xCoordinats.Count() - 1) * 1 ) * xCoordinats.Count() / 2 ;
            return false;
        }

        public bool IsItShipCoordinate(Cell cell) =>
            this.Cells.Contains(cell);
    }
}