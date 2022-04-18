using UnityEngine;

namespace CodeBase.Infrastructure.StaticData
{
  public class StaticDataService : IStaticDataService
  {
    public GameConfig GameConfig { get; private set; } 
    
    public void Load()
    {
      GameConfig = Resources.Load<GameConfig>("StaticData/PlanetsGeneratorConfig");
    }
  }
}