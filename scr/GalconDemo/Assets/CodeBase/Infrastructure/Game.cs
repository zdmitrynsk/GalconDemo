using System.Collections.Generic;
using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.StaticData;
using UnityEngine;

namespace CodeBase.Infrastructure
{
  public class Game
  {
    private IServiceLocator _serviceLocator;
    private ICoroutineRunner _coroutineRunner;
    private IAssetProvider _assetProvider;
    private IGameFactory _gameFactory;
    private GameObject _gameArea;
    private IStaticDataService _staticDataService;
    private IRandomService _randomUnityService;
    private List<GameObject> _planetsObjects;

    public Game(IServiceLocator serviceLocator, ICoroutineRunner coroutineRunner)
    {
      _serviceLocator = serviceLocator;
      _coroutineRunner = coroutineRunner;

      _gameFactory = serviceLocator.GameFactory;
      _assetProvider = serviceLocator.AssetProvider;
      _staticDataService = serviceLocator.StaticDataService;
      _randomUnityService = serviceLocator.RandomUnityService;
    }

    public void Start()
    {
      _gameArea = _gameFactory.CreateGameArea();
      List<PlanetData> planetDatas = CreatePlanetsData();
      _planetsObjects = CreatePlanetsObjects(planetDatas);
    }

    private List<PlanetData> CreatePlanetsData()
    {
      var planetsGenerator = new PlanetsGenerator(_staticDataService, _randomUnityService);
      return planetsGenerator.Create();
    }

    private List<GameObject> CreatePlanetsObjects(List<PlanetData> planets)
    {
      List<GameObject> planetsObj = _gameFactory.CreatePlanets(planets);
      return planetsObj;
    }
  }
}