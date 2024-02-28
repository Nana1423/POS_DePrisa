using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_DePrisa.formularios.Producto
{
    public partial class FrmCantidadDetalleKit : Form
    {
        public int cantidadProductoKit;
        public FrmCantidadDetalleKit()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //valida que sea numero
            //if (int.TryParse(txtCantidad.Text, out cantidadProductoKit))
            //{
            //    if (cantidadProductoKit > 0)
            //    {
            //        this.Close();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Ingrese un valor mayor a 0");
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Ingrese un valor numerico");
            //}

            if (int.TryParse(txtCantidad.Text, out cantidadProductoKit))
            {
                if (cantidadProductoKit > 0)
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ingrese un valor mayor a 0");
                }
            }
            else
            {
                MessageBox.Show("Ingrese un valor numerico");
            }

        }
    }
}
