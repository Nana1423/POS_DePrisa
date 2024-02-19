using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_DePrisa.entidades
{
    internal class DetalleFactura
    {

        // * Definicion de atributos *
        public int IdDetalleFactura { get; set; }
        public int Cantidad { get; set; }
        public float Precio { get; set; }
        public float Descuento { get; set; }
        public int IdProducto { get; set; }
        public int IdFactura { get; set; }

        // * Definicion de constructores *
        // Constructor vacio
        public DetalleFactura()
        {
        }

        // Constructor con parametros
        public DetalleFactura(int idDetalleFactura, int cantidad, float precio, float descuento, int idProducto, int idFactura)
        {
            IdDetalleFactura = idDetalleFactura;
            Cantidad = cantidad;
            Precio = precio;
            Descuento = descuento;
            IdProducto = idProducto;
            IdFactura = idFactura;
        }
    }
}
