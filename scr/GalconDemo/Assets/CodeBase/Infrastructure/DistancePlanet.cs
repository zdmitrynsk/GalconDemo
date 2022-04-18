namespace CodeBase.Infrastructure
{
  public class DistancePlanet
  {
    public readonly PlanetInfo Planet;
    public readonly float Distance;

    public DistancePlanet(PlanetInfo planet, float distance)
    {
      Planet = planet;
      Distance = distance;
    }
  }
}