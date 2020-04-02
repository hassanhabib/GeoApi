// ---------------------------------------------------------------
// Copyright (c) PiorSoft, LLC All rights reserved.
// ---------------------------------------------------------------

using GeoApi.Brokers.Logging;
using GeoApi.Brokers.Storage;
using GeoApi.Models;
using GeoApi.Services;
using Moq;
using System;
using System.Linq;
using System.Linq.Expressions;
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
            int randomGeoCount = new IntRange(min: 3, max: 10).GetValue();
            Filler<Geo> geoFiller = CreateGeoFiller();

            return geoFiller.Create(randomGeoCount).AsQueryable();
        }

        private Filler<Geo> CreateGeoFiller()
        {
            var filler = new Filler<Geo>();
            
            filler.Setup()
                .OnProperty(geo => geo.City).Use(new CityName());

            return filler;
        }
        private Expression<Func<Exception, bool>> SameExceptionAs(Exception expectedException)
        {
            return actualException => actualException.Message == expectedException.Message
                && actualException.InnerException.Message == expectedException.InnerException.Message;
        }
    }
}
