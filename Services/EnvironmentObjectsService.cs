using ReegornApi.Repositories;
using Newtonsoft.Json;

namespace ReegornApi.Services
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
