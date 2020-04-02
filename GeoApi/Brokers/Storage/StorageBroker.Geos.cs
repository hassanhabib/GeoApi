// ---------------------------------------------------------------
// Copyright (c) PiorSoft, LLC All rights reserved.
// ---------------------------------------------------------------

using GeoApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GeoApi.Brokers.Storage
{
    public partial class StorageBroker
    {
        public DbSet<Geo> Geos { get; set; }

        public IQueryable<Geo> SelectAllGeos() => this.Geos.AsQueryable();
    }
}