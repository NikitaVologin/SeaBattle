using SeaBattle.Interaction.Data.EventData;

namespace SeaBattle.Interaction.Bot
{
    public interface IAnotherPlayer
    {
        event EventHandler<MoveEventArgs> MoveSwitched;
        event EventHandler<MoveResultEventArgs> MoveAccepted;
        event EventHandler IsReadyForGame;
        event EventHandler GameIsLoosed;

        void Attack();

        void Attacked(Tuple<int, int> point);

        void AcceptMove(Tuple<int, int> point, bool isShipCell, bool isShipDestroyed);

        void AcceptMessageGameIsEnd();

        void AcceptAnotherPlayerMessageReadyForGame();
    }
}
