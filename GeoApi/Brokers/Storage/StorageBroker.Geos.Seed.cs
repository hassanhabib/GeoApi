// ---------------------------------------------------------------
// Copyright (c) PiorSoft, LLC All rights reserved.
// ---------------------------------------------------------------

using System;
using GeoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GeoApi.Brokers.Storage
{
    public partial class StorageBroker
    {
        private static void SeedGeos(ModelBuilder modelBuilder)
        {
            var geo = new Geo
            {
                Id = Guid.Parse("0bbef118-c9cb-426f-bed2-2f5648a98035"),
                City = "Redmond",
                State = "WA",
                Latitude = 47.671796,
                Longitude = -122.123242,
                ZipCode = 98052
            };

            modelBuilder.Entity<Geo>().HasData(geo);
        }
    }
}
