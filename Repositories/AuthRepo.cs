namespace AuthApi.Repositories
{
    public class AuthRepo
    {
        public string Auth(UserModel user)
        {
            if(user.User == "adm" && user.Pass == "123")
                return "token";

            return null;
        }
    }
}
