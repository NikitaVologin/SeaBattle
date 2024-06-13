using SeaBattle.Interaction.Data.EventData;
using SeaBattle.View.EventData;
using System;

namespace SeaBattle.View.Interfaces
{
    public interface IGameView
    {
        event EventHandler CycleFinished;
        event EventHandler<PlayerClickArgs> EnemyFieldClicked;
        event EventHandler<ShipPlaceArgs> ShipPlaced;
        event EventHandler ReadyButtonClicked;

        void LoadGameCycleParameters(GameplayEventArgs parameters);

        void RunGame();
    }
}