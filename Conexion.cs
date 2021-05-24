using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_7
{
    class Conexion
    {
        public SqlConnection con;

        public SqlConnection Conectar()
        {
            con = new SqlConnection("Server=localhost; " +
                "database=aereopuerto; Trusted_Connection=true");
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }
    }
}
