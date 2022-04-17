using CodeBase.Infrastructure.StaticData;

namespace CodeBase.Infrastructure.Services
{
  public class ServiceLocator : IServiceLocator
  {
    public IStaticDataService StaticDataService { get; private set; }

    public void Init()
    {
      InitStaticDataService();
    }

    private void InitStaticDataService()
    {
      StaticDataService = new StaticDataService();
      StaticDataService.Load();
    }
  }
}