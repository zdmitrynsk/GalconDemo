using CodeBase.Infrastructure.Data;
using UnityEngine;

namespace CodeBase.Infrastructure.Components
{
  [RequireComponent(typeof(PlanetDataHolder))]
  public class SelectorView : MonoBehaviour
  {

    [SerializeField] private GameObject selectedView;
    [SerializeField] private PlanetDataHolder _planetDataHolder;

    public void Init()
    {
      _planetDataHolder.PlanetData.OnChangedSelect += OnChangedSelect;
      UpdateSelected();
    }

    private void OnDestroy()
    {
      _planetDataHolder.PlanetData.OnChangedSelect -= OnChangedSelect;
    }

    private void OnChangedSelect(PlanetData obj) => 
      UpdateSelected();

    private void UpdateSelected() => 
      selectedView.SetActive(_planetDataHolder.PlanetData.IsSelected);
  }
}