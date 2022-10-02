using AuthApi.Models;
using AuthApi.Repositories;

namespace AuthApi.Services
{
    public class AuthService
    {
        public TokenModel Auth(UserModel user)
        {
            AuthRepo authRepo = new AuthRepo();

            if (!string.IsNullOrEmpty(user.Username) && !string.IsNullOrEmpty(user.AccessKey))
            {
                TokenModel response = authRepo.Auth(user);
                if (response != null)
                {
                    return response;
                }
            }

            return null;
        }
    }
}
