using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Dominio.Connections
{
    public class Connection
    {
        String connString = ConfigurationManager.ConnectionStrings["strconn"].ConnectionString;
        SqlConnection conn;

        public Connection()
        {
            conn = new SqlConnection(connString);
        }

        public void Conectar()
        {
            if(conn.State != ConnectionState.Open)
                conn.Open();
        }

        public void Desconectar() {
            if(conn.State == ConnectionState.Open)
            conn.Close();
        }

        public void ExecuteNonQuery(SqlCommand sqlComm) {
            sqlComm.ExecuteNonQuery();
        }

        public DataTable ExecutarDataTable(string query) {
            DataTable dt = new DataTable();

            using (SqlDataAdapter d = new SqlDataAdapter(query, conn))
            {
                d.Fill(dt);
            }
            return dt;

        }

      
    }
}
