﻿using System.Collections.Generic;

namespace CodeBase.Infrastructure
{
  public interface IPlanetsGenerator
  {
    public List<PlanetInfo> Create();
  }
}