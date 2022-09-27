using AuthApi.Repositories;

namespace AuthApi.Services
{
    public class AuthService
    {
        public string Auth(UserModel user)
        {
            AuthRepo authRepo = new AuthRepo();

            if (!string.IsNullOrEmpty(user.User) && !string.IsNullOrEmpty(user.Pass))
            {
                string response = authRepo.Auth(user);
                return response;
            }

            return null;
        }
    }
}
