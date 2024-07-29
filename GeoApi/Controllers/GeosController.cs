// ---------------------------------------------------------------
// Copyright (c) PiorSoft, LLC All rights reserved.
// ---------------------------------------------------------------

using System.Linq;
using System.Threading.Tasks;
using GeoApi.Models;
using GeoApi.Models.Exceptions;
using GeoApi.Services;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;

namespace GeoApi.Controllers
{
    [ApiController]
    public class GeosController : ControllerBase
    {
        private readonly IGeoService geoService;
        public GeosController(IGeoService geoService) => this.geoService = geoService;

        [HttpGet]
        [Route("api/geos")]
        [EnableQuery]
        public ActionResult<IQueryable<Geo>> Get()
        {
            try
            {
                IQueryable<Geo> allGeos = this.geoService.RetrieveAllGeos();

                return Ok(allGeos);
            }
            catch (GeoDependencyException geoDependencyException)
            {
                return Problem(geoDependencyException.Message);
            }
            catch (GeoServiceException geoServiceException)
            {
                return Problem(geoServiceException.Message);
            }
        }

        [HttpGet]
        [Route("api/v2/geos")]
        [EnableQuery]
        public async ValueTask<ActionResult<IQueryable<Geo>>> GetAsync()
        {
            try
            {
                IQueryable<Geo> allGeos = 
                    await this.geoService.RetrieveAllGeosAsync();

                return Ok(allGeos);
            }
            catch (GeoDependencyException geoDependencyException)
            {
                return Problem(geoDependencyException.Message);
            }
            catch (GeoServiceException geoServiceException)
            {
                return Problem(geoServiceException.Message);
            }
        }
    }
}