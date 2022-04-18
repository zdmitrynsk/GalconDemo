using System;
using CodeBase.Infrastructure.Data;

namespace CodeBase.Infrastructure.Services
{

  class SelectPlanetsService : ISelectPlanetsService
  {
    private PlanetData _lastSelectedPlanet;
    private IGameFactory _gameFactory;

    public event Action<PlanetData, PlanetData> OnInitiatedRunStarships;

    public void Click(PlanetData ClickedPlanet)
    {
      _lastSelectedPlanet?.SetSelected(false);
      if (ClickedPlanet.Owner == OwnerType.Player && !ClickedPlanet.IsSelected)
      {
        ClickedPlanet.SetSelected(true);
        _lastSelectedPlanet = ClickedPlanet;
      }
      else if (ClickedPlanet.Owner == OwnerType.Player && ClickedPlanet.IsSelected)
      {
        ClickedPlanet.SetSelected(false);
        _lastSelectedPlanet = null;
      }
      else if (ClickedPlanet.Owner != OwnerType.Player && _lastSelectedPlanet != null)
      {
        OnInitiatedRunStarships?.Invoke(_lastSelectedPlanet, ClickedPlanet);
      }
    }
  }
}