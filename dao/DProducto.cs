using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_DePrisa.dao
{
    internal class DProducto
    {
        private string connectionString;

        public DProducto()
        {
            connectionString = ConfigurationManager.ConnectionStrings["POS_DePrisa.Properties.Settings.DBDePrisaConnectionString"].ConnectionString;
        }

        public DataSet ListarProductos()
        {
           
            DataSet ds = new DataSet();
            string query = "SELECT * FROM Tbl_Producto";
            SqlConnection cnn = new SqlConnection(connectionString);

            //ds = con.EjecutarConsulta(query);
            cnn.Open();
         SqlDataAdapter da = new SqlDataAdapter(query, cnn);
            da.Fill(ds);
            cnn.Close();
            return ds;
        }
    }
}
