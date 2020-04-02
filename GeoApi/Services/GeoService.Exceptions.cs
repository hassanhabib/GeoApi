// ---------------------------------------------------------------
// Copyright (c) PiorSoft, LLC All rights reserved.
// ---------------------------------------------------------------

using System;
using System.Linq;
using GeoApi.Models;
using GeoApi.Models.Exceptions;

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
        }

        private GeoDependencyException CreateAndLogCriticalDependencyException(Exception exception)
        {
            var geoDependencyException = new GeoDependencyException(exception);
            this.loggingBroker.LogCritical(geoDependencyException);

            return geoDependencyException;
        }
    }
}
