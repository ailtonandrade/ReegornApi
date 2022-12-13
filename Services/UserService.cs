using ReegornApi.Repositories;
using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using AuthApi.Models;

namespace ReegornApi.Services
{
    public class UserService
    {
        public async Task<List<UserModel>> GetByAccount(string? acc)
        {
            UserRepo repo = new UserRepo();
            var db = Transactions.Create();

            try
            {
                List<UserModel> response = await repo.GetByAccount(acc, db);
                return response;
            }
            catch
            {
                throw new Exception();
            }
        }
        public async void Create(BroadcastCharacterModel? character)
        {
            UserRepo repo = new UserRepo();
            var db = Transactions.Create();

            try
            {
                repo.Create(character, db);
            }
            catch
            {
                throw new Exception();
            }
        }
        public async void Update(BroadcastCharacterModel? character)
        {
            UserRepo repo = new UserRepo();
            var db = Transactions.Create();

            try
            {
                repo.Update(character, db);
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}
