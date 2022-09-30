using AuthApi.Repositories;
using Newtonsoft.Json;

namespace AuthApi.Services
{
    public class EnvironmentObjectsService
    {
        public string GetAll()
        {
            EnvironmentObjectsRepo environmentObjectsRepo = new EnvironmentObjectsRepo();

            try
            {
                return JsonConvert.SerializeObject(environmentObjectsRepo.GetAll());
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}
