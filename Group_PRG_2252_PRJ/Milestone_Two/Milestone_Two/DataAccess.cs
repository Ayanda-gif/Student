using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Net.Http.Headers;

namespace Milestone_Two
{
    class DataAccess
    {
        string con = @"Data Source = (local); Initial Catalog = StudentDB ;  Integrated Security = SSPI";
        public SqlConnection Connection()
        {
            SqlConnection connection = new SqlConnection(con);
            return connection;
        }
        public SqlCommand Command(string query, SqlConnection connection)
        {
            SqlCommand command = new SqlCommand(query, connection);
            return command;
        }
    }
}
