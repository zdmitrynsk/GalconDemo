using CodeBase.Infrastructure.Data;

namespace CodeBase.Infrastructure.Services
{
  public class RunnerStarshipsService : IRunnerStarshipsService 
  {
    private readonly ISelectPlanetsService _selectPlanetsService;
    private readonly IGameFactory _gameFactory;

    public RunnerStarshipsService(ISelectPlanetsService selectPlanetsService, IGameFactory gameFactory)
    {
      _selectPlanetsService = selectPlanetsService;
      _gameFactory = gameFactory;
    }

    public void Init()
    {
      _selectPlanetsService.OnInitiatedRunStarships += OnInitiatedRunStarships;
    }

    private void OnInitiatedRunStarships(PlanetData source, PlanetData target)
    {
      int countNewStarships = (int)(source.CountStarships * 0.5f);
      source.SetStarships(source.CountStarships - countNewStarships);
      _gameFactory.RunStarships(source, target, countNewStarships);
    }
  }
}