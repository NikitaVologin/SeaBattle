using SeaBattle.Domain.EventData;

namespace SeaBattle.Domain.Models.Interfaces
{
    public interface IGameModel
    {
        event EventHandler<GameplayEventArgs> Updated;

        void Update();

        public void Attack(Tuple<int, int> point);

        public void SetShip(int shipId, List<Tuple<int, int>> cells);

        public void Initialize();
    }
}
