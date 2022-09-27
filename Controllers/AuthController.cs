using Microsoft.AspNetCore.Mvc;

namespace AuthApi.Controllers;

[ApiController]
[Route("auth")]
public class AuthController : Controller
{

    [HttpPost]
    public IActionResult Auth(string user, string pass)
    {
        if (user == "admin" && pass == "123")
            return Json("Logado");

        return Json("Não Logado!");
    }
}
