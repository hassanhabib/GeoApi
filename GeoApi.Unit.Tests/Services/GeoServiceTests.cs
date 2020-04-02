// ---------------------------------------------------------------
// Copyright (c) PiorSoft, LLC All rights reserved.
// ---------------------------------------------------------------

using System.Linq;
using GeoApi.Brokers.Logging;
using GeoApi.Brokers.Storage;
using GeoApi.Models;
using GeoApi.Services;
using Moq;
using Tynamix.ObjectFiller;

namespace GeoApi.Unit.Tests.Services
{
    public partial class GeoServiceTests
    {
        private readonly Mock<IStorageBroker> storageBrokerMock;
        private readonly Mock<ILoggingBroker> loggingBrokerMock;
        private readonly IGeoService geoService;

        public GeoServiceTests()
        {
            this.storageBrokerMock = new Mock<IStorageBroker>();
            this.loggingBrokerMock = new Mock<ILoggingBroker>();

            this.geoService = new GeoService(
                this.storageBrokerMock.Object,
                this.loggingBrokerMock.Object);
        }

        private IQueryable<Geo> CreateRandomGeos()
        {
            int randomGeoCount = new IntRange().GetValue();
            Filler<Geo> geoFiller = CreateGeoFiller();

            return geoFiller.Create(randomGeoCount).AsQueryable();
        }

        private Filler<Geo> CreateGeoFiller() => new Filler<Geo>();
    }
}
