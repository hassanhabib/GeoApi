// ---------------------------------------------------------------
// Copyright (c) PiorSoft, LLC All rights reserved.
// ---------------------------------------------------------------

using FluentAssertions;
using GeoApi.Models;
using Moq;
using System.Linq;
using Xunit;

namespace GeoApi.Unit.Tests.Services
{
    public partial class GeoServiceTests
    {
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
    }
}
