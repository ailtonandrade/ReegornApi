using AuthApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReegornApi;
using ReegornApi.Services;

namespace AuthApi.Controllers
{
    [ApiController]
    [Route("acc")]
    public class AccountsController : Controller
    {
        [HttpPost]
        [Produces("application/json")]
        [Route("select-character")]
        public async Task<IActionResult> GetCharacterList(ObjectDataModel? obj)
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
