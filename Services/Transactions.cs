using System.Data.SQLite;

namespace AuthApi.Services
{
    public class Transactions
    {
        public Transactions() {
        }
        public static SQLiteConnection GetConnection()
        {
            SQLiteConnection connection = new SQLiteConnection("Data Source=c:\\ProgramData\\Reegorn\\data.sqlite Version=3");
            connection.Open();
            return connection;
        }
        public static void InitData()
        {
            try
            {
                SQLiteConnection.CreateFile(@"c:\ProgramData\Reegorn\data.sqlite");
                try
                {
                    var query= GetConnection().CreateCommand();
                    query.CommandText = @"CREATE TABLE ENV_OBJS (
                                            ID INT,
                                            DISPLAYNAME VARCHAR(70),
                                            NAME VARCHAR(70),
                                            INTERNALID VARCHAR(70),
                                            HP INT,
                                            CATEGORY VARCHAR(70),
                                            TYPE VARCHAR(70)
                                        )";
                    query.ExecuteNonQuery();
                    try
                    {
                        var queryInsert = GetConnection().CreateCommand();
                        queryInsert.CommandText = @"
                        INSERT INTO ENV_OBJS VALUES (0,'CUBO ROXO','CubePurple','A5S6D1F256A',20000,'COLLECTABLE',ORE);
                        INSERT INTO ENV_OBJS VALUES (1,'CUBO LARANJA','CubeOrange','1S5A6S51D4D',NULL,'ENVIRONMENT','ORE');
                                        ";
                        queryInsert.ExecuteNonQuery();
                    }
                    catch
                    {
                        throw;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                finally
                {
                    GetConnection().Close();
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
