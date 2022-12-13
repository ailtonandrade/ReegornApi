using ReegornApi.Data;
using ReegornApi.Services;
using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace ReegornApi.Repositories
{
    public class EnvironmentObjectsRepo
    {
        public async Task<List<EnvironmentObjectsModel>> GetById(long? idSession, OracleConnection db)
        {
            List<EnvironmentObjectsModel> listObj = new List<EnvironmentObjectsModel>();
            try
            {
                db.Open();
                var sql = $"SELECT DISPLAYNAME,HP,INTERNALID,ID,TYPE,CATEGORY FROM ENV_OBJS WHERE ID = {idSession}";

                OracleDataReader response = new OracleCommand(sql,db).ExecuteReader();

                while (response.Read())
                {
                    EnvironmentObjectsModel obj = new EnvironmentObjectsModel();
                    obj.Name = response.GetString(0);
                    obj.Hp = response.IsDBNull(1) ? 0 : response.GetInt64(1);
                    obj.InternalId = response.GetString(2);
                    obj.Id = response.GetInt64(3);
                    obj.Type = response.GetString(4);
                    obj.Category = response.GetString(5);
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
