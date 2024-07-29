// ---------------------------------------------------------------
// Copyright (c) PiorSoft, LLC All rights reserved.
// ---------------------------------------------------------------

using System.Linq;
using System.Threading.Tasks;
using GeoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GeoApi.Brokers.Storage
{
    public partial class StorageBroker
    {
        public DbSet<Geo> Geos { get; set; }

        public IQueryable<Geo> SelectAllGeos() => 
            this.Geos;

        public async ValueTask<IQueryable<Geo>> SelectAllGeosAsync() =>
            this.Geos;
    }
}