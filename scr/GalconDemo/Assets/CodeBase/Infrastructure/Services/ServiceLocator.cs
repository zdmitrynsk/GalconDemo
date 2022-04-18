using CodeBase.Infrastructure.StaticData;

namespace CodeBase.Infrastructure.Services
{
  public class ServiceLocator : IServiceLocator
  {
    public IStaticDataService StaticDataService { get; private set; }
    public IRandomService RandomUnityService { get; private set; }

    public void Init()
    {
      InitStaticDataService();
      InitRandomUnityService();
    }

    private void InitRandomUnityService() => 
      RandomUnityService = new RandomUnityService();

    private void InitStaticDataService()
    {
      StaticDataService = new StaticDataService();
      StaticDataService.Load();
    }
  }
}