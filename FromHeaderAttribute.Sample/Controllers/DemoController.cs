using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FromHeaderAttribute.Sample.Models;

namespace FromHeaderAttribute.Sample.Controllers
{
    [RoutePrefix("demo")]
    public class DemoController : ApiController
    {
        [HttpGet]
        [Route("headers")]
        public IHttpActionResult EchoHeaders([RedRiver.FromHeaderAttribute.FromHeader]StandardHeaders headers)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            return Json(new
            {
                yourUserAgent = headers.UserAgent,
                whatYouAccept = headers.Accept
            });
        }

        [HttpGet]
        [Route("penguinOnlyInformation")]
        public IHttpActionResult GetPenguinOnlyInformation([RedRiver.FromHeaderAttribute.FromHeader]PenguinProofHeaders headers)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            return Json(new
            {
                secretPenguinMessage = "Wenk!"
            });
        }
    }
}
