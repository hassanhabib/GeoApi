// ---------------------------------------------------------------
// Copyright (c) PiorSoft, LLC All rights reserved.
// ---------------------------------------------------------------

using System.Collections.Generic;
using System.IO;
using GeoApi.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace GeoApi.Brokers.Storage
{
    public partial class StorageBroker
    {
        private static void SeedGeos(ModelBuilder modelBuilder)
        {
            var jsonData = File.ReadAllText(@"AllData.json");
            List<Geo> allGeos = JsonConvert.DeserializeObject<List<Geo>>(jsonData);
            modelBuilder.Entity<Geo>().HasData(allGeos);

        }
    }
}
