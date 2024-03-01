using POS_DePrisa.negocios;
using POS_DePrisa.entidades;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace POS_DePrisa.formularios.Producto
{
    public partial class FrmPrueba : Form
    {
        private TabPage detalleKit;
        private int idProductoSelected;
        private bool modoEdicion;
        public FrmPrueba()
        {
            InitializeComponent();
            

        }

        private async void FrmPrueba_Load(object sender, EventArgs e)
        {
            idProductoSelected = -1; //Nos servira para validar si el usuario ya esta creado antes de entrar a detalles kit
            modoEdicion = false;
            guardarTabPage();
            eliminarTabPage();
            await CargarListaProductoAsync(dgvListaProductoPrincipal);
            await CargarComboAsync();

        }

        private async Task CargarComboAsync()
        {
            await Task.Run(() =>
            {
                ProductoServices productoServices = new ProductoServices();
                var categorias = productoServices.listarCategorias();

                // Actualizar el ComboBox en el hilo de la interfaz de usuario
                this.Invoke((MethodInvoker)delegate
                {
                    cbxCategoria.DataSource = categorias.Tables[0];
                    cbxCategoria.DisplayMember = "Nombre";
                    cbxCategoria.ValueMember = "IdCategoria";
                    cbxCategoria.SelectedIndex = -1;
                });
            });
        }

        private async Task CargarListaProductoAsync(DataGridView dg)
        {
            await Task.Run(() =>
            {
                ProductoServices services = new ProductoServices();
                var productos = services.listarProductos();

                this.Invoke((MethodInvoker)delegate
                {
                    dg.DataSource = productos.Tables[0];
                    OcultarMostrarColumnas(dg);
                    CambiarNombresColumnas(dg);
                });
            });
        }

        private void OcultarMostrarColumnas(DataGridView dg)
        {
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
        }

        private void CambiarNombresColumnas(DataGridView dg)
        {
            dg.Columns["Nombre"].HeaderText = "Nombre";
            dg.Columns["CodigoBarra"].HeaderText = "Codigo de Barra";
            dg.Columns["Descripcion"].HeaderText = "Descripcion";
            dg.Columns["Stock"].HeaderText = "Stock";
            dg.Columns["Costo"].HeaderText = "Precio";
            dg.Columns["DescuentoMaximo"].HeaderText = "Descuento Maximo";
            dg.Columns["TieneKit"].HeaderText = "Tiene Kit";
            dg.Columns["TieneIva"].HeaderText = "Tiene Iva";
        }


        private void guardarTabPage()
        {
            detalleKit = tabControl1.TabPages[1];
        }

        private void eliminarTabPage()
        {
            tabControl1.TabPages.Remove(tabPage1);
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

        private async void btnGuardarProducto_Click(object sender, EventArgs e)
        {
            if (!validarCampos())
            {
                return;
            }

            ProductoServices productoServices = new ProductoServices();

            // Este codigo simplemente se realiza para obtener una instancia de la clase producto.
            // El visual studio no me permite crear una instancia de la clase por que lo confunde con un namespace
            // para confirmar quita la siguiente comillas
             //Producto producto1 = new Producto();

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


            //pasos a ejecutar solamente si el producto es un kit
            if (rbKitSi.Checked == true)
            {
                //Nos va a servir para poder obtener el id del producto que acabamos de guardar y o vamos a utilizar para guardar el detalle del kit
                idProductoSelected = productoServices.obtenerIdProducto(produ.CodigoBarra);

                MessageBox.Show("Agrega los productos del kit");
                //cambia al tabPage de detalle del kit
                tabControl1.TabPages.Add(detalleKit);
                tabControl1.SelectedIndex = 2;
                await CargarListaProductoAsync(dgvListaKit);
                await CargarListaProductoAsync(dgvListaProductos);

                //se corta la ejecucion del metodo por que si se limpian los campos se genera un checkedChange y oculta la tabPage
                return;
            }
          

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
            idProductoSelected = -1;
            eliminarTabPage();
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



        private void rbKitSi_CheckedChanged(object sender, EventArgs e)
        {
            if ((rbKitSi.Checked) && (idProductoSelected >0))
            {
               if(!tabControl1.TabPages.Contains(detalleKit))
                {
                    tabControl1.TabPages.Add(detalleKit);
                }
            }


        }

        private void rbKitNo_CheckedChanged(object sender, EventArgs e)
        {
            if ((rbKitNo.Checked) && (idProductoSelected == -1))
            {
                tabControl1.TabPages.Remove(detalleKit);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //crea un detalle kit

            var frm = new FrmCantidadDetalleKit();
            frm.ShowDialog();
            int cantidadProducto = frm.cantidadProductoKit;


            DetalleKit detalle = new DetalleKit();
            detalle.IdProductoKit = idProductoSelected;
            detalle.IdProductoIndividual = Convert.ToInt32(dgvListaProductos.CurrentRow.Cells[0].Value);
            detalle.Cantidad = cantidadProducto;
            
            ProductoServices productServices = new ProductoServices();
            var resultado = productServices.guardarProductoKit(detalle);

            if (!resultado.IsExitoso)
            {
                MessageBox.Show(resultado.Mensaje);
                return;
            }

            MessageBox.Show(resultado.Mensaje);
            cargarProductosKit();
        }

        private void cargarProductosKit()
        {
            ProductoServices productoServices = new ProductoServices();
            var listaProductos = productoServices.obtenerPruductosKit(idProductoSelected);
            dgvListaKit.DataSource = listaProductos.Tables[0];
            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
           //valida que si desea eliminar el producto
            DialogResult dialogResult = MessageBox.Show("¿Desea eliminar el producto?", "Eliminar", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
            {
                return;
            }
            ProductoServices productoServices = new ProductoServices();
            //var resultado = productoServices.eliminarProducto(idProductoSelected);
            //if (!resultado.IsExitoso)
            //{
            //    MessageBox.Show(resultado.Mensaje);
            //    return;
            //}
            //MessageBox.Show(resultado.Mensaje);
            //limpiarCampos();
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            ProductoServices productoServices = new ProductoServices();
            DetalleKit detalle = new DetalleKit();
            detalle.IdProductoKit = idProductoSelected;
            detalle.IdProductoIndividual = Convert.ToInt32(dgvListaKit.CurrentRow.Cells[0].Value);
            var resultado = productoServices.eliminarProductoKit(detalle);
            if (!resultado.IsExitoso)
            {
                MessageBox.Show(resultado.Mensaje);
                return;
            }
            MessageBox.Show(resultado.Mensaje);
            cargarProductosKit();
        }

        private async void dgvListaProductoPrincipal_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //valida que sea en filas validas
            if (e.RowIndex < 0)
            {
                return;
            }
            limpiarCampos();
            modoEdicion = true;

            //carga los datos del producto seleccionado pero utiliza el nombre de la columna
            idProductoSelected = Convert.ToInt32(dgvListaProductoPrincipal.CurrentRow.Cells["IdProducto"].Value);
            txtNombre.Text = dgvListaProductoPrincipal.CurrentRow.Cells["Nombre"].Value.ToString();
            txtCodigoBarra.Text = dgvListaProductoPrincipal.CurrentRow.Cells["CodigoBarra"].Value.ToString();
            txtDescripcion.Text = dgvListaProductoPrincipal.CurrentRow.Cells["Descripcion"].Value.ToString();
            txtCantidad.Text = dgvListaProductoPrincipal.CurrentRow.Cells["Stock"].Value.ToString();
            txtPrecio.Text = dgvListaProductoPrincipal.CurrentRow.Cells["Costo"].Value.ToString();
            txtDescuento.Text = dgvListaProductoPrincipal.CurrentRow.Cells["DescuentoMaximo"].Value.ToString();
            cbxCategoria.SelectedValue = dgvListaProductoPrincipal.CurrentRow.Cells["IdCategoria"].Value;
            if (Convert.ToBoolean(dgvListaProductoPrincipal.CurrentRow.Cells["tieneKit"].Value) == true)
            {
                rbKitSi.Checked = true;
            }
            else
            {
                rbKitNo.Checked = true;
            }
            if (Convert.ToBoolean(dgvListaProductoPrincipal.CurrentRow.Cells["tieneIva"].Value) == true)
            {
                rbIvaSi.Checked = true;
            }
            else
            {
                rbIvaNo.Checked = true;
            }
            if (rbKitSi.Checked == true)
            {
                await CargarListaProductoAsync(dgvListaProductos);
                cargarProductosKit();
            }


            btnGuardarProducto.Enabled = false;
            btnEliminar.Enabled = true;
            btnActualizar.Enabled = true;

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cargarListaProductos(dgvListaProductos);
            //cargarProductosKit();
        }

        private void dgvListaProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           //validar fila 
           if (e.RowIndex < 0)
            {
                return;
            }
           btnAgregar.Enabled = true;
          
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        
        private void btnActualizar_Click(object sender, EventArgs e)
        {

        }
    }
}
