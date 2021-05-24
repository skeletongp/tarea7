using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Practica_7
{
    class Vuelos
    {
        Conexion con = new Conexion();
        public DataTable Data_Vuelo(string estado)
        {
            DataTable dt = new DataTable();
            try
            {
                string cmdtext = "Select * from Vuelos Where Estado='" + estado + "'";
                SqlDataAdapter adp = new SqlDataAdapter(cmdtext, con.Conectar());
                adp.Fill(dt);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }       
            return dt;
        }
        public void Marcar_Vuelo(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("edit_data", con.Conectar());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void Insertar_Vuelo(int numero, int cantidad)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("insert_data", con.Conectar());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@numero", numero);
                cmd.Parameters.AddWithValue("@cantidad", cantidad);
                cmd.Parameters.AddWithValue("@hora", 
                    DateTime.Now.ToString("HH:mm:ss"));
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
    