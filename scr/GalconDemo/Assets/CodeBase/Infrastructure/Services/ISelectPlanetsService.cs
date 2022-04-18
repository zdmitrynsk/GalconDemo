using System;
using CodeBase.Infrastructure.Data;

namespace CodeBase.Infrastructure.Services
{
  public interface ISelectPlanetsService
  {
    void Click(PlanetData ClickedPlanet);
    event Action<PlanetData, PlanetData> OnInitiatedRunStarships;
  }
}