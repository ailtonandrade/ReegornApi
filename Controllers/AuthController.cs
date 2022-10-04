using ReegornApi.Models;
using ReegornApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static System.Transactions.Transaction;

namespace ReegornApi.Controllers;

[ApiController]
[Route("auth")]
public class AuthController : Controller
{

    [HttpPost]
    [Produces("application/json")]
    [AllowAnonymous]
    public IActionResult Auth(UserModel? user)
    {
        AuthService authService = new AuthService();
        user.AccessKey = HashService.Encode(user.AccessKey);
        TokenModel token = authService.Auth(user);
            if (token == null)
        {
            Response.StatusCode = 401;
            return Json("Usuário não autorizado.");
        }



        return Json(token);
    }
}
