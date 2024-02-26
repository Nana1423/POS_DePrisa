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
            //pon el color amarillo en los bordes del tabcontrol

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                tabControl1.TabPages.Add(detalleProducto);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                tabControl1.TabPages.Remove(detalleProducto);
            }
        }
    }
}
