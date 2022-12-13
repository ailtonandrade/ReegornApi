using AuthApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReegornApi.Services;

namespace AuthApi.Controllers
{
    [ApiController]
    [Route("BroadcastingCharacterWorld")]
    public class BroadcastingCharacterWorldController : Controller
    {
        [HttpPost]
        [Produces("application/json")]
        [Route("update")]
        [AllowAnonymous]
        public async Task<IActionResult> BroadcastingCharacterWorldAsync(string? idSession)
        {
            BroadcastingCharacterWorldService service = new BroadcastingCharacterWorldService();
            try
            {
                List<BroadcastCharacterModel> model = await service.SelectCharacterWorld(idSession);
                return Json(model);        
    }
            catch(Exception ex)
            {

                throw new Exception(ex.Message);
                
            }
        }
    }
}
