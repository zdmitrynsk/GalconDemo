using UnityEngine;

namespace CodeBase.Infrastructure.Services
{
  public class RandomUnityService : IRandomService
  {
    public int Next(int min, int max) => 
      Random.Range(min, max);
  }
}