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
using System.Configuration;

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
            cargarListaProductos(dgvListaProductoPrincipal);
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

        private bool validarProductoKit()
        {
            bool resultado = false;
    

            if (dgvListaKit.RowCount > 0)
            {
                resultado = true;
            }


            return resultado; 
        }

        private void btnGuardarProducto_Click(object sender, EventArgs e)
        {
            if (!validarCampos())
            {
                return;
            }

            if (rbKitSi.Checked)
            {
                if (!validarProductoKit())
                {
                    MessageBox.Show("Debe agregar productos al kit");
                    return;
                }
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

     

        private void cargarListaProductos(DataGridView dg)
        {
            ProductoServices services = new ProductoServices();
            var productos = services.listarProductos();
            dg.DataSource = productos.Tables[0];

            //ocultas las columnas que no se necesitan y ocupa el nombre de la columna para ocultarla
            dg.Columns["IdProducto"].Visible = false;
            dg.Columns["IdCategoria"].Visible = false;
            dg.Columns["TieneKit"].Visible = false;
            dg.Columns["TieneIva"].Visible = false;
            dg.Columns["DescuentoMaximo"].Visible = false;
            dg.Columns["Costo"].Visible = true;
            dg.Columns["Stock"].Visible = true;
            dg.Columns["Descripcion"].Visible = true;
            dg.Columns["CodigoBarra"].Visible = false;
            dg.Columns["Nombre"].Visible = true;
            dg.Columns["estado"].Visible = false;
            //cambia el nombre de las columnas
            dg.Columns["Nombre"].HeaderText = "Nombre";
            dg.Columns["CodigoBarra"].HeaderText = "Codigo de Barra";
            dg.Columns["Descripcion"].HeaderText = "Descripcion";
            dg.Columns["Stock"].HeaderText = "Stock";
            dg.Columns["Costo"].HeaderText = "Precio";
            dg.Columns["DescuentoMaximo"].HeaderText = "Descuento Maximo";
            dg.Columns["TieneKit"].HeaderText = "Tiene Kit";
            dg.Columns["TieneIva"].HeaderText = "Tiene Iva";

        }
        private void configurarDgvListaKit()
        {
            //agrega columnas al dgv igualitas a las de dgvListaProducto
            dgvListaKit.ColumnCount = 11;
            dgvListaKit.Columns[0].Name = "idProducto";
            dgvListaKit.Columns[1].Name = "CodigoBarra";
            dgvListaKit.Columns[2].Name = "Nombre";
            dgvListaKit.Columns[3].Name = "Descripcion";
            dgvListaKit.Columns[4].Name = "Stock";
            dgvListaKit.Columns[5].Name = "Costo";
            dgvListaKit.Columns[6].Name = "DescuentoMaximo";
            dgvListaKit.Columns[7].Name = "TieneKit";
            dgvListaKit.Columns[8].Name = "TieneIva";
            dgvListaKit.Columns[9].Name = "IdCategoria";
            dgvListaKit.Columns[10].Name = "estado";
            //oculta las columnas que no se necesitan
            dgvListaKit.Columns[0].Visible = false;
            dgvListaKit.Columns[2].Visible = false;
            dgvListaKit.Columns[7].Visible = false;
            dgvListaKit.Columns[8].Visible = false;
            dgvListaKit.Columns[9].Visible = false;
            dgvListaKit.Columns[10].Visible = false;

     
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                cargarListaProductos(dgvListaProductos);
                configurarDgvListaKit();
            }
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //pregunta cantidad del producto en messagebox
           
            //cruza los datos al siguiente dgv
            DataGridViewRow selectedRow = dgvListaProductos.CurrentRow;
            var newRow = selectedRow.Clone() as DataGridViewRow;
            foreach (DataGridViewCell cell in selectedRow.Cells)
            {
                newRow.Cells[cell.ColumnIndex].Value = cell.Value;
            }
            dgvListaKit.Rows.Add(newRow);

        }

        private void dgvListaProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //valida que se haya seleccionado una fila valida
            if (e.RowIndex >= 0)
            {
                btnAgregar.Enabled = true;

                return;
            }


  

        }

        private void dgvListaKit_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnAgregar.Enabled = false;
                btnQuitar.Enabled = true;

                return;
            }

        }
    }
}
