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
    [Consumes("application/json")]
    [Produces("application/json")]
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
                return Json("Usu�rio n�o autorizado.");
        }



        return Json(token);
    }
}
