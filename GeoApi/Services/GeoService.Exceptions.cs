// ---------------------------------------------------------------
// Copyright (c) PiorSoft, LLC All rights reserved.
// ---------------------------------------------------------------

using System;
using System.Linq;
using System.Threading.Tasks;
using GeoApi.Models;
using GeoApi.Models.Exceptions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace GeoApi.Services
{
    public partial class GeoService
    {
        private delegate IQueryable<Geo> ReturningGeosFunction();
        private delegate ValueTask<IQueryable<Geo>> ReturningGeosFunctionAsync();

        private IQueryable<Geo> TryCatch(ReturningGeosFunction returningGeosFunction)
        {
            try
            {
                return returningGeosFunction();
            }
            catch (SqlException sqlException)
            {
                throw CreateAndLogCriticalDependencyException(sqlException);
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw CreateAndLogDependencyException(dbUpdateException);
            }
            catch (EmptyGeosException emptyGeosException)
            {
                throw CreateAndLogCriticalDependencyException(emptyGeosException);
            }
            catch (Exception serviceException)
            {
                throw CreateAndLogServiceException(serviceException);
            }
        }

        private async ValueTask<IQueryable<Geo>> TryCatch(ReturningGeosFunctionAsync returningGeosFunction)
        {
            try
            {
                return await returningGeosFunction();
            }
            catch (SqlException sqlException)
            {
                throw CreateAndLogCriticalDependencyException(sqlException);
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw CreateAndLogDependencyException(dbUpdateException);
            }
            catch (EmptyGeosException emptyGeosException)
            {
                throw CreateAndLogCriticalDependencyException(emptyGeosException);
            }
            catch (Exception serviceException)
            {
                throw CreateAndLogServiceException(serviceException);
            }
        }


        private GeoDependencyException CreateAndLogCriticalDependencyException(Exception exception)
        {
            var geoDependencyException = new GeoDependencyException(exception);
            this.loggingBroker.LogCritical(geoDependencyException);

            return geoDependencyException;
        }

        private GeoDependencyException CreateAndLogDependencyException(Exception exception)
        {
            var geoDependencyException = new GeoDependencyException(exception);
            this.loggingBroker.LogError(geoDependencyException);

            return geoDependencyException;
        }

        private GeoServiceException CreateAndLogServiceException(Exception exception)
        {
            var geoServiceException = new GeoServiceException(exception);
            this.loggingBroker.LogError(geoServiceException);

            return geoServiceException;
        }
    }
}
