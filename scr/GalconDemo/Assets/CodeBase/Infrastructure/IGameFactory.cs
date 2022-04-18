using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Infrastructure
{
  public interface IGameFactory
  {
    GameObject CreateGameArea();
    List<GameObject> CreatePlanets(List<PlanetData> planetDatas);
  }
}