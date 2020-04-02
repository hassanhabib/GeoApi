// ---------------------------------------------------------------
// Copyright (c) PiorSoft, LLC All rights reserved.
// ---------------------------------------------------------------

using System;

namespace GeoApi.Models.Exceptions
{
    public class GeoDependencyException : Exception
    {
        public GeoDependencyException(Exception innerException)
            : base("Validation exception occurred, contact support", innerException)
        {
        }
    }
}
