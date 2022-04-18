using UnityEngine;

namespace CodeBase.Infrastructure.StaticData
{
  [CreateAssetMenu(fileName = "PlanetsGeneratorConfig", menuName = "StaticData/PlanetsGeneratorConfig")]
  public class PlanetsGeneratorConfig : ScriptableObject
  {
    public int minRadius;
    public int maxRadius;
    public int countPlanets;
  }
}