namespace AuthApi.Data
{
    public class Global
    {
        public static string Secret {get;set;} = new ConfigurationBuilder()
                                                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                                                    .AddJsonFile("appsettings.json")
                                                    .Build().GetSection("SecretKey").Value;


    }
}
