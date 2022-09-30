using AuthApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace AuthApi.Controllers;

[ApiController]
[Route("environment-object")]
public class EnvironmentObjectsController : Controller
{

    [HttpGet]
    [Route("")]
    public IActionResult GetAll()
    {
         string user = "";
         string pass = "";
        AuthService authService = new AuthService();
        EnvironmentObjectsService environmentObjectsService = new EnvironmentObjectsService();

        UserModel usuario = new UserModel();
            usuario.User = user;
            usuario.Pass = pass;

            string token = authService.Auth(usuario);
            token = "test";
            if (string.IsNullOrEmpty(token))
            {
              return Json("Usuário não possui parâmetros suficientes para completar a chamada.");
            }
             else
            {
            var response = environmentObjectsService.GetAll();
            if (response != null)
            {
                return Json(response);
            }
                
                return Json("Erro ao buscar objetos do ambiente");
            }

    }
}
