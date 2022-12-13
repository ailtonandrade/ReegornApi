using Oracle.ManagedDataAccess.Client;
using ReegornApi.Models;
using ReegornApi.Repositories;

namespace ReegornApi.Services
{
    public class AuthService
    {
        public async Task<TokenModel> get(UserModel user)
        {
            AuthRepo authRepo = new AuthRepo();
            OracleConnection db =  Transactions.Create();

            if (!string.IsNullOrEmpty(user.Username) && !string.IsNullOrEmpty(user.AccessKey))
            {
            
                TokenModel response = await authRepo.get(user, db);
                if (response != null)
                {
                    return response;
                }
            }

            return null;
        }
    }
}
