using POS_DePrisa.negocios;
using POS_DePrisa.entidades;
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

namespace POS_DePrisa.formularios.Producto
{
    public partial class FrmGuardarProducto : Form
    {

        private TabPage detalleProducto;
        public FrmGuardarProducto()
        {
            InitializeComponent();
            detalleProducto = guardarTabPage();
            eliminarTabPage();
        }

        private TabPage guardarTabPage()
        {
            //obten el tabpage del tabcontrol
           
            detalleProducto = tabControl1.TabPages[1];
            detalleProducto.Text = "Detalle Producto";
            detalleProducto.BackColor = Color.Yellow;
            detalleProducto.BorderStyle = BorderStyle.Fixed3D;
            detalleProducto.Name = "detalleProducto";
            return detalleProducto;
        }
        private void eliminarTabPage()
        {
            tabControl1.TabPages.Remove(tabPage1);
        }

        private void FrmGuardarProducto_Load(object sender, EventArgs e)
        {
            cargarComboBox();
        }

        private void cargarComboBox()
        {
            ProductoServices productoServices = new ProductoServices();
            var categorias = productoServices.listarCategorias();
            cbxCategoria.DataSource = categorias.Tables[0];
            cbxCategoria.DisplayMember = "Nombre";
            cbxCategoria.ValueMember = "IdCategoria";
            cbxCategoria.SelectedIndex = -1;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (rbKitSi.Checked == true)
            {
                tabControl1.TabPages.Add(detalleProducto);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (rbKitNo.Checked == true)
            {
                tabControl1.TabPages.Remove(detalleProducto);
            }
        }

        private void btnGuardarProducto_Click(object sender, EventArgs e)
        {
            if (!validarCampos())
            {
                return;
            }
            ProductoServices productoServices = new ProductoServices();
            var produ = productoServices.obtenerProducto();

            try
            {
                produ.CodigoBarra = txtCodigoBarra.Text;
                produ.Nombre = txtNombre.Text;
                produ.Descripcion = txtDescripcion.Text;
                produ.Stock = Convert.ToInt32(txtCantidad.Text);
                produ.Precio = Convert.ToDouble(txtPrecio.Text);
                produ.DescuentoMaximo = (float)Convert.ToDouble(txtDescuento.Text);
                produ.idcategoria = Convert.ToInt32(cbxCategoria.SelectedValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

           
            if (rbKitSi.Checked == true)
            {
                produ.TieneKit = true;
            }
            else
            {
                produ.TieneKit = false;
            }

            if (rbIvaSi.Checked == true)
            {
                produ.TieneIva = true;
            }
            else
            {
                produ.TieneIva = false;
            }

            var resultado = productoServices.Guardar(produ);

            if (!resultado.IsExitoso)
            {
               MessageBox.Show(resultado.Mensaje);
                return;
            }

            MessageBox.Show(resultado.Mensaje);
            limpiarCampos();
          

        }

        private void limpiarCampos()
        {
            txtCodigoBarra.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtCantidad.Text = "";
            txtPrecio.Text = "";
            txtDescuento.Text = "";
            cbxCategoria.SelectedIndex = -1;
            rbKitNo.Checked = true;
            rbIvaNo.Checked = true;
        }

        //Regresa verdadero si cumple con todos los campos requeridos
        private bool validarCampos()
        {

            if (txtCodigoBarra.Text == "")
            {
                MessageBox.Show("El campo Codigo de Barra es obligatorio");
                return false;
            }
            if (txtNombre.Text == "")
            {
                MessageBox.Show("El campo Nombre es obligatorio");
                return false;
            }
            if (txtCantidad.Text == "")
            {
                MessageBox.Show("El campo Stock es obligatorio");
                return false;
            }
            if (txtPrecio.Text == "")
            {
                MessageBox.Show("El campo Precio es obligatorio");
                return false;
            }
            if (txtDescuento.Text == "")
            {
                MessageBox.Show("El campo Descuento Maximo es obligatorio");
                return false;
            }

            if (cbxCategoria.SelectedIndex == -1)
            {
                MessageBox.Show("El campo Categoria es obligatorio");
                return false;
            }
            return true;
        }   
    }
}
