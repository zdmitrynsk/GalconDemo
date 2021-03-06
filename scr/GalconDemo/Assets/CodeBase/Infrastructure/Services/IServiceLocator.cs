using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.StaticData;

namespace CodeBase.Infrastructure.Services
{
  public interface IServiceLocator
  {
    IStaticDataService StaticDataService { get; }
    IRandomService RandomUnityService { get; }
    IGameFactory GameFactory { get; }
    IAssetProvider AssetProvider { get; }
    IStarshipsGenerator StarshipsGenerator { get; }
    ICoroutineRunner CoroutineRunner { get; }
    void Init(ICoroutineRunner coroutineRunner);
  }
}