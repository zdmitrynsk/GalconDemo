using System;
using System.Collections;
using System.Collections.Generic;
using CodeBase.Infrastructure.Data;
using CodeBase.Infrastructure.StaticData;
using UnityEngine;

namespace CodeBase.Infrastructure.Services
{
  public class StarshipsGenerator : IStarshipsGenerator
  {
    private List<PlanetData> _planets;
    private ICoroutineRunner _coroutineRunner;
    private IStaticDataService _staticDataService;

    public StarshipsGenerator(ICoroutineRunner coroutineRunner, IStaticDataService staticDataService)
    {
      _staticDataService = staticDataService;
      _coroutineRunner = coroutineRunner;
    }

    public void Start(List<PlanetData> planets)
    {
      _planets = planets;
      _coroutineRunner.StartCoroutine(Generate());
    }

    private IEnumerator Generate()
    {
      while (true)
      {
        foreach (PlanetData planet in _planets) 
          if (planet.Owner != OwnerType.None)
            planet.AddStarships(1);
        float gameStarshipsPerSecond = (float)1 / _staticDataService.GameConfig.starshipsPerSecond;
        yield return new WaitForSeconds(gameStarshipsPerSecond);
      }
    }
  }
}