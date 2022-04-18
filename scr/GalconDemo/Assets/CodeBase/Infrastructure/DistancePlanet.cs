namespace CodeBase.Infrastructure
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