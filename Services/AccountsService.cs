using ReegornApi.Repositories;
using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using AuthApi.Models;

namespace ReegornApi.Services
{
    public class AccountsService
    {
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
        public async void UpdateCharacterLocal(BroadcastCharacterModel? character)
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
