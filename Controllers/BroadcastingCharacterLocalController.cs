using AuthApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthApi.Controllers
{
    [ApiController]
    [Route("brdcst")]
    public class BroadcastingCharacterLocalController : Controller
    {
        [HttpPost]
        [Produces("application/json")]
        [Route("brod-ch-lo")]
        [AllowAnonymous]
        public IActionResult MovChLo(BroadcastCharacterModel? obj)
        {
            try
            {

                return Json(obj);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Json(ex.Message);
            }
        }
    }
}
