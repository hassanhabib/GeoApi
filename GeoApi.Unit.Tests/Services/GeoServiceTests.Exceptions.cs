// ---------------------------------------------------------------
// Copyright (c) PiorSoft, LLC All rights reserved.
// ---------------------------------------------------------------

using GeoApi.Models.Exceptions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Runtime.Serialization;
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

        [Fact]
        public void ShouldThrowServiceExceptionOnRetrieveAllWhenServiceErrorOccursAndLogIt()
        {
            // given
            var serviceException = new Exception();
            var expectedGeoServiceException = new GeoServiceException(serviceException);

            this.storageBrokerMock.Setup(broker =>
                broker.SelectAllGeos())
                    .Throws(serviceException);

            // when . then
            Assert.Throws<GeoServiceException>(() => this.geoService.RetrieveAllGeos());

            this.storageBrokerMock.Verify(broker =>
                broker.SelectAllGeos(),
                    Times.Once);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(expectedGeoServiceException))),
                    Times.Once);
        }

        [Fact]
        public void ShouldThrowDependencyExceptionOnRetrieveAllIfSqlExceptionWasThrownAndLogIt()
        {
            SqlException sqlException = CreateSqlException();
            var expectedGeoDependencyException = new GeoDependencyException(sqlException);

            this.storageBrokerMock.Setup(broker =>
                broker.SelectAllGeos())
                    .Throws(sqlException);

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
