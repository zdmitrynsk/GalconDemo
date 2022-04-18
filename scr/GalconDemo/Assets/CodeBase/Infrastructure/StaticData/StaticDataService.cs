using UnityEngine;

namespace CodeBase.Infrastructure.StaticData
{
  public class StaticDataService : IStaticDataService
  {
    public PlanetsGeneratorConfig PlanetsGenerator { get; private set; } 
    
    public void Load()
    {
      PlanetsGenerator = Resources.Load<PlanetsGeneratorConfig>("StaticData/PlanetsGeneratorConfig");
    }
  }
}