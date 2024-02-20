using POS_DePrisa.entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            try
            {
                string query = "SELECT * FROM Tbl_Producto";


                //Utilizamos using para que el objeto se destruya al salir del bloque
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    //abrimos la conexión
                    connection.Open();


                    using (SqlDataAdapter da = new SqlDataAdapter(query, connection))
                    {
                        if (da!=null)
                        {
                            da.Fill(ds);
                        }
                    }
                    connection.Close();
                }


            }
            catch (Exception ex) 
            {
                String Error = $"Eror en DProducto()\nTipo: {ex.GetType()}\nDescripción: {ex.Message}";
                MessageBox.Show(Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return ds;

        }

        public bool guardarProducto(Producto producto)
        {
            bool resultado = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Tbl_Producto (CodigoBarra, Nombre, Descripcion, Stock, Costo, TieneIva, TieneKit, DescuentoMaximo, estado, idcategoria) VALUES (@CodigoBarra, @Nombre, @Descripcion, @Stock, @Costo, @TieneIva, @TieneKit, @DescuentoMaximo, @estado, @idcategoria)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CodigoBarra", producto.CodigoBarra);
                        command.Parameters.AddWithValue("@Nombre", producto.Nombre);
                        command.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                        command.Parameters.AddWithValue("@Stock", producto.Stock);
                        command.Parameters.AddWithValue("@Costo", producto.Precio);
                        command.Parameters.AddWithValue("@TieneIva", producto.TieneIva);
                        command.Parameters.AddWithValue("@TieneKit", producto.TieneKit);
                        command.Parameters.AddWithValue("@DescuentoMaximo", producto.DescuentoMaximo);
                        command.Parameters.AddWithValue("@estado", producto.estado);
                        command.Parameters.AddWithValue("@idcategoria", producto.idcategoria);
                        int result = command.ExecuteNonQuery();
                        if (result > 0)
                        {
                            resultado = true;
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                String Error = $"Eror en guardarProducto()\nTipo: {ex.GetType()}\nDescripción: {ex.Message}";
                MessageBox.Show(Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return resultado;   
        }
    }
}
