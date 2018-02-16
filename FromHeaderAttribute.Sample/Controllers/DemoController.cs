using FromHeaderAttribute.Sample.Models;
using System.Web.Http;

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

        [Route("")]
        public string PostEcho([RedRiver.FromHeaderAttribute.FromHeader]string test)
        {
            return test;
        }
    }
}
