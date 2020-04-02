// ---------------------------------------------------------------
// Copyright (c) PiorSoft, LLC All rights reserved.
// ---------------------------------------------------------------

using Microsoft.AspNetCore.Mvc;

namespace GeoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get() =>
            Ok("Sorry Mario, the princess is in another castle!");
    }
}