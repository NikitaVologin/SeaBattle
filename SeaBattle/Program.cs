
using AutoMapper;
using SeaBattle.Interaction.Mappings.Common;
using SeaBattle.Interaction.Models;
using SeaBattle.Presenter;
using System.Reflection;

using var game = new SeaBattle.View.GameCycle();

var conf = new MapperConfigurationExpression();
conf.AddProfile(new AssemblyMappingProfile(Assembly.GetAssembly(typeof(IMapWith<>))));
var mapper = new Mapper(new MapperConfiguration(conf));

var presenter = new GameplayPresenter(new GameModel(mapper), game);
presenter.LaunchGame();