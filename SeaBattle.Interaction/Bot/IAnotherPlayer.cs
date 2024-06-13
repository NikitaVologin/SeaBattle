using SeaBattle.Domain.Entities;
using SeaBattle.Interaction.Data.EventData;
using SeaBattle.Interaction.Data.TransportObjects;

namespace SeaBattle.Interaction.Bot
{
    public interface IAnotherPlayer
    {
        event EventHandler<MoveEventArgs> MoveSwitched;
        event EventHandler<GameStartEventArgs> GameStarted;

        void Attack(Field field);

        void Attacked(Cell cell);

        void GetShips();
    }
}
