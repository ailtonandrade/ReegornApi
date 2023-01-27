using ReegornApi.Repositories;
using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using AuthApi.Models;

namespace ReegornApi.Services
{
    public class AccountsService
    {
        public async Task<List<CharacterModel>> GetCharacterList(UserModel obj)
        {
            AccountsRepo repo = new AccountsRepo();
            var db = Transactions.Create();

            try
            {
                return await repo.GetCharacterList(obj, db);
            }
            catch
            {
                throw new Exception();
            }
        }
        public async void Create(AccountsModel? acc)
        {
            AccountsRepo repo = new AccountsRepo();
            var db = Transactions.Create();

            try
            {
                repo.Create(acc, db);
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}
