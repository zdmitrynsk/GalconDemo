using System.Collections.Generic;
using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.StaticData;
using UnityEngine;
using UnityEngine.AI;

namespace CodeBase.Infrastructure
{
  public class GameFactory : IGameFactory 
  {
    private IAssetProvider _assetProvider;
    private readonly IStaticDataService _staticDataService;

    public GameFactory(IAssetProvider assetProvider, IStaticDataService staticDataService)
    {
      _assetProvider = assetProvider;
      _staticDataService = staticDataService;
    }
    

    public GameObject CreateGameArea() => 
      _assetProvider.Instatiate(AssetPaths.GameArea);

    public List<GameObject> CreatePlanets(List<PlanetData> planetDatas)
    {
      float offset = _staticDataService.PlanetsGenerator.minRadius;

      List<GameObject> planets = new List<GameObject>();
      foreach (PlanetData planetData in planetDatas)
      {
        Vector2 position = planetData.Position;
        position.x += offset;
        position.y += offset;
        
        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(position);
        worldPoint.y = 0.6f;
        GameObject planetObj = _assetProvider.Instatiate(AssetPaths.Planet, worldPoint);
        planetObj.transform.eulerAngles = new Vector3(90, 0 ,0);
        float radiusInUnits = RadiusInUnits(planetData);
        planetObj.transform.localScale = new Vector3(radiusInUnits, radiusInUnits, 1);
        planets.Add(planetObj);
      }

      return planets;
    }

    private static float RadiusInUnits(PlanetData planetData)
    {
      float unitsPerPixel = (Camera.main.orthographicSize * 2) / Screen.height;
      float radiusInUnits = planetData.Radius * unitsPerPixel;
      return radiusInUnits;
    }
  }
}