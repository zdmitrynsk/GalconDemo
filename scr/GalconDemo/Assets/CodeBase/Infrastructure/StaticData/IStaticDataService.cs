﻿namespace CodeBase.Infrastructure.StaticData
{
  public interface IStaticDataService
  {
    void Load();
    PlanetsGeneratorConfig PlanetsGenerator { get; }
  }
}