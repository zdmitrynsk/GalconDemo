using CodeBase.Infrastructure.Services;
using UnityEngine;

namespace CodeBase.Infrastructure
{
  public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
  {
    private Game _game;

    private void Awake()
    {
      _game = new Game(CreateServiceLocator(), this);
      _game.Start();
      
      DontDestroyOnLoad(this);
    }

    private static IServiceLocator CreateServiceLocator()
    {
      IServiceLocator serviceLocator = new ServiceLocator();
      serviceLocator.Init();
      return serviceLocator;
    }
  }
}