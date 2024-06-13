namespace SeaBattle.Domain.Entities
{
    public class Field
    {
        private Ship[] _ships;
        private Cell[,] _map;

        public Field() 
        {
            _map = new Cell[10, 10];
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                    _map[i, j] = new Cell(j, i);

            _ships = new Ship[10];
            for (int i = 0; i < 10; i++) 
            {
                if (i < 4)
                    _ships[i] = new Ship(1);
                else if (i < 7)
                    _ships[i] = new Ship(2);
                else if (i < 9)
                    _ships[i] = new Ship(3);
                else if (i < 10)
                    _ships[i] = new Ship(4);
            }
        }

        public Cell[,] Map => _map;

        public Ship[] Ships
        {
            get => _ships; 
        }

        public bool AreShipsDestoyed
        {
            get => this._ships.All(ship => ship.isDestroyed);
        }

        public void SetShipPositions(int shipId, List<Cell> cells)
        {
            var ship = Ships.Where(ship => ship.Id == shipId).FirstOrDefault();
            ship.Cells = cells.ToList();
        }

        public bool Attack(Cell cell)
        {
            this[cell].IsAttacked = true;
            return this.Ships.Any(x => x.IsItShipCoordinate(cell));
        }

        private bool cellInMapBounds(int x, int y)
        {
            return x >= this.getMinX() && x <= this.getMaxX() &&
                   y >= this.getMinY() && y <= this.getMaxY();
        }

        private int getMaxX() =>
            this._map[0, 9].X;

        private int getMinX() =>
            this._map[0, 0].X;

        private int getMaxY() =>
            this._map[0, 9].Y;

        private int getMinY() =>
            this._map[0, 0].Y;

        public Cell this[int x, int y]
        {
            get
            {
                if (!this.cellInMapBounds(x, y))
                    throw new InvalidOperationException("This cell does not in field bounds");
                return this._map[x, y];
            }
            set 
            {
                if (!this.cellInMapBounds(x, y))
                    throw new InvalidOperationException("This cell does not in field bounds");
                this._map[x, y] = value; 
            }
        }

        public Cell this[Cell cell] 
        {
            get => this[cell.X, cell.Y];
            set => this[cell.X, cell.Y] = value;
        }
    }
}