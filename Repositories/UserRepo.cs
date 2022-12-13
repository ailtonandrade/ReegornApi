using ReegornApi.Data;
using ReegornApi.Services;
using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using AuthApi.Models;

namespace ReegornApi.Repositories
{
    public class UserRepo
    {
        public async Task<List<UserModel>> GetByAccount(string acc, OracleConnection db)
        {
            List<UserModel> listUser = new List<UserModel>();
            UserModel user = new UserModel();

            try
            {
                db.Open();
                var sql = $"SELECT CH_NAME,CH_ID_SESSION FROM CHARACTERS WHERE CH_ACC = '{acc}'";

                var response = new OracleCommand(sql, db).ExecuteReader();
                while (response.Read())
                {
                    user.Name = response.GetString(0);
                    user.IdSession = response.GetString(1);
                    listUser.Add(user);
                }
                db.Close();
                return listUser;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async void Create(BroadcastCharacterModel character, OracleConnection db)
        {
            try
            {
                db.Open();
                var sql = $"INSERT INTO CHARACTERS (CH_NAME,CH_ACC,CH_POSX,CH_POSY,CH_POSZ,CH_ROT,CH_ID_SESSION) " +
                          $"VALUES ({character.name},{character.acc},{character.posX},{character.posY},{character.posZ},{character.rot},'SANDBOX01')";

                new OracleCommand(sql, db).ExecuteNonQuery();
                db.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async void  Update(BroadcastCharacterModel character, OracleConnection db)
        {
            try
            {
                db.Open();
                var sql = $"UPDATE CHARACTERS SET CH_POSX = {character.posX}, CH_POSY = {character.posY}, CH_POSZ = {character.posZ}, CH_ROT = {character.rot},CH_ID_SESSION = {character.idSession}  WHERE CH_ID = {character.id},AND CH_NAME = {character.name}";

                new OracleCommand(sql,db).ExecuteNonQuery();
                db.Close(); 
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
