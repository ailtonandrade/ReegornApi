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
    public class SessionRepo
    {
        
        public async Task<List<CharacterModel>> GetAllPlayers(CharacterModel characterModel, OracleConnection db)
        {
            try
            {
                if(db.State == ConnectionState.Closed)
                    db.Open();

                var sql = $"SELECT CH_NAME name,CH_POSX positionX,CH_POSY positionY,CH_POSZ positionZ,CH_ROT rotation,CH_ACC acc,CH_HP hp,CH_CLASS chClass,CH_LEVEL lvl,CH_GENDER gender, CH_IS_ONLINE isOnline FROM CHARACTERS WHERE CH_WORLD = '{characterModel.world}' AND CH_LOCAL = '{characterModel.local}' AND CH_IS_ONLINE = 1";
                List<CharacterModel> listCharacter = new List<CharacterModel>();

                try
                {
                    OracleDataReader response = new OracleCommand(sql, db).ExecuteReader();

                    while (response.Read())
                    {
                        CharacterModel character = new CharacterModel();
                        character.name = response.GetString(0);
                        character.positionX = response.GetFloat(1);
                        character.positionY = response.GetFloat(2);
                        character.positionZ = response.GetFloat(3);
                        character.rotation = response.GetFloat(4);
                        character.acc = response.GetString(5);
                        character.hp = response.GetInt64(6);
                        character.chClass = response.GetString(7);
                        character.level = response.GetInt64(8);
                        character.gender = response.GetString(9);
                        character.isOnline = response.GetInt32(10);
                        listCharacter.Add(character);
                    }

                    if(db.State == ConnectionState.Open)
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
        public void  UpdateCharacterLocal(dynamic characterModel, OracleConnection db,long isOnline)
        {
            try
            {
                var sql = $"UPDATE CHARACTERS SET CH_POSX = '{characterModel.positionX}', CH_POSY = '{characterModel.positionY}', CH_POSZ = '{characterModel.positionZ}', CH_ROT = '{characterModel.rotation}' ,CH_HP = '{characterModel.hp}',CH_LOCAL = '{characterModel.local}'  WHERE CH_ACC = '{characterModel.acc}' AND CH_NAME = '{characterModel.name}' AND CH_IS_ONLINE = 1";
                if (db.State == ConnectionState.Closed)
                    db.Open();

                OracleCommand command = new OracleCommand(sql, db);
                OracleTransaction transaction = db.BeginTransaction();
                command.Transaction = transaction;
                var res = command.ExecuteReader();
                if (res == null)
                    throw new Exception("Érro ao sincronizar.");

                transaction.Commit();

                if (db.State == ConnectionState.Open)
                    db.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
