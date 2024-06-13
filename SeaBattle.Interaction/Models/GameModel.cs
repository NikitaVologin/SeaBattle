using AutoMapper;
using SeaBattle.Domain.Entities;
using SeaBattle.Interaction.Bot;
using SeaBattle.Interaction.Data.EventData;
using SeaBattle.Interaction.Data.TransportObjects;
using SeaBattle.Interaction.Models.Interfaces;

namespace SeaBattle.Interaction.Models
{
    public class GameModel : IGameModel
    {
        private readonly IMapper _mapper;

        public event EventHandler<GameplayEventArgs> Updated = delegate { };
        public event EventHandler<GameEndEventArgs> GameEnded = delegate { };
        public event EventHandler<MoveEventArgs> MoveSwitched = delegate { };
        public event EventHandler<GameStartEventArgs> GameStarted = delegate { };

        private IAnotherPlayer _anotherPlayer;
        private Field _field;
        private Field _enemyField;

        private int _moveOrder;

        public GameModel(IMapper mapper) { this._mapper = mapper; }

        public void Initialize()
        {
            this._field = new Field();
            this._enemyField = new Field();
            this._anotherPlayer = new BotPlayer();
        }

        public void Attack(Tuple<int, int> point)
        {
            var cell = Cell.ToCell(point);
            this._enemyField.Attack(cell);
            MoveSwitched.Invoke(this, new MoveEventArgs { X = cell.X, Y = cell.X });
        }

        public void Attacked(Tuple<int, int> point)
        {
            var cell = Cell.ToCell(point);
            this._field.Attack(cell);
        }

        public void SetShip(int shipId, List<Tuple<int, int>> points)
        {
            var cells = Cell.ToCells(points);
            this._field.SetShipPositions(shipId, cells);
        }

        public void GetReady()
        {
            var rnd = new Random(DateTime.Now.Second);
            this._moveOrder = rnd.Next(0, 1);
            if (this._moveOrder == 1) 
            {
                
            }
        }

        public void Update()
        {
            var data = getUpdateData();
            Updated.Invoke(this, data);
        }

        private GameplayEventArgs getUpdateData()
        {
            var ships = new List<ShipInformation>();
            ships = this._mapper.Map<List<ShipInformation>>(this._field.Ships.ToList());
            var width = this._field.Map.GetLength(0);
            var height = this._field.Map.GetLength(1);
            var enemyMap = new CellInformation[width, height];
            var map = new CellInformation[width, height];
            map = this._mapper.Map<CellInformation[,]>(this._field.Map);
            enemyMap = this._mapper.Map<CellInformation[,]>(this._enemyField.Map);

            var args = new GameplayEventArgs
            {
                Ships = ships,
                EnemyMap = enemyMap,
                Map = map
            };
            return args;
        }
    }
}