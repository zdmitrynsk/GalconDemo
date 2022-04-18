using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.StaticData;

namespace CodeBase.Infrastructure.Services
{
  public class ServiceLocator : IServiceLocator
  {
    public IStaticDataService StaticDataService { get; private set; }
    public IRandomService RandomUnityService { get; private set; }
    
    public IGameFactory GameFactory { get; private set; }
    public IAssetProvider AssetProvider { get; private set; }

    public void Init()
    {
      InitStaticDataService();
      RandomUnityService = new RandomUnityService();
      AssetProvider = new AssetProvider();
      GameFactory = new GameFactory(AssetProvider, StaticDataService);
    }

    private void InitStaticDataService()
    {
      StaticDataService = new StaticDataService();
      StaticDataService.Load();
    }
  }
}