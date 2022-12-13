using Oracle.ManagedDataAccess.Client;
using ReegornApi.Models;
using ReegornApi.Services;

namespace ReegornApi.Repositories
{
    public class AuthRepo
    {
        public async Task<TokenModel> get(UserModel credentials, OracleConnection db)
        {
            
            string sql = $"SELECT * FROM ACCOUNTS WHERE USER_NAME = '{credentials.Username}' AND ACCESS_KEY = '{credentials.AccessKey}'";
            UserModel user = new UserModel();

            try
            {
                db.Open();
                OracleDataReader response = new OracleCommand(sql, db).ExecuteReader();

                while (response.Read())
                        {
                            user.Id = response.GetInt32(0);
                            user.Name = response.GetString(1);
                            user.Username = response.GetString(2);
                            user.AccessKey = response.GetString(3);
                            user.Type = response.GetString(4);

                            Console.WriteLine($"Acesso concedido à {user.Username} - {DateTime.Now}");
                        };
            }
            catch (Exception ex){
                throw new Exception(ex.Message);
            }
            if(user.Username != null && user.Id != null)
            {
                sql = $"SELECT * FROM ROLES WHERE ACCOUNT_ID = {user.Id}";
                try
                {
                    OracleDataReader responseRoles = new OracleCommand(sql, db).ExecuteReader();
                    List<RolesModel> roles = new List<RolesModel>();
                    RolesModel role = new RolesModel();

                    while (responseRoles.Read())
                    {
                        role.Id = responseRoles.GetInt32(0);
                        role.AccountId = responseRoles.GetInt32(1);
                        role.Role = responseRoles.GetString(2);
                        roles.Add(role);
                    }
                    db.Close();
                    return TokenService.GenerateToken(user, roles);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Acesso negado {user.Username} - {DateTime.Now}");
                    throw new Exception(ex.Message);
                }
            }
            return null;
        }
    }
}
