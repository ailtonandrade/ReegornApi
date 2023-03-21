using ReegornApi.Data;
using ReegornApi.Services;
using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using AuthApi.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace ReegornApi.Repositories
{
    public class AccountsRepo
    {
        
        public async Task<List<CharacterModel>> GetCharacterList(UserModel obj, OracleConnection db)
        {
            try
            {

                var sql = $"SELECT CH_NAME name,CH_POSX positionX,CH_POSY positionY,CH_POSZ positionZ,CH_ROT rotation,CH_WORLD world,CH_LOCAL local,CH_ACC acc,CH_CLASS chClass,CH_LEVEL lvl,CH_GENDER gender ,CH_HP hp FROM CHARACTERS WHERE CH_ACC = '{obj.Username}'";
                List<CharacterModel> listCharacter = new List<CharacterModel>();

                try
                {
                    db.Open();
                    OracleDataReader response = new OracleCommand(sql, db).ExecuteReader();

                    while (response.Read())
                    {
                        CharacterModel character = new CharacterModel();
                        character.name = response.GetString(0);
                        character.positionX = response.GetFloat(1);
                        character.positionY = response.GetFloat(2);
                        character.positionZ = response.GetFloat(3);
                        character.rotation = response.GetFloat(4);
                        character.world = response.GetString(5);
                        character.local = response.GetString(6);
                        character.acc = response.GetString(7);
                        character.chClass = response.GetString(8);
                        character.level = response.GetInt64(9);
                        character.gender = response.GetString(10);
                        character.hp = response.GetInt64(11);
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
    }
}
