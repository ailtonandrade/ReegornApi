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
                List<EnvironmentObjectsModel> model = environmentObjectsRepo.GetAll();
                return JsonConvert.SerializeObject(model);
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}
