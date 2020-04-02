// ---------------------------------------------------------------
// Copyright (c) PiorSoft, LLC All rights reserved.
// ---------------------------------------------------------------

using GeoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GeoApi.Brokers.Storage
{
    public partial class StorageBroker
    {
        public DbSet<Geo> Geos { get; set; }
    }
}
