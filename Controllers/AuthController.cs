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
        public async Task<IActionResult> login(UserModel user)
        {
            validateUser(user);

            TokenModel token = await getToken(user);
            validateToken(token);

            return Json(token);
        }
        private void validateUser(UserModel user)
        {
            user.Username = "andrade01";
            user.AccessKey = "123456";
            if (user.Username == null || user.AccessKey == null)
            {
                Response.StatusCode = 401;
                throw new Exception("Erro ao autenticar.");
            }
            user.AccessKey = HashService.Encode(user.AccessKey);
        }
        private void validateToken(TokenModel token)
        {
            if (token == null)
            {
                Response.StatusCode = 401;
                throw new Exception("Erro ao autenticar.");

            }
        }
        private async Task<TokenModel> getToken(UserModel user)
        {
            AuthService authService = new AuthService();

            return await authService.get(user);
        }

    }
}
