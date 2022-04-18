using System;
using UnityEngine;

namespace CodeBase.Infrastructure.Data
{
  public class PlanetData
  {
    public Vector2 Position;
    public int Radius;
    public int CountStarships;
    public OwnerType Owner;
    public bool IsSelected = false;

    public event Action<PlanetData> OnChangedCountStarships;
    public event Action<PlanetData> OnChangedOwner;
    public event Action<PlanetData> OnChangedSelect;

    public void SetStarships(int value)
    {
      CountStarships = value;
      OnChangedCountStarships?.Invoke(this);
    }
    
    public void AddStarships(int value)
    {
      CountStarships += value;
      OnChangedCountStarships?.Invoke(this);
    }

    public void SetOwner(OwnerType newOwner)
    {
      Owner = newOwner;
      OnChangedOwner?.Invoke(this);
    }

    public void SetSelected(bool value)
    {
      IsSelected = value;
      OnChangedSelect?.Invoke(this);
    }
  }
}