using CodeBase.Infrastructure.Data;
using UnityEngine;

namespace CodeBase.Infrastructure.Components
{
  public class PlanetDataHolder : MonoBehaviour
  {
    public PlanetData PlanetData;

    public void Construct(PlanetData planetData)
    {
      PlanetData = planetData;
    }
  }
}