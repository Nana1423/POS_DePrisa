using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_DePrisa.entidades
{
    internal class DetalleKit
    {

        // * Definicion de atributos *
        public int IdDetalleKit { get; set; }
        public int IdProductoKit { get; set; }
        public int Cantidad { get; set; }
        public int IdProductoIndividual { get; set; }

        // * Definicion de constructores *
        // Constructor vacio
        public DetalleKit()
        {
        }

        // Constructor con parametros
        public DetalleKit(int idDetalleKit, int idProductoKit, int cantidad, int idProductoIndividual)
        {
            IdDetalleKit = idDetalleKit;
            IdProductoKit = idProductoKit;
            Cantidad = cantidad;
            IdProductoIndividual = idProductoIndividual;
        }
    }
}
