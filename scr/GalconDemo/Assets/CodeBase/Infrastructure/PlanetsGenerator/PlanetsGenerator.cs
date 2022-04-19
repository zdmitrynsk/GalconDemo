using System.Collections.Generic;
using System.Linq;
using CodeBase.Infrastructure.Data;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.StaticData;
using UnityEngine;

namespace CodeBase.Infrastructure.PlanetsGenerator
{
  public class PlanetsGenerator : IPlanetsGenerator
  {
    private IStaticDataService _staticDataService;
    private IRandomService _randomService;
    private PointInfo[,] _maskAreaPlanets;

    private List<PlanetData> _createdPlanets;

    public PlanetsGenerator(IStaticDataService staticDataService, IRandomService randomService)
    {
      _randomService = randomService;
      _staticDataService = staticDataService;
    }

    public List<PlanetData> Create()
    {
      _maskAreaPlanets = CreateMaskAreaPlanets();
      _createdPlanets = new List<PlanetData>();
      
      for (int i = 0; i < CountPlanetsSettings(); i++) 
        _createdPlanets.Add(CreatePlanet());
      
      return _createdPlanets;
    }

    private PointInfo[,] CreateMaskAreaPlanets()
    {
      PointInfo[,] maskAreaPlanets = new PointInfo[
        MaskWidth(), 
        MaskHeight()];
      
      for (int x = 0; x < maskAreaPlanets.GetLength(0); x++)
      for (int y = 0; y < maskAreaPlanets.GetLength(1); y++)
        maskAreaPlanets[x, y] = new PointInfo
        {
          Position = new Vector2(x, y), 
          IsFiled = false
        };
      
      return maskAreaPlanets;
    }
    private int CountPlanetsSettings() => 
      _staticDataService.GameConfig.countPlanets;

    private PlanetData CreatePlanet()
    {
      List<PointInfo> emptyPoints = FindEmptyPoints(_maskAreaPlanets);
      PointInfo randomEmptyPoint = RandomPoint(emptyPoints);

      int newRadius = NewRadius(randomEmptyPoint);
      FillMaskArea(newRadius + MinRadiusSettings(), randomEmptyPoint.Position);
      return CreatePlanet(newRadius, randomEmptyPoint.Position);
    }

    private List<PointInfo> FindEmptyPoints(PointInfo[,] maskAreaPlanets) => 
      maskAreaPlanets.Cast<PointInfo>().Where(maskInfo => !maskInfo.IsFiled).ToList();

    private PointInfo RandomPoint(List<PointInfo> emptyPoints)
    {
      int randomIndex = _randomService.Next(0, emptyPoints.Count);
      return emptyPoints[randomIndex];
    }

    private int NewRadius(PointInfo point)
    {
      float maxRadius = MaxRadiusSettings();
      if (IsExistsPlanets())
        maxRadius = MaxRadiusByNeighbor(point);
      int newRadius = _randomService.Next(MinRadiusSettings(), (int) maxRadius);
      return newRadius;
    }

    private bool IsExistsPlanets() => 
      _createdPlanets.Count > 0;

    private float MaxRadiusByNeighbor(PointInfo randomEmptyPoint)
    {
      float maxRadius;
      DistancePlanet distanceInfo = FindNeighboringPlanet(randomEmptyPoint.Position);
      maxRadius = distanceInfo.Distance - distanceInfo.Planet.Radius;
      maxRadius = maxRadius < MaxRadiusSettings() ? maxRadius : MaxRadiusSettings();
      return maxRadius;
    }

    private DistancePlanet FindNeighboringPlanet(Vector2 position)
    {
      List<DistancePlanet> distancePlanets = new List<DistancePlanet>();
      foreach (PlanetData planet in _createdPlanets)
      {
        float distance = Vector2.Distance(planet.Position, position);
        distancePlanets.Add(new DistancePlanet(planet, distance));
        distancePlanets.Sort((x, y) => x.Distance.CompareTo(y.Distance));
      }

      return distancePlanets[0];
    }

    private void FillMaskArea(int radius, Vector2 centerPosition)
    {
      int minX = MinFillingValue(centerPosition.x, radius);
      int maxX = MaxFillingX(centerPosition.x, radius);
      
      for (int x = minX; x <= maxX; x++)
      {
        int maxCircleY = Mathf.Abs(GetYCircle(radius, centerPosition, x));
        int minFillingY = MinFillingValue(centerPosition.y, maxCircleY);
        int maxFillingY = MaxFillingY(centerPosition.y, maxCircleY);

        for (int y = minFillingY; y <= maxFillingY; y++) 
          _maskAreaPlanets[x, y].IsFiled = true;
      }
    }

    private static int GetYCircle(int radius, Vector2 centerPosition, int x)
    {
      float relativeX = (x - centerPosition.x) / radius;
      float rad = Mathf.Acos(relativeX);
      float relativeY = Mathf.Sin(rad);
      int maxY = (int) (relativeY * radius);
      return maxY;
    }

    private int MinFillingValue(float center, int radius)
    {
      int min = (int) center - radius;
      return min > 0 ? min : 0;
    }

    private int MaxFillingX(float center, int radius)
    {
      int max = (int) center + radius;
      return max < MaskWidth() - 1 ? max : MaskWidth() - 1;
    }

    private int MaxFillingY(float center, int radius)
    {
      int max = (int) center + radius;
      return max < MaskHeight() - 1 ? max : MaskHeight() - 1;
    }

    private PlanetData CreatePlanet(int newRadius, Vector2 position) => 
      new PlanetData {Radius = newRadius, Position = position, CountStarships = RandomCountStarships()};

    private int RandomCountStarships() => 
      _randomService.Next(_staticDataService.GameConfig.minStartStarships, _staticDataService.GameConfig.maxStartStarships);

    private int MinRadiusSettings() => 
      _staticDataService.GameConfig.minRadius;

    private int MaxRadiusSettings() => 
      _staticDataService.GameConfig.maxRadius;

    private int MaskHeight() => 
      Screen.height - MinRadiusSettings()*2;

    private int MaskWidth() => 
      Screen.width - MinRadiusSettings()*2;
  }
}