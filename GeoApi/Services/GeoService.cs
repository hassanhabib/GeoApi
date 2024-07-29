// ---------------------------------------------------------------
// Copyright (c) PiorSoft, LLC All rights reserved.
// ---------------------------------------------------------------

using System.Linq;
using System.Threading.Tasks;
using GeoApi.Brokers.Logging;
using GeoApi.Brokers.Storage;
using GeoApi.Models;

namespace GeoApi.Services
{
    public partial class GeoService : IGeoService
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

        public IQueryable<Geo> RetrieveAllGeos() => 
        TryCatch(() =>
        {
            IQueryable<Geo> storageGeos =
                this.storageBroker.SelectAllGeos();

            return storageGeos;
        });

        public ValueTask<IQueryable<Geo>> RetrieveAllGeosAsync() => 
        TryCatch(async () =>
        {
            IQueryable<Geo> storageGeos = 
                await this.storageBroker.SelectAllGeosAsync();

            return storageGeos;
        });
    }
}
