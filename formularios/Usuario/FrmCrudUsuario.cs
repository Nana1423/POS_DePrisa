using POS_DePrisa.entidades;
using POS_DePrisa.negocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_DePrisa.formularios.Usuario
{
    public partial class FrmCrudUsuario : Form
    {
        private UsuarioServices usuarioServices;
        public FrmCrudUsuario()
        {
            InitializeComponent();
            usuarioServices = new UsuarioServices();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Clear();
            txtUserName.Clear();
            txtContrasena.Clear();
            cbxRol.SelectedIndex = -1;
        }

        private void FrmCrudUsuario_Load(object sender, EventArgs e)
        {
            cargarDgvListaUsuario();
            cargarCbxRol();
        }

        private void cargarCbxRol()
        {
            cbxRol.DataSource = usuarioServices.obtenerRoles().Tables[0];
            cbxRol.DisplayMember = "nombre";
            cbxRol.ValueMember = "idRol";

        }

        private void cargarDgvListaUsuario()
        {
            dgvListaUsuario.DataSource = usuarioServices.listarUsuarios().Tables[0];
            dgvListaUsuario.Columns["idUsuario"].Visible = false;
            dgvListaUsuario.Columns["idRol"].Visible = false;
            dgvListaUsuario.Columns["pw"].Visible = false;
            dgvListaUsuario.Columns["fechaCreacion"].Visible = false;
            dgvListaUsuario.Columns["estado"].Visible   = false;

            //cambia el nombre de la columna
            dgvListaUsuario.Columns["nombre"].HeaderText = "Nombre";
            dgvListaUsuario.Columns["nombreUsuario"].HeaderText = "Usuario";


        }

        private bool validarCampos()
        {
            if (txtNombre.Text == "")
            {
                MessageBox.Show("El campo nombre es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtUserName.Text == "")
            {
                MessageBox.Show("El campo nombre de usuario es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtContrasena.Text == "")
            {
                MessageBox.Show("El campo contraseña es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cbxRol.SelectedIndex == -1)
            {
                MessageBox.Show("El campo rol es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void btnGuardarProducto_Click(object sender, EventArgs e)
        {
            if (!validarCampos())
            {
                return;
            }

            var usuario = new entidades.Usuario();

            usuario.Nombre = txtNombre.Text;
            usuario.NombreUsuario = txtUserName.Text;
            usuario.Pw = txtContrasena.Text;
            usuario.IdRol = Convert.ToInt32(cbxRol.SelectedValue);
            usuario.FechaCreacion = DateTime.Now;
            usuario.Estado = 1;


            var resultado = usuarioServices.guardar(usuario);

            if (!resultado.IsExitoso)
            {
                MessageBox.Show(resultado.Mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show(resultado.Mensaje, "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            cargarDgvListaUsuario();
            btnLimpiar.PerformClick();
      
        }
    }
}
