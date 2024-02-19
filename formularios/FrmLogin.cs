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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            Image img = pbElipse.Image;
            img.RotateFlip(RotateFlipType.Rotate180FlipNone);
            pbElipse.Image = img;

            //redondear esquinas de los textbox
           
            
        }

        private void txtUser_Click(object sender, EventArgs e)
        {
            if (txtUser.Text == "Usuario")
            {
                txtUser.Text = "";
            }
        }

        private void txtContra_Click(object sender, EventArgs e)
        {
            if (txtContra.Text == "Contraseña")
            {
                txtContra.Text = "";
                txtContra.PasswordChar = '*';
            }
        }

        private void btnSalir_MouseHover(object sender, EventArgs e)
        {
            //cambia el backcolor a rojo
            btnSalir.BackColor = Color.Red;
        }

        private void btnSalir_MouseLeave(object sender, EventArgs e)
        {
            //regresa el color al color del contenedor padre
            btnSalir.BackColor = Color.FromArgb(19, 18, 21);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
