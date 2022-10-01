using AuthApi.Services;
using Microsoft.AspNetCore.Mvc;
using static System.Transactions.Transaction;

namespace AuthApi.Controllers;

[ApiController]
[Route("auth")]
public class AuthController : Controller
{

    [HttpPost]
    public IActionResult Auth(string user, string pass)
    {
        AuthService authService = new AuthService();

            UserModel usuario = new UserModel();
            usuario.User = user;
            usuario.Pass = pass;

            string token = authService.Auth(usuario);
            if (string.IsNullOrEmpty(token))
        {
                return Json("Usuário não autorizado.");
        }



        return Json(token);
    }
}
