using SeaBattle.Interaction.Bot;
using SeaBattle.Interaction.Data.EventData;
using SeaBattle.Interaction.Models.Interfaces;

namespace SeaBattle.Interaction.ConnectionPresenter
{
    public class ConnectionPresenter
    {
        private readonly IGameModel _gameModel;
        private readonly IAnotherPlayer _anotherPlayer;

        public ConnectionPresenter(IGameModel gameModel, IAnotherPlayer anotherPlayer)
        {
            _gameModel = gameModel;
            _anotherPlayer = anotherPlayer;

            _gameModel.GameIsLoosed += GameModelLoseGame;
            _gameModel.IsReadyForGame += GameModelIsReady;
            _gameModel.MoveSwitched += GameModelAttackAnotherPlayer;
            _gameModel.MoveAccepted += GameModelSendMoveResult;

            _anotherPlayer.GameIsLoosed += AnotherPlayerLoseGame;
            _anotherPlayer.IsReadyForGame += AnotherPlayerIsReady;
            _anotherPlayer.MoveSwitched += AnotherPlayerAttackGameModel;
            _anotherPlayer.MoveAccepted += AnotherPlayerSendMoveResult;
        }

        public void AnotherPlayerAttackGameModel(object sender, MoveEventArgs args)
        {
            _gameModel.Attacked(new Tuple<int, int>(args.X, args.Y));
        }

        public void GameModelAttackAnotherPlayer(object sender, MoveEventArgs args) 
        {
            _anotherPlayer.Attacked(new Tuple<int, int>(args.X, args.Y));
            _anotherPlayer.Attack();
        }

        public void GameModelSendMoveResult(object sender, MoveResultEventArgs args) 
        {
            _anotherPlayer.AcceptMove(new Tuple<int, int>(args.X, args.Y), args.IsShipCell, args.IsShipDestroyed);
        }

        public void AnotherPlayerSendMoveResult(object sender, MoveResultEventArgs args)
        {
           _gameModel.AcceptMove(new Tuple<int, int>(args.X, args.Y), args.IsShipCell, args.IsShipDestroyed);
        }

        public void AnotherPlayerIsReady(object sender, EventArgs args)
        {
            _gameModel.AcceptAnotherPlayerMessageReadyForGame();
        }

        public void GameModelIsReady(object sender, EventArgs args)
        {
            _anotherPlayer.AcceptAnotherPlayerMessageReadyForGame();
        }

        public void AnotherPlayerLoseGame(object sender, EventArgs args)
        {
            _gameModel.AcceptMessageGameIsEnd();
        }

        public void GameModelLoseGame(object sender, EventArgs args)
        {
            _anotherPlayer.AcceptMessageGameIsEnd();
        }
    }
}
