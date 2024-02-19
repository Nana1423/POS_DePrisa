using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_DePrisa.entidades
{
    internal class Factura
    {

        // * Definicion de atributos *
        public int IdFactura { get; set; }
        public int IdUsuario { get; set; }
        public DateTime Fecha { get; set; }
        public int IdArqueo { get; set; }
        public int Estado { get; set; }

        // * Definicion de constructores *
        // Constructor vacio
        public Factura()
        {
        }

        // Constructor con parametros
        public Factura(int idFactura, int idUsuario, DateTime fecha, int idArqueo, int estado)
        {
            IdFactura = idFactura;
            IdUsuario = idUsuario;
            Fecha = fecha;
            IdArqueo = idArqueo;
            Estado = estado;
        }
    }
}
