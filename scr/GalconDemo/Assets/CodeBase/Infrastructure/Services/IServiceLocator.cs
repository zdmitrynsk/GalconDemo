using CodeBase.Infrastructure.StaticData;

namespace CodeBase.Infrastructure.Services
{
  public interface IServiceLocator
  {
    IStaticDataService StaticDataService { get; }
    IRandomService RandomUnityService { get; }
    void Init();
  }
}