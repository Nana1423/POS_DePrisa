using POS_DePrisa.dao;
using POS_DePrisa.formularios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_DePrisa
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            cargarDataGrid();
        }

        private void cargarDataGrid()
        {
       
        }

        private void tableLayoutBackGround_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnFacturas_Click(object sender, EventArgs e)
        {
            //utiliza el panelshowData para cargarFrmProducto
            showForm(new FrmProducto());

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

        private void btnProductos_Click(object sender, EventArgs e)
        {

        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            showForm(new FrmUsuario());
        }

        private void btnSalir_Click_2(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
