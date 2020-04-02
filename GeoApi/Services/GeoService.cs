// ---------------------------------------------------------------
// Copyright (c) PiorSoft, LLC All rights reserved.
// ---------------------------------------------------------------

using GeoApi.Brokers.Logging;
using GeoApi.Brokers.Storage;
using GeoApi.Models;
using System.Linq;

namespace GeoApi.Services
{
    public class GeoService : IGeoService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;

        public GeoService(
            IStorageBroker storageBroker,
            ILoggingBroker loggingBroker)
        {
            this.storageBroker = storageBroker;
            this.loggingBroker = loggingBroker;
        }

        public IQueryable<Geo> RetrieveAllGeos() => this.storageBroker.SelectAllGeos();
    }
}
