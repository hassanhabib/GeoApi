// ---------------------------------------------------------------
// Copyright (c) PiorSoft, LLC All rights reserved.
// ---------------------------------------------------------------

using System;

namespace GeoApi.Models.Exceptions
{
    public class EmptyGeosException : Exception
    {
        public EmptyGeosException()
            : base("Empty Geos error occurred, contact support.")
        {
        }
    }
}
