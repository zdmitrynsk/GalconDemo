using CodeBase.Infrastructure.Services;
using UnityEngine;

namespace CodeBase.Infrastructure
{
  public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
  {
    private Game _game;

    private void Awake()
    {
      _game = new Game(CreateServiceLocator());
      _game.Start();
      
      DontDestroyOnLoad(this);
    }

    private IServiceLocator CreateServiceLocator()
    {
      IServiceLocator serviceLocator = new ServiceLocator();
      serviceLocator.Init(this);
      return serviceLocator;
    }
  }
}