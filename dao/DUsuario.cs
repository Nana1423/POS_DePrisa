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
    internal class DUsuario
    {

        // String de la conexion a la base de datos
        private string connectionString;

        // Constructor de la clase
        public DUsuario()
        {
            connectionString = ConfigurationManager.ConnectionStrings["POS_DePrisa.Properties.Settings.DBDePrisaConnectionString"].ConnectionString;
        }


        // Metodo para listar los usuarios
        public DataSet ListarUsuarios()
        {
            DataSet ds = new DataSet();
            try
            {
                string query = "SELECT * FROM Tbl_Usuario where Estado = 1";

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
                String Error = $"Eror en DUsuario()\nTipo: {ex.GetType()}\nDescripción: {ex.Message}";
                MessageBox.Show(Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return ds;
        }


        // Metodo para insertar un nuevo usuario
        public bool GuardarUsuario(Usuario usuario)
        {
            bool resultado = false;
            try
            {

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Tbl_Usuario (Nombre, NombreUsuario, Pw, FechaCreacion, Estado, IdRol) VALUES (@Nombre, @NombreUsuario, @Pw, @FechaCreacion, @Estado, @IdRol)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                        command.Parameters.AddWithValue("@NombreUsuario", usuario.NombreUsuario);
                        command.Parameters.AddWithValue("@Pw", usuario.Pw);
                        command.Parameters.AddWithValue("@FechaCreacion", usuario.FechaCreacion);
                        command.Parameters.AddWithValue("@Estado", 1);
                        command.Parameters.AddWithValue("@IdRol", usuario.IdRol);
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
                String Error = $"Eror en GuardarUsuario()\nTipo: {ex.GetType()}\nDescripción: {ex.Message}";
                MessageBox.Show(Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return resultado;
        }

        public bool validarUsuarioUnico(Usuario usuario)
        {
            bool resultado = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Tbl_Usuario WHERE NombreUsuario = @NombreUsuario";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@NombreUsuario", usuario.NombreUsuario);
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
                String Error = $"Eror en validarUsuarioUnico()\nTipo: {ex.GetType()}\nDescripción: {ex.Message}";
                MessageBox.Show(Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return resultado;
        }

        public bool validarCredenciales(Usuario usuario)
        {
            bool resultado = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Tbl_Usuario WHERE NombreUsuario = @NombreUsuario AND Pw = @Pw";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@NombreUsuario", usuario.NombreUsuario);
                        command.Parameters.AddWithValue("@Pw", usuario.Pw);
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
                String Error = $"Eror en validarCredenciales()\nTipo: {ex.GetType()}\nDescripción: {ex.Message}";
                MessageBox.Show(Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return resultado;
        }
    }
}
