using System.Collections.Generic;
using CodeBase.Infrastructure.Data;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.StaticData;
using UnityEngine;

namespace CodeBase.Infrastructure
{
  public class Game
  {
    private IGameFactory _gameFactory;
    private GameObject _gameArea;
    private IStaticDataService _staticDataService;
    private IRandomService _randomUnityService;
    private IStarshipsGenerator _starshipsGenerator;

    public Game(IServiceLocator serviceLocator)
    {
      _gameFactory = serviceLocator.GameFactory;
      _staticDataService = serviceLocator.StaticDataService;
      _randomUnityService = serviceLocator.RandomUnityService;
      _starshipsGenerator = serviceLocator.StarshipsGenerator;
    }

    public void Start()
    {
      _gameArea = _gameFactory.CreateGameArea();
      List<PlanetData> planetsData = CreatePlanetsData();
      CreatePlanetsObjects(planetsData);
      InitPlayerPlanet(planetsData);
      _starshipsGenerator.Start(planetsData);
    }

    private void InitPlayerPlanet(List<PlanetData> planetsData)
    {
      planetsData[0].SetOwner(OwnerType.Player);
      planetsData[0].SetStarships(_staticDataService.GameConfig.countStartPlayerStarships);
    }

    private List<PlanetData> CreatePlanetsData()
    {
      var planetsGenerator = new PlanetsGenerator(_staticDataService, _randomUnityService);
      return planetsGenerator.Create();
    }

    private List<GameObject> CreatePlanetsObjects(List<PlanetData> planets) => 
      _gameFactory.CreatePlanets(planets);
  }
}