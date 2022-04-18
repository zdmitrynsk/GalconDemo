using UnityEngine;

namespace CodeBase.Infrastructure.StaticData
{
  [CreateAssetMenu(fileName = "PlanetsGeneratorConfig", menuName = "StaticData/PlanetsGeneratorConfig")]
  public class GameConfig : ScriptableObject
  {
    public int minRadius = 100;
    public int maxRadius = 150;
    public int countPlanets = 15;
    public int minStartStarships = 15;
    public int maxStartStarships = 100;

    public int starshipsPerSecond = 5;
    public int countStartPlayerStarships = 50;
  }
}