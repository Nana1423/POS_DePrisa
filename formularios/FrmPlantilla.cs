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
    public partial class FrmPlantilla : Form
    {
        public FrmPlantilla()
        {
            InitializeComponent();
        }
    

        private void showForm(Form form)
        {
            panelShowData.Controls.Clear();
            form.FormBorderStyle = FormBorderStyle.None;
            form.TopLevel = false;
            form.WindowState = FormWindowState.Maximized;
            panelShowData.Controls.Add(form);
            form.Show();
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            showForm(new FrmGuardarProducto());
        }
    }

}
