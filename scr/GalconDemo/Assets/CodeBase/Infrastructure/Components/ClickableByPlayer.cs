using CodeBase.Infrastructure.Services;
using UnityEngine;

namespace CodeBase.Infrastructure.Components
{
  [RequireComponent(typeof(ClickObserver))]
  [RequireComponent(typeof(PlanetDataHolder))]
  public class ClickableByPlayer : MonoBehaviour
  {
    [SerializeField] private ClickObserver clickObserver;
    [SerializeField] private PlanetDataHolder _planetDataHolder;
    private ISelectPlanetsService _selectPlanetsService;

    public void Construct(ISelectPlanetsService selectPlanetsService)
    {
      _selectPlanetsService = selectPlanetsService;
    }
    
    private void Awake()
    {
      clickObserver.OnClicked += OnClicked;
    }

    private void OnDestroy()
    {
      clickObserver.OnClicked -= OnClicked;
    }

    private void OnClicked() => 
      _selectPlanetsService.Click(_planetDataHolder.PlanetData);
  }
}