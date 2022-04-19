using CodeBase.Infrastructure.Data;

namespace CodeBase.Infrastructure.PlanetsGenerator
{
  public class DistancePlanet
  {
    public readonly PlanetData Planet;
    public readonly float Distance;

    public DistancePlanet(PlanetData planet, float distance)
    {
      Planet = planet;
      Distance = distance;
    }
  }
}