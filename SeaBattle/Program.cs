
using SeaBattle.Domain.Models;
using SeaBattle.Presenter;

using var game = new SeaBattle.View.GameCycle();

var presenter = new GameplayPresenter(new GameModel(), game);

presenter.LaunchGame();