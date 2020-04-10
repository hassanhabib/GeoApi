// ---------------------------------------------------------------
// Copyright (c) PiorSoft, LLC All rights reserved.
// ---------------------------------------------------------------

using System.Linq;
using GeoApi.Models;
using GeoApi.Models.Exceptions;

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
