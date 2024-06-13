using SeaBattle.Interaction.Bot;
using SeaBattle.Interaction.Data.EventData;
using SeaBattle.Interaction.Models.Interfaces;
using SeaBattle.View.EventData;
using SeaBattle.View.Interfaces;
using System;

namespace SeaBattle.Presenter
{
    public class GameplayPresenter
    {
        private readonly IGameModel _gameModel;
        private readonly IGameView _gameView;

        public GameplayPresenter(IGameModel gameModel, IGameView gameView) 
        {
            this._gameModel = gameModel;
            this._gameView = gameView;

            this._gameView.EnemyFieldClicked += ReloadModelClickToEnemyField;
            this._gameView.ShipPlaced += ReloadModeClickToPlaceShip;
            this._gameView.ReadyButtonClicked += GetReady;
            this._gameView.CycleFinished += ReloadModel;

            this._gameModel.Updated += ReloadView;    

            this._gameModel.Initialize();
        }

        public void LaunchGame()
        {
            this._gameView.RunGame();
        }

        public void GetReady(object sender, EventArgs e)
        {
            this._gameModel.GetReady();
        }

        public void ReloadView(object sender, GameplayEventArgs e)
        {
            this._gameView.LoadGameCycleParameters(e);
        }

        public void ReloadModelClickToEnemyField(object sender, PlayerClickArgs e)
        {
            this._gameModel.Attack(Tuple.Create(e.X, e.Y));
        }

        public void ReloadModeClickToPlaceShip(object sender, ShipPlaceArgs e)
        {
            this._gameModel.SetShip(e.ShipId, e.Coordinates);
        }

        public void ReloadModel(object sender, EventArgs e) 
        {
            this._gameModel.Update();
        }
    }
}