using AuthApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReegornApi.Services;

namespace AuthApi.Controllers
{
    [ApiController]
    [Route("PlayerLocalSync")]
    public class PlayerLocalSyncController : Controller
    {
        [HttpPost]
        [Produces("application/json")]
        [Route("getall")]
        [AllowAnonymous]
        public void getAllPlayer(string? idSession)
        {
            AccountsService service = new AccountsService();
            try
            {
                //acc.accessKey = HashService.Encode(acc.accessKey);
                //service.Create(acc);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }
        }
    }
}
