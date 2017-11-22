using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BeeCard.API.Controllers
{
    public class BaseController : ApiController
    {

        [HttpGet]
        [Route("api/token/validate")]
        public HttpResponseMessage ValidateToken()
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        public HttpResponseMessage SendResponse(HttpStatusCode statusCode, string message = null)
        {
            if (statusCode == HttpStatusCode.NotFound)
                return Request.CreateResponse(HttpStatusCode.NotFound, string.Empty);
            else
                return Request.CreateResponse(statusCode, new
                {
                    summary = message
                });
        }

    }
}
