using SeaBattle.Domain.Entities;
using SeaBattle.Interaction.Data.EventData;

namespace SeaBattle.Interaction.Bot
{
    public class BotPlayer : IAnotherPlayer
    {
        public event EventHandler<MoveEventArgs> MoveSwitched = delegate { };
        public event EventHandler<MoveResultEventArgs> MoveAccepted = delegate { };
        public event EventHandler IsReadyForGame = delegate { };
        public event EventHandler GameIsLoosed = delegate { };

        private Field _field;
        private Field _enemyField;

        private int _moveOrder;

        public BotPlayer()
        {
            this.Initialize();
        }

        public void Initialize()
        {
            this._field = new Field();
            this._enemyField = new Field();
        }

        public void Attack()
        {
            var notAttackedCells = new List<Cell>();
            var width = _enemyField.Map.GetLength(0);
            var height = _enemyField.Map.GetLength(1);
            for (var i = 0; i < width; i++)
                for (int j = 0; j < height; j++)    
                    if (!_enemyField[i, j].IsAttacked)
                        notAttackedCells.Add(new Cell(i, j));

            var rnd = new Random(DateTime.Now.Second);
            var cellNumber = rnd.Next(0, notAttackedCells.Count - 1);
            var cell = notAttackedCells[cellNumber];

            this._moveOrder = 0;
            MoveSwitched.Invoke(this, new MoveEventArgs { X = cell.X, Y = cell.Y });
        }

        public void Attacked(Tuple<int, int> point)
        {
            throw new NotImplementedException();
            this._moveOrder = 1;
        }

        public void AcceptMove(Tuple<int, int> point, bool isShipCel, bool isShipDestroyed)
        {
            throw new NotImplementedException();
        }

        public void AcceptAnotherPlayerMessageReadyForGame()
        {
            IsReadyForGame.Invoke(this, new EventArgs());
        }

        public void AcceptMessageGameIsEnd()
        {
            
        }

        private void isGameEnd()
        {
            if (this._field.AreShipsDestoyed)
            {
                GameIsLoosed.Invoke(this, new EventArgs());
            }
        }
    }
}
