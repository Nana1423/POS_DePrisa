using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_DePrisa.entidades
{
    internal class Producto
    {

        public int IdProducto { get; set; }
        public string CodigoBarra { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Stock { get; set; }  
        public double Precio { get; set; }
        public bool TieneIva { get; set; }
        public bool TieneKit { get; set ; }
        public float DescuentoMaximo { get; set; }  
        public int estado { get; set; }
        public int idcategoria { get; set; }
        
        public Producto()
        {
        }

        public Producto(int idProducto, string codigoBarra, string nombre, string descripcion, int stock, double precio, bool tieneIva, bool tieneKit, float descuentoMaximo, int estado, int idcategoria)
        {
            IdProducto = idProducto;
            CodigoBarra = codigoBarra;
            Nombre = nombre;
            Descripcion = descripcion;
            Stock = stock;
            Precio = precio;
            TieneIva = tieneIva;
            TieneKit = tieneKit;
            DescuentoMaximo = descuentoMaximo;
            this.estado = estado;
            this.idcategoria = idcategoria;
        }
    }
}
