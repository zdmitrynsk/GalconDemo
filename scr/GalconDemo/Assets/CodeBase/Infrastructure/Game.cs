using CodeBase.Infrastructure.Services;

namespace CodeBase.Infrastructure
{
  public class Game
  {
    public Game(IServiceLocator serviceLocator, ICoroutineRunner coroutineRunner)
    {
      var planetsGenerator = new PlanetsGenerator(
        serviceLocator.StaticDataService
        , serviceLocator.RandomUnityService);
      planetsGenerator.Create();
    }
  }
}