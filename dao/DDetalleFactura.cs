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
    internal class DDetalleFactura
    {

        // String de la conexion a la base de datos
        private string connectionString;

        // Constructor de la clase
        public DDetalleFactura()
        {
            connectionString = ConfigurationManager.ConnectionStrings["POS_DePrisa.Properties.Settings.DBDePrisaConnectionString"].ConnectionString;
        }


        // Metodo para listar los detalles de facturas
        public DataSet ListarDetalleFacturas()
        {
            DataSet ds = new DataSet();
            try
            {
                string query = "SELECT * FROM Tbl_DetalleFactura";

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
                String Error = $"Eror en DDetalleFactura()\nTipo: {ex.GetType()}\nDescripción: {ex.Message}";
                MessageBox.Show(Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return ds;
        }


        // Metodo para insertar un nuevo detalle de factura
        public bool GuardarDetalleFactura(DetalleFactura detalleFactura)
        {
            bool resultado = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Tbl_DetalleFactura (Cantidad, Precio, Descuento, IdProducto, IdFactura) VALUES (@Cantidad, @Precio, @Descuento, @IdProducto, @IdFactura)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Cantidad", detalleFactura.Cantidad);
                        command.Parameters.AddWithValue("@Precio", detalleFactura.Precio);
                        command.Parameters.AddWithValue("@Descuento", detalleFactura.Descuento);
                        command.Parameters.AddWithValue("@IdProducto", detalleFactura.IdProducto);
                        command.Parameters.AddWithValue("@IdFactura", detalleFactura.IdFactura);
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
                String Error = $"Eror en GuardarDetalleFactura()\nTipo: {ex.GetType()}\nDescripción: {ex.Message}";
                MessageBox.Show(Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return resultado;
        }
    }
}
