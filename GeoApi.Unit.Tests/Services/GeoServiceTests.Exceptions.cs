// ---------------------------------------------------------------
// Copyright (c) PiorSoft, LLC All rights reserved.
// ---------------------------------------------------------------

using GeoApi.Models.Exceptions;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace GeoApi.Unit.Tests.Services
{
    public partial class GeoServiceTests
    {
        [Fact]
        public void ShouldThrowDependencyExceptionOnRetrieveAllIfStorageFailsAndLogIt()
        {
            // given
            var dbUpdateException = new DbUpdateException();
            var expectedGeoDependencyException = new GeoDependencyException(dbUpdateException);

            this.storageBrokerMock.Setup(broker =>
                broker.SelectAllGeos())
                    .Throws(dbUpdateException);

            // when . then
            Assert.Throws<GeoDependencyException>(() => this.geoService.RetrieveAllGeos());

            this.storageBrokerMock.Verify(broker =>
                broker.SelectAllGeos(),
                    Times.Once);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(expectedGeoDependencyException))),
                    Times.Once);
        }
    }
}
