using AuthApi.Models;
using AuthApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static System.Transactions.Transaction;

namespace AuthApi.Controllers;

[ApiController]
[Route("auth")]
public class AuthController : Controller
{

    [HttpPost]
    [AllowAnonymous]
    public IActionResult Auth(string user, string pass)
    {
        AuthService authService = new AuthService();

            UserModel usuario = new UserModel();
            usuario.Username = user;
            usuario.AccessKey = HashService.Encode(pass);

            TokenModel token = authService.Auth(usuario);
            if (token == null)
        {
                return Json("Usuário não autorizado.");
        }



        return Json(token);
    }
}
