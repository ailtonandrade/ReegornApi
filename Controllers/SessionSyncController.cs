using AuthApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReegornApi.Services;

namespace AuthApi.Controllers
{
    [ApiController]
    [Route("accounts")]
    public class SessionSyncController : Controller
    {
        [HttpPost]
        [Produces("application/json")]
        [Route("get-all")]
        [AllowAnonymous]
        public void getAllSessionl(AccountsModel? acc)
        {
            AccountsService service = new AccountsService();
            try
            {
                acc.accessKey = HashService.Encode(acc.accessKey);
                service.Create(acc);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }
        }
    }
}
