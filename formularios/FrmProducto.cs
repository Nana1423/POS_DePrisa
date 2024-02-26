using POS_DePrisa.formularios.Producto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_DePrisa.formularios
{
    public partial class FrmProducto : Form
    {
        public FrmProducto()
        {
            InitializeComponent();
        }

        private void showForm(Form form)
        {
            form.FormBorderStyle = FormBorderStyle.None;
            form.TopLevel = false;
            form.WindowState = FormWindowState.Maximized;
            panelShowData.Controls.Add(form);
            form.Show();
        }


        private void btnGuardarProducto_Click(object sender, EventArgs e)
        {
            showForm(new FrmGuardarProducto());
        }
    }
}
