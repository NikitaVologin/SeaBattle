using SeaBattle.Domain.Exceptions.CellExceptions;

namespace SeaBattle.Domain.Entities
{
    public class Cell
    {
        public static Cell Empty
            => new Cell();   
        
        public static Cell ToCell(Tuple<int, int> tupleCell)
        {
            return new Cell(tupleCell.Item1, tupleCell.Item2);
        }

        public static List<Cell> ToCells(List<Tuple<int, int>> tupleCells)
        {
            var cells = new List<Cell>();
            tupleCells.ForEach(tupleCell => { cells.Add(Cell.ToCell(tupleCell)); } );
            return cells;
        }

        private int _x;
        private int _y;
        private bool _isEmpty = false;
        private bool _isAttacked = false;
        private bool _isShipCell = false;

        public int X 
        { 
            get
            {
                return _x; 
            }
            set => this._x = value;
        }
        public int Y 
        {
            get
            {
                return _y;
            }
            set => this._y = value;
        }

        public void SetCoordinates(Cell cell)
        {
            (X, Y) = (cell.X, cell.Y);
            this._isEmpty = false;
        }

        public bool IsAttacked 
        {
            get
            {
                if (_isEmpty)
                    return false;
                return this._isAttacked;
            }
            set
            {
                if (_isEmpty)
                    throw new InvalidOperationException("You can not set {IsAttracked} to empty cell!");
                this._isAttacked = value;
            }
        }

        public bool IsShipCell
        {
            get
            {
                if (_isEmpty)
                    return false;
                return this._isShipCell;
            }
            set
            {
                this._isShipCell = value;
            }
        }

        public Cell(int x, int y) =>
            (X, Y) = (x, y);

        private Cell()
        {
            (X, Y) = (0, 0);
            this._isEmpty = true;
        }    

        private bool Equals(Cell obj) =>
            (this._isEmpty == obj._isEmpty && this._isEmpty) ||
                (this.X == obj.X && this.Y == obj.Y); 
       
        public override bool Equals(object? obj) => 
            obj is Cell cell && Equals(cell);

        public override int GetHashCode() =>
            base.GetHashCode();

        public override string ToString()
        {
            if (this._isEmpty)
                return "{Empty}";
            return $"{{{this.X}; {this.Y}}}";
        }
    }
}