// ---------------------------------------------------------------
// Copyright (c) PiorSoft, LLC All rights reserved.
// ---------------------------------------------------------------

using GeoApi.Models;
using GeoApi.Models.Exceptions;
using System.Linq;

namespace GeoApi.Services
{
    public partial class GeoService
    {
        private void ValidateStorageGeos(IQueryable<Geo> storageGeos)
        {
            if (storageGeos.Count() == 0)
            {
                throw new EmptyGeosException();
            }
        }
    }
}
