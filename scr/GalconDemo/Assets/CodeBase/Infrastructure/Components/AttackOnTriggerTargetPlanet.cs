using CodeBase.Infrastructure.Data;
using UnityEngine;

namespace CodeBase.Infrastructure.Components
{
  public class AttackOnTriggerTargetPlanet : MonoBehaviour
  {
    [SerializeField] private TriggerObserver _triggerObserver;
    private PlanetData _targetPlanet;

    public void Construct(PlanetData planetData)
    {
      _targetPlanet = planetData;
    }
    
    private void Awake()
    {
      _triggerObserver.OnTriggeredEnter += OnTriggeredEnter;
    }

    private void OnTriggeredEnter(Collider obj)
    {
      PlanetDataHolder dataHolder = obj.gameObject.GetComponent<PlanetDataHolder>();
      PlanetData collidedPlanet = dataHolder.PlanetData;
      
      if (collidedPlanet == _targetPlanet && collidedPlanet.Owner != OwnerType.Player)
      {
        int newCountStarships = collidedPlanet.CountStarships - 1;
        collidedPlanet.SetStarships(newCountStarships);
        if (newCountStarships < 0)
          collidedPlanet.SetOwner(OwnerType.Player);
        Destroy(gameObject);
      }
      else if (collidedPlanet == _targetPlanet && collidedPlanet.Owner == OwnerType.Player)
      {
        collidedPlanet.SetStarships(collidedPlanet.CountStarships + 1);
        Destroy(gameObject);
      }
    }
  }
}