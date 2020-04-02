// ---------------------------------------------------------------
// Copyright (c) PiorSoft, LLC All rights reserved.
// ---------------------------------------------------------------

using System;

namespace GeoApi.Models.Exceptions
{
    public class GeoServiceException : Exception
    {
        public GeoServiceException(Exception innerException)
           : base("Service exception occurred, contact support", innerException)
        {
        }
    }
}
