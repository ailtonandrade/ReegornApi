using Oracle.ManagedDataAccess.Client;
using ReegornApi.Models;
using ReegornApi.Repositories;
using System.Threading.Tasks;

namespace ReegornApi.Services
{
    public class AuthService
    {
        public async Task<TokenModel> get(HashModel hash)
        {
            AuthRepo authRepo = new AuthRepo();
            OracleConnection db =  Transactions.Create();

            if (hash != null)
            {
            
                TokenModel response = await authRepo.get(hash, db);
                if (response != null)
                {
                    return response;
                }
            }

            return null;
        }
    }
}
