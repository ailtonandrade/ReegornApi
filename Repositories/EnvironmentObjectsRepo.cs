using AuthApi.Data;
using AuthApi.Services;
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
                var query = Transactions.GetConnection().CreateCommand();
                query.CommandText = @"SELECT * FROM ENV_OBJS";
                var response = query.ExecuteReaderAsync();
                Console.WriteLine(response.ToString());
                return list;
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}
