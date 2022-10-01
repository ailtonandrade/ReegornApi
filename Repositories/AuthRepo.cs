namespace AuthApi.Repositories
{
    public class AuthRepo
    {
        public string Auth(UserModel user)
        {
            if(user.User == "adm" && user.Pass == "123")
                return "daf4-ad4f-4daf8a4ds8f4a8d-fa-d4f4a-dfasfa3f4a-34f-aw344fa8--3wf8a434f4a-3fa3";

            return null;
        }
    }
}
