using CodeBase.Infrastructure.Data;
using UnityEngine;

namespace CodeBase.Infrastructure.Components
{
  [RequireComponent(typeof(PlanetDataHolder))]
  public class OwnerViewer : MonoBehaviour
  {
    [SerializeField] private PlanetDataHolder _planetDataHolder;
    [SerializeField] private SpriteRenderer _planetRenderer;
    [SerializeField] private Color _defaultColor;
    [SerializeField] private Color _playerColor;

    public void Init()
    {
      _planetDataHolder.PlanetData.OnChangedOwner += OnChangedOwner;
      UpdateOwnerView();
    }

    private void OnDestroy()
    {
      _planetDataHolder.PlanetData.OnChangedOwner -= OnChangedOwner;
    }

    private void OnChangedOwner(PlanetData planet) => 
      UpdateOwnerView();

    private void UpdateOwnerView()
    {
      if (_planetDataHolder.PlanetData.Owner == OwnerType.None)
        _planetRenderer.color = _defaultColor;
      else if (_planetDataHolder.PlanetData.Owner == OwnerType.Player)
        _planetRenderer.color = _playerColor;
    }
  }
}