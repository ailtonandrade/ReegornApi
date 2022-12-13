using AuthApi.Core.HandleExceprions;
using Oracle.ManagedDataAccess.Client;
using ReegornApi.Data;
using System.Data;
using System.Data.SQLite;

namespace ReegornApi.Services
{
    public class Transactions
    {
        public Transactions() {
        }
        public static OracleConnection Create()
        { 
            OracleConnection con = new OracleConnection();
            con.ConnectionString = Global.DefaultConnection;
            return con;
        }
    }
}
