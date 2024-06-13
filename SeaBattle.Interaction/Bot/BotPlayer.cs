using SeaBattle.Domain.Entities;
using SeaBattle.Interaction.Data.EventData;
using SeaBattle.Interaction.Data.TransportObjects;

namespace SeaBattle.Interaction.Bot
{
    public class BotPlayer : IAnotherPlayer
    {
        public event EventHandler<MoveEventArgs> MoveSwitched = delegate { };

        public void Attack(Field field)
        {
            var notAttackedCells = new List<Cell>();
            var width = field.Map.GetLength(0);
            var height = field.Map.GetLength(1);
            for (var i = 0; i < width; i++)
                for (int j = 0; j < height; j++)    
                    if (!field[i, j].IsAttacked)
                        notAttackedCells.Add(new Cell(i, j));

            var rnd = new Random(DateTime.Now.Second);
            var cellNumber = rnd.Next(0, notAttackedCells.Count - 1);
            var cell = notAttackedCells[cellNumber];
        }

        public void GetShips()
        {
            throw new NotImplementedException();
        }
    }
}
