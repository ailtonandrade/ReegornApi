using ReegornApi.Data;
using ReegornApi.Services;
using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using AuthApi.Models;

namespace ReegornApi.Repositories
{
    public class BroadcastingCharacterWorldRepo
    {
        public async Task<List<BroadcastCharacterModel>> GetAllCharacterWorld(string? idSession, OracleConnection db)
        {
            List<BroadcastCharacterModel> listObj = new List<BroadcastCharacterModel>();
            try
            {
                db.Open();
                var sql = $"SELECT CH_POSX,CH_POSY,CH_POSZ,CH_ROT,CH_NAME FROM CHARACTERS WHERE CH_ID_SESSION = '{idSession}'";

                OracleDataReader response = new OracleCommand(sql,db).ExecuteReader();

                while (response.Read())
                {
                    BroadcastCharacterModel obj = new BroadcastCharacterModel();
                    obj.posX = response.GetString(0);
                    obj.posY = response.GetString(1);
                    obj.posZ = response.GetString(2);
                    obj.rot = response.GetString(3);
                    obj.name = response.GetString(4);
                    listObj.Add(obj);
                }
                db.Close();
                return listObj;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return null;
        }
    }
}
