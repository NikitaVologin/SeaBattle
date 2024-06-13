using SeaBattle.Interaction.Data.EventData;

namespace SeaBattle.Interaction.Models.Interfaces
{
    public interface IGameModel
    {
        public event EventHandler<GameplayEventArgs> Updated;
        public event EventHandler<GameEndEventArgs> GameEnded;
        public event EventHandler<MoveEventArgs> MoveSwitched;

        void Update();

        void Attack(Tuple<int, int> point);

        void SetShip(int shipId, List<Tuple<int, int>> cells);

        void GetReady();

        void Initialize();
    }
}