// ---------------------------------------------------------------
// Copyright (c) PiorSoft, LLC All rights reserved.
// ---------------------------------------------------------------

using System.Linq;
using FluentAssertions;
using GeoApi.Brokers.Logging;
using GeoApi.Brokers.Storage;
using GeoApi.Models;
using GeoApi.Services;
using Moq;
using Tynamix.ObjectFiller;
using Xunit;

namespace GeoApi.Unit.Tests
{
    public class GeoServiceTests
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

        [Fact]
        public void ShouldRetrieveAllGeos()
        {
            // given
            IQueryable<Geo> randomGeos = CreateRandomGeos();
            IQueryable<Geo> storageGeos = randomGeos;
            IQueryable<Geo> expectedGeos = storageGeos;

            this.storageBrokerMock.Setup(broker =>
                broker.SelectAllGeos())
                    .Returns(storageGeos);

            // when
            IQueryable<Geo> actualGeos = this.geoService.RetrieveAllGeos();

            // then
            actualGeos.Should().BeEquivalentTo(expectedGeos);

            this.storageBrokerMock.Verify(broker =>
                broker.SelectAllGeos(),
                    Times.Once);
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
