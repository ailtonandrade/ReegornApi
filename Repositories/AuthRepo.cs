using ReegornApi.Models;
using ReegornApi.Services;

namespace ReegornApi.Repositories
{
    public class AuthRepo
    {
        public TokenModel Auth(UserModel credentials)
        {
            var query = Transactions.GetConnection().CreateCommand();
            query.CommandText = "SELECT * FROM ACCOUNTS WHERE USER_NAME = '"+ credentials.Username+ "' AND ACCESS_KEY = '"+ credentials.AccessKey+"'";
            var response = query.ExecuteReader();
            UserModel user = new UserModel();
            while (response.Read()){
                user.Id = response.GetInt32(0);
                user.Name = response.GetString(1);
                user.Username = response.GetString(2);
                user.AccessKey = response.GetString(3);
                user.Type = response.GetString(4);
            
                Console.WriteLine("Acesso concedido à "+user.Username+" ["+DateTime.Now+"]");
            };
            if(user.Username != null && user.Id != null)
            {
                var queryRoles = Transactions.GetConnection().CreateCommand();
                queryRoles.CommandText = "SELECT * FROM ROLES WHERE ACCOUNT_ID = "+user.Id;
                var responseRoles = queryRoles.ExecuteReader();
                List<RolesModel> roles = new List<RolesModel>();
                while (responseRoles.Read())
                {
                    RolesModel role = new RolesModel();
                    role.Id = responseRoles.GetInt32(0);
                    role.AccountId = responseRoles.GetInt32(1);
                    role.Role = responseRoles.GetString(2);
                    roles.Add(role);
                }
                return TokenService.GenerateToken(user, roles);
            }
            Console.WriteLine("Acesso negado " + user.Username + " [" + DateTime.Now + "]");

            return null;
        }
    }
}
