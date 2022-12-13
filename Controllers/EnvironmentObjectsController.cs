using ReegornApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ReegornApi.Controllers;

[ApiController]
[Route("environment-object")]
public class EnvironmentObjectsController : Controller
{

    [HttpGet]
    [Authorize(Roles = "GOD")]
    [Produces("application/json")]
    [Route("")]

    public async Task<string> GetAll()
    {
        EnvironmentObjectsService environmentObjectsService = new EnvironmentObjectsService();
        var response = environmentObjectsService.GetAll();
            if (response.IsCompletedSuccessfully)
            {
                return JsonConvert.SerializeObject(response.Result);
            }
        return JsonConvert.SerializeObject(new {message = "Erro ao buscar objetos do ambiente" });


    }
}
