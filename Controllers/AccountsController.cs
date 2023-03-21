using Microsoft.AspNetCore.Mvc;
using ReegornApi;
using ReegornApi.Services;
using System;
using System.Threading.Tasks;

namespace AuthApi.Controllers
{
    [ApiController]
    [Route("acc")]
    public class AccountsController : Controller
    {
        [HttpPost]
        [Produces("application/json")]
        [Route("select-character")]
        public async Task<IActionResult> GetCharacterList(UserModel? obj)
        {
            AccountsService service = new AccountsService();
            try
            {
                return Json(await service.GetCharacterList(obj));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
