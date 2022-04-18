﻿using System.Collections.Generic;
using CodeBase.Infrastructure.Data;

namespace CodeBase.Infrastructure
{
  public interface IPlanetsGenerator
  {
    public List<PlanetData> Create();
  }
}