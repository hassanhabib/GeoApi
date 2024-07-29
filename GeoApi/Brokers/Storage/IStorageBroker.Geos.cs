// ---------------------------------------------------------------
// Copyright (c) PiorSoft, LLC All rights reserved.
// ---------------------------------------------------------------

using System.Linq;
using System.Threading.Tasks;
using GeoApi.Models;

namespace GeoApi.Brokers.Storage
{
    public partial interface IStorageBroker
    {
        IQueryable<Geo> SelectAllGeos();
        ValueTask<IQueryable<Geo>> SelectAllGeosAsync();
    }
}
