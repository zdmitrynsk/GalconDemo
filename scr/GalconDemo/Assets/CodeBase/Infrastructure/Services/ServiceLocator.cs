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
    public IPlanetSelectService PlanetSelectService  { get; private set; }
    public IStarshipsGenerator StarshipsGenerator { get; private set; }
    public ICoroutineRunner CoroutineRunner { get; private set; }
    public ISelectPlanetsService SelectPlanetsService { get; private set; }
    public IRunnerStarshipsService RunnerStarshipsService { get; private set; }

    public void Init(ICoroutineRunner coroutineRunner)
    {
      CoroutineRunner = coroutineRunner;
      InitStaticDataService();
      RandomUnityService = new RandomUnityService();
      AssetProvider = new AssetProvider();
      SelectPlanetsService = new SelectPlanetsService();
      GameFactory = new GameFactory(AssetProvider, StaticDataService, SelectPlanetsService);
      InitRunnerStarshipsService();
      PlanetSelectService = new PlanetSelectService();
      StarshipsGenerator = new StarshipsGenerator(CoroutineRunner, StaticDataService);
    }

    private void InitRunnerStarshipsService()
    {
      RunnerStarshipsService = new RunnerStarshipsService(SelectPlanetsService, GameFactory);
      RunnerStarshipsService.Init();
    }

    private void InitStaticDataService()
    {
      StaticDataService = new StaticDataService();
      StaticDataService.Load();
    }
  }
}