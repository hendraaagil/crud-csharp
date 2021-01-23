using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace _4_CRUD_With_SQL_Server
{
    class Connection
    {
        public SqlConnection GetConn()
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = "Data Source = AGIL-PC\\SQLEXPRESS; Initial Catalog = DB_CONTOH; Integrated Security = true";
            return Conn;
        }
    }
}
