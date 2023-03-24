using Oracle.ManagedDataAccess.Client;
using ReegornApi.Models;
using ReegornApi.Services;
using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Threading.Tasks;

namespace ReegornApi.Repositories
{
    public class AuthRepo
    {
        public async Task<TokenModel> get(HashModel hash, OracleConnection db)
        {
            UserModel user = new UserModel();

            string sql = $@"SELECT 
	                        a.NAME, 
	                        a.USER_NAME, 
	                        a.ACCESS_KEY, 
	                        a.TYPE, 
	                        a.ID,
	                        ca.ADDRESS,
	                        ca.HAS_CHARACTER_ONLINE 
	                        FROM ACCOUNTS a
	                        INNER JOIN CONTROL_ACCESS ca ON (a.ID = ca.ACCOUNT_ID)
	                        WHERE ACCESS_KEY = '{hash.Hash}'
                            AND IS_DENIED = 0
                            AND ADDRESS = '{hash.IpAddress}'";

            try
            {
                db.Open();
                OracleDataReader response = new OracleCommand(sql, db).ExecuteReader();

                while (response.Read()){
                            user.Name = response.GetString(0);
                            user.Username = response.GetString(1);
                            user.AccessKey = response.GetString(2);
                            user.Type = response.GetString(3);
                            user.Id = response.GetInt32(4);
                            user.IpAddress = response.GetString(5);
                            user.HasCharactersOnline = response.GetInt32(6);

                    Console.WriteLine($"Acesso concedido à {user.Username} - {DateTime.Now}");
                 };
            }
            catch (Exception ex){
                throw new Exception(ex.Message);
            }
            validateIpAddress(user,hash);


            if (user.Username != null && user.Id != null)
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
                        role.Role = responseRoles.GetString(1);
                        role.AccountId = responseRoles.GetInt32(2);
                        roles.Add(role);
                    }
                    db.Close();

                    return TokenService.GenerateToken(user, roles, hash.IpAddress);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Acesso negado {user.Username} - {DateTime.Now}");
                    throw new Exception(ex.Message);
                }
            }
            return null;
        }
        private void validateIpAddress(UserModel userStorage,HashModel hashData)
        {
            try
            {
                if(userStorage.IpAddress != hashData.IpAddress)
                {
                    userStorage.IsNewIpAddress = 1;
                }
                else
                {
                    userStorage.IsNewIpAddress = 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Acesso negado para o usuário: {userStorage.Username} - {DateTime.Now}");
                throw new Exception(ex.Message);
            }
        }
    }
}
