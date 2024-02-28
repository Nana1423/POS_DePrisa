using POS_DePrisa.entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_DePrisa.dao
{
    internal class DDetalleKit
    {

        // String de la conexion a la base de datos
        private string connectionString;

        // Constructor de la clase
        public DDetalleKit()
        {
            connectionString = ConfigurationManager.ConnectionStrings["POS_DePrisa.Properties.Settings.DBDePrisaConnectionString"].ConnectionString;
        }


        // Metodo para listar los detalles de los productos que componen un kit
        public DataSet ListarDetalleKits()
        {
            DataSet ds = new DataSet();
            try
            {
                string query = "SELECT * FROM Tbl_DetalleKit";

                //Se utiliza using para que el objeto se destruya al salir del bloque
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    //Se abre la conexion
                    connection.Open();

                    using (SqlDataAdapter da = new SqlDataAdapter(query, connection))
                    {
                        if (da != null)
                        {
                            da.Fill(ds);
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                String Error = $"Eror en DDetalleKit()\nTipo: {ex.GetType()}\nDescripción: {ex.Message}";
                MessageBox.Show(Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return ds;
        }

        public DataSet obtenerPruductosKit(int idProductoKit)
        {
            DataSet ds = new DataSet();
            try
            {
                string query = "SELECT * FROM Tbl_DetalleKit D JOIN Tbl_Producto P on D.idProductoIndividual = P.idProducto where D.idProductoKit = @IdProductoKit";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(query, connection))
                    {
                        da.SelectCommand.Parameters.AddWithValue("@IdProductoKit", idProductoKit);
                        if (da != null)
                        {
                            da.Fill(ds);
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                String Error = $"Eror en obtenerPruductosKit()\nTipo: {ex.GetType()}\nDescripción: {ex.Message}";
                MessageBox.Show(Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return ds;
        }


        // Metodo para insertar un nuevo detalle de kit
        public bool GuardarDetalleKit(DetalleKit detalleKit)
        {
            bool resultado = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Tbl_DetalleKit (IdProductoKit, Cantidad, IdProductoIndividual) VALUES (@IdProductoKit, @Cantidad, @IdProductoIndividual)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IdProductoKit", detalleKit.IdProductoKit);
                        command.Parameters.AddWithValue("@Cantidad", detalleKit.Cantidad);
                        command.Parameters.AddWithValue("@IdProductoIndividual", detalleKit.IdProductoIndividual);
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
                String Error = $"Eror en GuardarDetalleKit()\nTipo: {ex.GetType()}\nDescripción: {ex.Message}";
                MessageBox.Show(Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return resultado;
        }

        public bool eliminarProductoKit(DetalleKit detalle)
        {
            bool resultado = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM Tbl_DetalleKit WHERE IdProductoKit = @IdProductoKit and IdProductoIndividual = @IdProductoIndividual";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IdProductoKit", detalle.IdProductoKit);
                        command.Parameters.AddWithValue("@IdProductoIndividual", detalle.IdProductoIndividual);
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
                String Error = $"Eror en eliminarProductoKit()\nTipo: {ex.GetType()}\nDescripción: {ex.Message}";
                MessageBox.Show(Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return resultado;
        }

        public bool validarProductoUnico(DetalleKit detalleKit)
        {
            bool resultado = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Tbl_DetalleKit WHERE IdProductoKit = @IdProductoKit AND IdProductoIndividual = @IdProductoIndividual";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IdProductoKit", detalleKit.IdProductoKit);
                        command.Parameters.AddWithValue("@IdProductoIndividual", detalleKit.IdProductoIndividual);
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            resultado = true;
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                String Error = $"Eror en validarProductoUnico()\nTipo: {ex.GetType()}\nDescripción: {ex.Message}";
                MessageBox.Show(Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return resultado;
        }
    }
}
