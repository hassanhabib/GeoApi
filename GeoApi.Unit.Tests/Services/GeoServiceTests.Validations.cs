// ---------------------------------------------------------------
// Copyright (c) PiorSoft, LLC All rights reserved.
// ---------------------------------------------------------------

using GeoApi.Models;
using GeoApi.Models.Exceptions;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace GeoApi.Unit.Tests.Services
{
    public partial class GeoServiceTests
    {
        [Fact]
        public void ShouldThrowEmptyGeosExceptionOnRetrieveIfStorageWasEmptyAndLogIt()
        {
            // given
            IQueryable<Geo> emptyGeos = new List<Geo>().AsQueryable();
            IQueryable<Geo> storageGeos = emptyGeos;
            var emptyGeosException = new EmptyGeosException();
            var expectedGeoDependencyException = new GeoDependencyException(emptyGeosException);

            this.storageBrokerMock.Setup(broker =>
               broker.SelectAllGeos())
                   .Returns(storageGeos);

            // when . then
            Assert.Throws<GeoDependencyException>(() => this.geoService.RetrieveAllGeos());

            this.storageBrokerMock.Verify(broker =>
                broker.SelectAllGeos(),
                    Times.Once);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogCritical(It.Is(SameExceptionAs(expectedGeoDependencyException))),
                    Times.Once);
        }
    }
}
