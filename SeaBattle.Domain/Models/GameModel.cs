using SeaBattle.Domain.Entities;
using SeaBattle.Domain.EventData;
using SeaBattle.Domain.Models.Interfaces;
using SeaBattle.Domain.Views;

namespace SeaBattle.Domain.Models
{
    public class GameModel : IGameModel
    {
        public event EventHandler<GameplayEventArgs> Updated = delegate { };
        public event EventHandler GameEnded = delegate { };

        private Board _board;

        public GameModel() { }

        public void Initialize()
        {
            _board = new Board();
        }

        public void Attack(Tuple<int, int> point)
        {
            var cell = Cell.ToCell(point);
            this._board.Attack(cell);
        }

        public void SetShip(int shipId, List<Tuple<int, int>> points)
        {
            var cells = Cell.ToCells(points);
            this._board.SetShip(shipId, cells);
        }

        public void Update()
        {
            var ships = new List<ShipView>();

            foreach (var ship in this._board.Ships)
            {
                var cells = new List<CellView>();
                foreach (var cell in ship.Cells)
                    cells.Add(new CellView { X = cell.X, Y = cell.Y, IsAttacked = cell.IsAttacked });
                var shipView = new ShipView
                {
                    Id = ship.Id,
                    Cells = cells
                };
                ships.Add(shipView);
            }

            var width = this._board.Field.Map.GetLength(0);
            var height = this._board.Field.Map.GetLength(1);
            var bmap = this._board.Field.Map;
            var map = new CellView[width, height];

            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)    
                    map[j, i] = new CellView { X = bmap[j, i].X, Y = bmap[j, i].Y, IsAttacked = bmap[j, i].IsAttacked };
                
            Updated.Invoke(this,
                new GameplayEventArgs 
                { 
                    Ships = ships,
                    Map = map
                }
            );
        }
    }
}