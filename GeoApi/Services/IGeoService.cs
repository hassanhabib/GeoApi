// ---------------------------------------------------------------
// Copyright (c) PiorSoft, LLC All rights reserved.
// ---------------------------------------------------------------

using GeoApi.Models;
using System.Linq;

namespace GeoApi.Services
{
    public interface IGeoService
    {
        IQueryable<Geo> RetrieveAllGeos();
    }
}
