using System.Collections.Generic;
using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.Components;
using CodeBase.Infrastructure.Data;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.StaticData;
using UnityEngine;
using UnityEngine.AI;

namespace CodeBase.Infrastructure
{
  public class GameFactory : IGameFactory 
  {
    private IAssetProvider _assetProvider;
    private readonly IStaticDataService _staticDataService;
    private ISelectPlanetsService _selectPlanetsService;

    public GameFactory(IAssetProvider assetProvider, IStaticDataService staticDataService,
      ISelectPlanetsService selectPlanetsService)
    {
      _selectPlanetsService = selectPlanetsService;
      _assetProvider = assetProvider;
      _staticDataService = staticDataService;
    }
    

    public GameObject CreateGameArea() => 
      _assetProvider.Instatiate(AssetPaths.GameArea);

    public List<GameObject> CreatePlanets(List<PlanetData> planetDatas)
    {
      List<GameObject> planets = new List<GameObject>();
      
      foreach (PlanetData planetData in planetDatas) 
        planets.Add(CreatePlanet(planetData));

      return planets;
    }

    public void RunStarships(PlanetData sourcePlanet, PlanetData targetPlanet, int countNewStarships)
    {
      float starshipSize = 0.2f;
      for (int i = 0; i < countNewStarships; i++)
      {
        GameObject starship = _assetProvider.Instatiate(AssetPaths.Spaceship, WorldPoint(sourcePlanet));
        NavMeshAgent navMeshAgent = starship.GetComponent<NavMeshAgent>();
        navMeshAgent.updateRotation = false;
        navMeshAgent.updateUpAxis = false;
        navMeshAgent.SetDestination(WorldPoint(targetPlanet));
        starship.transform.eulerAngles = new Vector3(90, 0, 0);
        starship.GetComponent<AttackOnTriggerTargetPlanet>().Construct(targetPlanet);
      }
    }

    private GameObject CreatePlanet(PlanetData planetData)
    {
      GameObject planetObj = _assetProvider.Instatiate(AssetPaths.Planet);

      InitPlanetTransform(planetData, planetObj);
      planetObj.GetComponent<PlanetDataHolder>().PlanetData = planetData;
      InitStarshipsCounter(planetObj);
      InitOwnerViewer(planetObj);
      InitSelectorView(planetData, planetObj);
      InitClickableByPlayer(planetObj);
      return planetObj;
    }

    private void InitPlanetTransform(PlanetData planetData, GameObject planetObj)
    {
      Vector3 worldPoint = WorldPoint(planetData);
      planetObj.transform.position = worldPoint;
      planetObj.transform.eulerAngles = new Vector3(90, 0, 0);
      float radiusInUnits = RadiusInUnits(planetData);
      planetObj.transform.localScale = new Vector3(radiusInUnits, radiusInUnits, 1);
    }

    private Vector3 WorldPoint(PlanetData planetData)
    {
      float offset = _staticDataService.GameConfig.minRadius;
      Vector2 position = planetData.Position;
      position.x += offset;
      position.y += offset;

      Vector3 worldPoint = Camera.main.ScreenToWorldPoint(position);
      worldPoint.y = 0.6f;
      return worldPoint;
    }

    private static void InitStarshipsCounter(GameObject planetObj)
    {
      StarshipsCounter starshipsCounter = planetObj.GetComponent<StarshipsCounter>();
      starshipsCounter.Init();
    }

    private static void InitOwnerViewer(GameObject planetObj)
    {
      OwnerViewer ownerViewer = planetObj.GetComponent<OwnerViewer>();
      ownerViewer.Init();
    }

    private static void InitSelectorView(PlanetData planetData, GameObject planetObj)
    {
      SelectorView selectorView = planetObj.GetComponent<SelectorView>();
      selectorView.Init();
    }

    private void InitClickableByPlayer(GameObject planetObj)
    {
      ClickableByPlayer clickableByPlayer = planetObj.GetComponent<ClickableByPlayer>();
      clickableByPlayer.Construct(_selectPlanetsService);
    }

    private static float RadiusInUnits(PlanetData planetData)
    {
      float unitsPerPixel = (Camera.main.orthographicSize * 2) / Screen.height;
      float radiusInUnits = planetData.Radius * unitsPerPixel;
      return radiusInUnits;
    }
  }
}