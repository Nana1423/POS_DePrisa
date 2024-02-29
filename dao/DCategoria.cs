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
    internal class DCategoria
    {
        // String de la conexion a la base de datos
        private string connectionString;

        // Constructor de la clase
        public DCategoria()
        {
            connectionString = ConfigurationManager.ConnectionStrings["POS_DePrisa.Properties.Settings.DBDePrisaConnectionString"].ConnectionString;
        }


        // Metodo para listar las categorias
        public DataSet ListarCategorias()
        {
            DataSet ds = new DataSet();
            try
            {
                string query = "SELECT * FROM Tbl_Categoria";

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
                String Error = $"Eror en DCategoria()\nTipo: {ex.GetType()}\nDescripción: {ex.Message}";
                MessageBox.Show(Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return ds;
        }


        // Metodo para insertar una nueva categoria
        public bool GuardarCategoria(Categoria categoria)
        {
            bool resultado = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Tbl_Categoria (Nombre) VALUES (@Nombre)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre", categoria.Nombre);
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
                String Error = $"Eror en GuardarCategoria()\nTipo: {ex.GetType()}\nDescripción: {ex.Message}";
                MessageBox.Show(Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return resultado;
        }

        public bool validarCategoriaUnica(Categoria categoria)
        {
            bool resultado = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Tbl_Categoria WHERE Nombre = @Nombre";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre", categoria.Nombre);
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
                String Error = $"Eror en validarCategoriaUnica()\nTipo: {ex.GetType()}\nDescripción: {ex.Message}";
                MessageBox.Show(Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return resultado;
        }

        public bool actualizarCategoria(Categoria categoria)
        {
            bool resultado = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Tbl_Categoria SET Nombre = @Nombre WHERE idCategoria = @idCategoria";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre", categoria.Nombre);
                        command.Parameters.AddWithValue("@idCategoria", categoria.IdCategoria);
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
                String Error = $"Eror en actualizarCategoria()\nTipo: {ex.GetType()}\nDescripción: {ex.Message}";
                MessageBox.Show(Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return resultado;
        }

        public bool eliminarCategoria(Categoria categoria)
        {
            bool resultado = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM Tbl_Categoria WHERE idCategoria = @idCategoria";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@idCategoria", categoria.IdCategoria);
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
                String Error = $"Eror en eliminarCategoria()\nTipo: {ex.GetType()}\nDescripción: {ex.Message}";
                MessageBox.Show(Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return resultado;
        }

        public DataSet buscarCategoria(String nombre)
        {
            DataSet ds = new DataSet();
            try
            {
                string query = "SELECT * FROM Tbl_Categoria WHERE Nombre LIKE @Nombre";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(query, connection))
                    {
                        da.SelectCommand.Parameters.AddWithValue("@Nombre", "%" + nombre + "%");
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
                String Error = $"Eror en buscarCategoria()\nTipo: {ex.GetType()}\nDescripción: {ex.Message}";
                MessageBox.Show(Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return ds;
        }
    }
}
