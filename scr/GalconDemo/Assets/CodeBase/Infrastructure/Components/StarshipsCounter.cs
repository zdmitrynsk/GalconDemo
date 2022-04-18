using CodeBase.Infrastructure.Data;
using TMPro;
using UnityEngine;

namespace CodeBase.Infrastructure.Components
{
  [RequireComponent(typeof(PlanetDataHolder))]
  internal class StarshipsCounter : MonoBehaviour
  {
    [SerializeField] private TextMeshPro Counter;
    [SerializeField] private PlanetDataHolder _planetDataHolder;

    public void Init()
    {
      _planetDataHolder.PlanetData.OnChangedCountStarships += OnChangedCountStarships;
      UpdateCounter();
    }

    private void OnDestroy()
    {
      _planetDataHolder.PlanetData.OnChangedCountStarships -= OnChangedCountStarships;
    }

    private void OnChangedCountStarships(PlanetData obj) => 
      UpdateCounter();

    private void UpdateCounter() => 
      Counter.SetText(_planetDataHolder.PlanetData.CountStarships.ToString());
  }
}