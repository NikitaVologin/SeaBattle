using SeaBattle.Interaction.Data.EventData;

namespace SeaBattle.Interaction.Models.Interfaces
{
    public interface IGameModel
    {
        event EventHandler<GameplayEventArgs> Updated;
        event EventHandler<GameStartEventArgs> GameStarted;
        event EventHandler<GameEndEventArgs> GameEnded;
        event EventHandler<MoveEventArgs> MoveSwitched;
        event EventHandler<MoveResultEventArgs> MoveAccepted;
        event EventHandler IsReadyForGame;
        event EventHandler GameIsLoosed;

        void Update();

        void Attack(Tuple<int, int> point);

        void Attacked(Tuple<int, int> point);

        void AcceptMove(Tuple<int, int> point, bool isShipCell, bool isShipDestroyed);

        void AcceptAnotherPlayerMessageReadyForGame();

        void AcceptMessageGameIsEnd();

        void SetShip(int shipId, List<Tuple<int, int>> cells);

        void GetReady();

        void Initialize();
    }
}