using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CodeBase.Infrastructure.Components
{
  public class ClickObserver : MonoBehaviour, IPointerClickHandler
  {
    public event Action OnClicked;

    public void OnPointerClick(PointerEventData eventData)
    {
      OnClicked?.Invoke();
    }
    
  }
}