using ReegornApi.Data;
using ReegornApi.Services;
using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using AuthApi.Models;

namespace ReegornApi.Repositories
{
    public class AccountsRepo
    {
        public async void Create(AccountsModel acc, OracleConnection db)
        {
            try
            {
                db.Open();
                var sql = $"INSERT INTO ACCOUNTS (NAME,USER_NAME,ACCESS_KEY,TYPE) " +
                          $"VALUES ('{acc.name}','{acc.userName}','{acc.accessKey}','{acc.type}')";

                new OracleCommand(sql, db).ExecuteNonQuery();
                db.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async void  UpdateCharacterLocal(BroadcastCharacterModel character, OracleConnection db)
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
