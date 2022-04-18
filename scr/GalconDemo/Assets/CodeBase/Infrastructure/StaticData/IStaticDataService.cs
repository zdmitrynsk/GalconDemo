namespace CodeBase.Infrastructure.StaticData
{
  public interface IStaticDataService
  {
    void Load();
    GameConfig GameConfig { get; }
  }
}