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

        private void btnOcultar_Click(object sender, EventArgs e)
        {
            //oculta la segunda fila del tablelayout y haz visible el toolstrip
            //tableLayoutBackGround.RowStyles[1].SizeType =SizeType.Absolute;
            //tableLayoutBackGround.RowStyles[1].Height = 0;


            //toolStripContainer1.Visible = true;
            cambiarVisibilidadBotones(1);
            tableLayoutBackGround.RowStyles[1].Height = toolStrip2.Height;
            
            

        }

        private void cambiarVisibilidadBotones(int estado) 
        {
            if (estado == 1)
            {
                roundedButton1.Visible = false;
                btnCategoria.Visible = false;
                btnOcultar.Visible = false;
                toolStrip2.Visible = true;
            }
            else
            {
                roundedButton1.Visible = true;
                btnCategoria.Visible = true;
                btnOcultar.Visible = true;
                toolStrip2.Visible = false;
            }
            
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
       
   
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            tableLayoutBackGround.RowStyles[1].SizeType = SizeType.Absolute;
            tableLayoutBackGround.RowStyles[1].Height = 46;
            cambiarVisibilidadBotones(0);

        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            showForm(new FrmGuardarProducto());

        }

        private void btnCategoria_Click(object sender, EventArgs e)
        {
            showForm(new FrmCategoria());
        }
    }

}
