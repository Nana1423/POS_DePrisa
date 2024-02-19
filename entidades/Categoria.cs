using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_DePrisa.entidades
{
    internal class Categoria
    {

        // * Definicion de atributos *
        public int IdCategoria { get; set; }
        public string Nombre { get; set; }


        // * Definicion de constructores *
        // Constructor vacio
        public Categoria()
        {
        }

        // Constructor con parametros
        public Categoria(int idCategoria, string nombre)
        {
            IdCategoria = idCategoria;
            Nombre = nombre;
        }
    }
}
