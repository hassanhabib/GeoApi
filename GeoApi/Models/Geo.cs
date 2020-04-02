// ---------------------------------------------------------------
// Copyright (c) PiorSoft, LLC All rights reserved.
// ---------------------------------------------------------------

using System;

namespace GeoApi.Models
{
    public class Geo
    {
        public Guid Id { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public int ZipCode { get; set; }
    }
}
