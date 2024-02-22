using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_DePrisa.customControls
{
    internal class GradientPanel: System.Windows.Forms.Panel
    {

        //public System.Drawing.Color ColorTop { get; set; }
        //public System.Drawing.Color ColorBottom { get; set; }
        //protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        //{
        //    System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(this.ClientRectangle, this.ColorTop, this.ColorBottom, 90F);
        //    e.Graphics.FillRectangle(brush, this.ClientRectangle);
        //    base.OnPaint(e);
        //}

        //genera el codigo para crear el gradiente de izquierda a derecha
        public System.Drawing.Color ColorLeft { get; set; }
        public System.Drawing.Color ColorRight { get; set; }
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(this.ClientRectangle, this.ColorLeft, this.ColorRight, 0F);
            e.Graphics.FillRectangle(brush, this.ClientRectangle);
            base.OnPaint(e);
        }
    }
}
