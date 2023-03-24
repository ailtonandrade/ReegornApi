using ReegornApi.Models;
using ReegornApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static System.Transactions.Transaction;
using System.Threading.Tasks;
using System;

namespace ReegornApi.Controllers
{ 
    [ApiController]
    [Route("auth")]
    public class AuthController : Controller
    {

        [HttpPost]
        [Produces("application/json")]
        [AllowAnonymous]
        public async Task<IActionResult> login(HashModel hash)
        {

            TokenModel token = await getToken(hash);
            validateToken(token);

            return Json(token);
        }
        private void validateToken(TokenModel token)
        {
            if (token == null)
            {
                Response.StatusCode = 401;
                throw new Exception("Erro ao autenticar.");

            }
        }
        private async Task<TokenModel> getToken(HashModel hash)
        {
            AuthService authService = new AuthService();

            return await authService.get(hash);
        }

    }
}
