// ---------------------------------------------------------------
// Copyright (c) PiorSoft, LLC All rights reserved.
// ---------------------------------------------------------------

using EFxceptions;
using Microsoft.EntityFrameworkCore;

namespace GeoApi.Brokers.Storage
{
    public partial class StorageBroker : EFxceptionsContext, IStorageBroker
    {
        public StorageBroker(DbContextOptions<StorageBroker> options)
            : base(options) => this.Database.Migrate();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedGeos(modelBuilder);
        }
    }
}
