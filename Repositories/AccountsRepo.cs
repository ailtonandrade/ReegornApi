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
        
        public async Task<List<CharacterModel>> GetCharacterList(ObjectDataModel obj, OracleConnection db)
        {
            try
            {

                var sql = $"SELECT CH_NAME,CH_POSX,CH_POSY,CH_POSZ,CH_ROT,CH_ID_SESSION,CH_ACC,CH_CLASS,CH_LEVEL,CH_GENDER FROM CHARACTERS WHERE CH_ACC = '{obj.Name}'";
                List<CharacterModel> listCharacter = new List<CharacterModel>();

                try
                {
                    db.Open();
                    OracleDataReader response = new OracleCommand(sql, db).ExecuteReader();

                    while (response.Read())
                    {
                        CharacterModel character = new CharacterModel();
                        character.name = response.GetString(0);
                        character.posX = response.GetString(1);
                        character.posY = response.GetString(2);
                        character.posZ = response.GetString(3);
                        character.rot = response.GetString(4);
                        character.idSession = response.GetString(5);
                        character.acc = response.GetString(6);
                        character.chClass = response.GetString(7);
                        character.level = response.GetInt64(8);
                        character.gender = response.GetString(9);
                        listCharacter.Add(character);
                    }
                    db.Close();
                    return listCharacter;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
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
        public async void  UpdateCharacterLocal(CharacterModel character, OracleConnection db)
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
