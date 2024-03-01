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

namespace POS_DePrisa.formularios.Producto
{
    public partial class FrmCategoria : Form
    {
        private CategoriaServices categoriaServices;
        private Categoria categoriaSelected;
        public FrmCategoria()
        {
            InitializeComponent();
            categoriaServices = new CategoriaServices();
        }

        private async void FrmCategoria_Load(object sender, EventArgs e)
        {
            try
            {
                await CargarListaProductoAsync(dgvListaCategorias);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message);

             }
        }

        //genera una funciona asincrona llamada cargarData que se encarga de cargar los datos de la base de datos
        private async Task CargarListaProductoAsync(DataGridView dg)
        {
            await Task.Run(() =>
            {
              
                var categorias = categoriaServices.listarCategoria();

                this.Invoke((MethodInvoker)delegate
                {
                    dg.DataSource = categorias.Tables[0];
                    dg.Columns["idCategoria"].Visible = false;
               
                });
            });
        }

        private void cargarListaCategorias()
        {
            var categorias = categoriaServices.listarCategoria();
            dgvListaCategorias.DataSource = categorias.Tables[0];
            dgvListaCategorias.Columns["idCategoria"].Visible = false;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            //remueve la seleccion del datagridview
            dgvListaCategorias.ClearSelection();
            txtBuscar.Text = "";

            txtCategoria.Text = "";
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;
            btnGuardar.Enabled = true;
            tpCategoria.Text = "Nueva Categoria";

            categoriaSelected = null;

        }

        private  void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampo())
            {
                return;
            }

            Categoria categoria = new Categoria();
            categoria.Nombre = txtCategoria.Text.Trim().ToUpper();

            var resultado = categoriaServices.guardar(categoria);

            if (!resultado.IsExitoso)
            {
                MessageBox.Show(resultado.Mensaje);
                return;
            }

            MessageBox.Show("Categoria guardada con exito");
            btnLimpiar_Click(sender, e);
            cargarListaCategorias();
        }

        private bool ValidarCampo()
        {
            bool resultado = false;
            if (string.IsNullOrEmpty(txtCategoria.Text))
            {
                MessageBox.Show("El campo categoria no puede estar vacio");
                resultado = false;
            }
            else
            {
                resultado = true;
            }

            return resultado; 
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampo())
            {
                return;
            }

            if (!categoriaSelectedHasChanged())
            {
                MessageBox.Show("No has modificado el nombre de la categoria");
                return;
            }

            categoriaSelected.Nombre = txtCategoria.Text.Trim().ToUpper();



            var resultado = categoriaServices.actualizarCategoria(categoriaSelected);

            if (!resultado.IsExitoso)
            {
                MessageBox.Show(resultado.Mensaje);
                return;
            }

            MessageBox.Show("Categoria actualizada con exito");
            btnLimpiar_Click(sender, e);
            cargarListaCategorias();
        }

        private bool categoriaSelectedHasChanged()
        {
            return categoriaSelected.Nombre != txtCategoria.Text.Trim().ToUpper();
        }

        private void dgvListaCategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //valida que sea una fila seleccionada valida
            if (e.RowIndex < 0)
            {
                return;
            }
            categoriaSelected = new Categoria();
            //obtiene el id de la fila seleccionada
            categoriaSelected.IdCategoria = Convert.ToInt32(dgvListaCategorias.Rows[e.RowIndex].Cells["idCategoria"].Value);
            categoriaSelected.Nombre = dgvListaCategorias.Rows[e.RowIndex].Cells["nombre"].Value.ToString();

            txtCategoria.Text = categoriaSelected.Nombre;


            tpCategoria.Text = "Actualizar Categoria";
            btnActualizar.Enabled = true;
            btnEliminar.Enabled = true;
            btnGuardar.Enabled = false;


        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.Text.Length > 0)
            {
                var ds = categoriaServices.buscar(txtBuscar.Text);
                dgvListaCategorias.DataSource = ds.Tables[0];
                dgvListaCategorias.Columns["idCategoria"].Visible = false;
            }
            else
            {
                cargarListaCategorias();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //valida si desea eliminar la categoria
            if (MessageBox.Show($"¿Estas seguro de eliminar la categoria: {categoriaSelected.Nombre}?", "Eliminar Categoria", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var resultado = categoriaServices.borrar(categoriaSelected);
                if (!resultado.IsExitoso)
                {
                    MessageBox.Show(resultado.Mensaje);
                    return;
                }
                MessageBox.Show("Categoria eliminada con exito");
                btnLimpiar_Click(sender, e);
                cargarListaCategorias();
            }
        }
    }
}
