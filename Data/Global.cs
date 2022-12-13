namespace ReegornApi.Data
{
    public class Global
    {
        public static string Secret {get;set;} = new ConfigurationBuilder()
                                                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                                                    .AddJsonFile("appsettings.json")
                                                    .Build().GetSection("SecretKey").Value;

        public static string DefaultConnection { get; set; } = new ConfigurationBuilder()
                                            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                                            .AddJsonFile("appsettings.json")
                                            .Build().GetConnectionString("DefaultConnection");


    }
}
