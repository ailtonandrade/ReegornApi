using AuthApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReegornApi;
using ReegornApi.Services;

namespace AuthApi.Controllers
{
    [ApiController]
    [Route("Characters")]
    public class UsersController : Controller
    {
        [HttpGet]
        [Consumes("application/json")]
        [Produces("application/json")]
        [Route("getbyacc/{acc}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByAccount([FromRoute]string acc)
        {
            UserService service = new UserService();
            try
            {
                List<UserModel> response = await service.GetByAccount(acc);
                return Json(response);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }
        }

        [HttpPost]
        [Produces("application/json")]
        [Route("update")]
        [AllowAnonymous]
        public void Update(CharacterModel? obj)
        {
            UserService service = new UserService();
            try
            {
                //service.Update(obj);
            }
            catch(Exception ex)
            {

                throw new Exception(ex.Message);
                
            }
        }
        [HttpPost]
        [Produces("application/json")]
        [Route("create")]
        [AllowAnonymous]
        public void Create(CharacterModel? obj)
        {
            UserService service = new UserService();
            try
            {
                service.Create(obj);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }
        }
    }
}
