using System.Data.SQLite;

namespace ReegornApi.Services
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
                    query.CommandText = @"CREATE TABLE IF NOT EXISTS ENV_OBJS (
                                            ID INT,
                                            DISPLAYNAME VARCHAR(70),
                                            NAME VARCHAR(70),
                                            INTERNALID VARCHAR(70),
                                            HP INT,
                                            CATEGORY VARCHAR(70),
                                            TYPE VARCHAR(70)
                                        );
                                        CREATE TABLE IF NOT EXISTS ACCOUNTS (
                                            ID INT,
                                            NAME VARCHAR(70),
                                            USER_NAME VARCHAR(70),
                                            ACCESS_KEY VARCHAR(70),
                                            TYPE VARCHAR(10)
                                        );
                                        CREATE TABLE IF NOT EXISTS ROLES (
                                            ID INT,
                                            ACCOUNT_ID INT,
                                            ROLE VARCHAR(70)
                                        );
";
                    query.ExecuteNonQuery();
                    
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
        public static void InitDataValues()
        {
            try
            {
                var queryInsert = GetConnection().CreateCommand();
                queryInsert.CommandText = @"
                        DELETE FROM ENV_OBJS WHERE ID >=0;
                        DELETE FROM ACCOUNTS WHERE ID >=0;
                        DELETE FROM ROLES WHERE ID >=0;

                        INSERT INTO ENV_OBJS VALUES ('CUBO ROXO','CubePurple','A5S6D1F256A',20000,'COLLECTABLE','ORE');
                        INSERT INTO ENV_OBJS VALUES ('CUBO LARANJA','CubeOrange','1S5A6S51D4D',NULL,'MOB','ENEMY');
                        
                        INSERT INTO ACCOUNTS VALUES (0,'AILTON ANDRADE','andrade01','"+HashService.Encode("123456")+@"','GOD');

                        INSERT INTO ROLES VALUES (0,0,'GOD');
                                        ";
                queryInsert.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
        }
    }
}
