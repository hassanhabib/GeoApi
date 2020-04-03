// ---------------------------------------------------------------
// Copyright (c) PiorSoft, LLC All rights reserved.
// ---------------------------------------------------------------

using System.Linq;
using GeoApi.Models;
using GeoApi.Models.Exceptions;
using GeoApi.Services;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;

namespace GeoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeosController : ControllerBase
    {
        private readonly IGeoService geoService;
        public GeosController(IGeoService geoService) => this.geoService = geoService; 

        [HttpGet]
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
    }
}