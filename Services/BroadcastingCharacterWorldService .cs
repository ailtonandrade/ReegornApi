using ReegornApi.Repositories;
using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using AuthApi.Models;

namespace ReegornApi.Services
{
    public class BroadcastingCharacterWorldService
    {
        public async Task<List<BroadcastCharacterModel?>> SelectCharacterWorld(string? idSession)
        {
            BroadcastingCharacterWorldRepo repo = new BroadcastingCharacterWorldRepo();
            var db = Transactions.Create();

            try
            {
                List<BroadcastCharacterModel> model = await repo.GetAllCharacterWorld(idSession, db);
                return model;
                
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}
