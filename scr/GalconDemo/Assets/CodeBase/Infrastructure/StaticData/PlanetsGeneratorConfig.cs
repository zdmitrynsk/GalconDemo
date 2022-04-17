using UnityEngine;

namespace CodeBase.Infrastructure.StaticData
{
  [CreateAssetMenu(fileName = "PlanetsGeneratorConfig", menuName = "StaticData")]
  public class PlanetsGeneratorConfig : ScriptableObject
  {
    public int minRadius = 10;
    public int maxRadius = 30;
    public int countOfPlanetsThatAreNeighbors = 3;
  }
}