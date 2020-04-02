// ---------------------------------------------------------------
// Copyright (c) PiorSoft, LLC All rights reserved.
// ---------------------------------------------------------------

using GeoApi.Models;
using GeoApi.Models.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace GeoApi.Services
{
    public partial class GeoService
    {
        private delegate IQueryable<Geo> ReturningGeosFunction();

        private IQueryable<Geo> TryCatch(ReturningGeosFunction returningGeosFunction)
        {
            try
            {
                return returningGeosFunction();
            }
            catch (EmptyGeosException emptyGeosException)
            {
                throw CreateAndLogCriticalDependencyException(emptyGeosException);
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw CreateAndLogDependencyException(dbUpdateException);
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
    }
}
