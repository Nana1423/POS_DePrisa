using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_DePrisa.entidades
{
    internal class Rol
    {

        // * Definicion de atributos *
        public int IdRol { get; set; }
        public string Nombre { get; set; }

        // * Definicion de constructores *
        // Constructor vacio
        public Rol()
        {
        }

        // Constructor con parametros
        public Rol(int idRol, string nombre)
        {
            IdRol = idRol;
            Nombre = nombre;
        }
    }
}
