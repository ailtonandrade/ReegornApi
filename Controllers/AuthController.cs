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
    public async Task<IActionResult> get(UserModel? user)
    {
        AuthService authService = new AuthService();
        user.AccessKey = HashService.Encode(user.AccessKey);
        TokenModel token = await authService.get(user);
            if (token == null)
        {
            Response.StatusCode = 401;
            return Json("Usuário não autorizado.");
        }



        return Json(token);
    }
}
