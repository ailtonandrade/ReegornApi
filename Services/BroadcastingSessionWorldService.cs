using ReegornApi.Repositories;
using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;

namespace ReegornApi.Services
{
    public class BroadcastingSessionWorldService
    {
        public async Task<List<EnvironmentObjectsModel>> GetById(long? idSession)
        {
            EnvironmentObjectsRepo environmentObjectsRepo = new EnvironmentObjectsRepo();
            var db = Transactions.Create();

            try
            {
                List<EnvironmentObjectsModel> model = await environmentObjectsRepo.GetById(idSession, db);
                return model;
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}
