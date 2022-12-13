using ReegornApi.Repositories;
using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;

namespace ReegornApi.Services
{
    public class EnvironmentObjectsService
    {
        public async Task<List<EnvironmentObjectsModel>> GetAll()
        {
            EnvironmentObjectsRepo environmentObjectsRepo = new EnvironmentObjectsRepo();
            var db = Transactions.Create();

            try
            {
                List<EnvironmentObjectsModel> model = await environmentObjectsRepo.GetAll(db);
                return model;
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}
