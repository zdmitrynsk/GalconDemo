using System.Collections.Generic;
using CodeBase.Infrastructure.Data;
using UnityEngine;

namespace CodeBase.Infrastructure
{
  public interface IGameFactory
  {
    GameObject CreateGameArea();
    List<GameObject> CreatePlanets(List<PlanetData> planetDatas);
    void RunStarships(PlanetData lastSelectedPlanet, PlanetData clickedPlanet, int countNewStarships);
  }
}