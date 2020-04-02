// ---------------------------------------------------------------
// Copyright (c) PiorSoft, LLC All rights reserved.
// ---------------------------------------------------------------

using GeoApi.Models;
using System.Linq;

namespace GeoApi.Brokers.Storage
{
    public partial interface IStorageBroker
    {
        IQueryable<Geo> SelectAllGeos();
    }
}
