using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class Conexao
    {
        public static SqlCommand Conectar()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = @"";
            connection.Open();

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            return command;
        }
        
    }
}
