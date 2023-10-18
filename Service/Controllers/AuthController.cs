using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Service.Controllers
{
    public class AuthController : ControllerBase
    {

        [HttpGet]
        [Route("auth/open")]
        public ActionResult GetSemAutenticacao()
        {
            return Ok("Rota sem autenticação");        
        }

        [HttpGet]
        [Authorize]
        [Route("auth/protected")]
        public ActionResult ProtectedRoute()
        {
            return Ok("Metodo com autenticação");
        }

    }
}
