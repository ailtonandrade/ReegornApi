using AuthApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReegornApi.Services;

namespace AuthApi.Controllers
{
    [ApiController]
    [Route("accounts")]
    public class AccountsController : Controller
    {
        [HttpPost]
        [Produces("application/json")]
        [Route("create")]
        [AllowAnonymous]
        public void Create(AccountsModel? acc)
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
