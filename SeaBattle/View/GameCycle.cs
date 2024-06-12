using Microsoft.Win32.SafeHandles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SeaBattle.Domain.EventData;
using SeaBattle.Domain.Views;
using SeaBattle.View.EventData;
using SeaBattle.View.Interfaces;
using System;
using System.Collections.Generic;

namespace SeaBattle.View
{
    public class GameCycle : Game, IGameView
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private CellView[,] _map;
        private List<ShipView> _ships;

        public event EventHandler CycleFinished = delegate { };
        public event EventHandler<PlayerClickArgs> EnemyFieldClicked = delegate { };
        public event EventHandler<ShipPlaceArgs> ShipPlaced = delegate { };
        public event EventHandler ReadyButtonClicked = delegate { };

        public GameCycle()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            base.Update(gameTime);

            CycleFinished.Invoke(this, new EventArgs());
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            base.Draw(gameTime);
        }

        public void LoadGameCycleParameters(GameplayEventArgs parameters)
        {
            this._map = parameters.Map;
            this._ships = parameters.Ships;
        }

        public void RunGame()
        {
            this.Run();
        }
    }
}