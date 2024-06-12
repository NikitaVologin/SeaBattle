namespace SeaBattle.Domain.Entities
{
    public class Board
    {
        public Field Field { get; set; }

        public Field? EnemyField { get; set; }   

        public Board() =>
            Field = new Field();

        public List<Ship> Ships =>
            Field.Ships.ToList();

        public bool IsItLose =>
            this.Field.AreShipsDestoyed;

        public bool IsItWin =>
            this.EnemyField!.AreShipsDestoyed;

        public bool Attack(Cell cell) =>
            EnemyField!.Attack(cell); 
        
        public void SetShip(int shipId, List<Cell> cells)
        {
            var ship = Ships.Where(ship => ship.Id == shipId).FirstOrDefault();             
            Field.SetShipPositions(ship, cells);
        }
    }
}