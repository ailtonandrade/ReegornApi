using AuthApi.Data;
using Newtonsoft.Json;

namespace AuthApi.Repositories
{
    public class EnvironmentObjectsRepo
    {
        public List<EnvironmentObjectsModel> GetAll()
        {
            List<EnvironmentObjectsModel> list = new List<EnvironmentObjectsModel>();

            try
            {
                GameObjectsData gameObjData = new GameObjectsData();
                list = JsonConvert.DeserializeObject<List<EnvironmentObjectsModel>>(gameObjData.gameObjectsData);
                return list;
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}
