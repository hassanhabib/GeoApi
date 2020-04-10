// ---------------------------------------------------------------
// Copyright (c) PiorSoft, LLC All rights reserved.
// ---------------------------------------------------------------

using System.Linq;
using GeoApi.Models;

namespace GeoApi.Services
{
    public interface IGeoService
    {
        IQueryable<Geo> RetrieveAllGeos();
    }
}
