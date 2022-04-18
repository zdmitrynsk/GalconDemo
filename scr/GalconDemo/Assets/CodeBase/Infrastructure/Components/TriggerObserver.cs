using System;
using UnityEngine;

namespace CodeBase.Infrastructure.Components
{
  public class TriggerObserver : MonoBehaviour
  {
    public event Action<Collider> OnTriggeredEnter;
    
    private void OnTriggerEnter(Collider other)
    {
      OnTriggeredEnter?.Invoke(other);
    }
  }
}