using ReegornApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ReegornApi.Controllers;

[ApiController]
[Route("environment-object")]
public class EnvironmentObjectsController : Controller
{

    [HttpGet]
    [Route("")]

    public IActionResult GetAll(string? auth)
    {
        EnvironmentObjectsService environmentObjectsService = new EnvironmentObjectsService();

        if (string.IsNullOrEmpty(auth))
        {
            return Json("Erro de autenticação.");
        }
        var response = environmentObjectsService.GetAll();
            if (response != null)
            {
                return Json(response);
            }
                return Json("Erro ao buscar objetos do ambiente");


    }
}
