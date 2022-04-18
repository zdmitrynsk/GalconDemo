using System.Collections.Generic;
using CodeBase.Infrastructure.Data;

namespace CodeBase.Infrastructure.Services
{
  public interface IStarshipsGenerator
  {
    void Start(List<PlanetData> planets);
  }
}