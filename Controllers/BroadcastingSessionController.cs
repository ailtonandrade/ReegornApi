using AuthApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReegornApi.Services;

namespace AuthApi.Controllers
{
    [ApiController]
    [Route("broadcastingSessionWorld")]
    public class BroadcastingSessionWorldController : Controller
    {
        [HttpPost]
        [Produces("application/json")]
        [Route("")]
        [AllowAnonymous]
        public IActionResult BroadcastingSessionWorld(long? idSession)
        {
            BroadcastingSessionWorldService service = new BroadcastingSessionWorldService();
            var response = service.GetById(idSession);
            if (response.IsCompletedSuccessfully)
            {
                return Json(response.Result);
            }
            return Json(new { message = "Erro ao buscar objetos do ambiente" });
        }
    }
}
