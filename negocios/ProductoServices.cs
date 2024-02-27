using POS_DePrisa.dao;
using POS_DePrisa.entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_DePrisa.negocios
{
    internal class ProductoServices
    {
        private DProducto dProducto;

        public ProductoServices()
        {
            dProducto = new DProducto();
        }

        public ResultadoOperacion Guardar(Producto producto)
        {
            ResultadoOperacion resultado = new ResultadoOperacion();

            if (producto is null)
            {
                resultado.IsExitoso = false;
                resultado.Mensaje = "El producto no puede ser nulo";
                return resultado;
            }

            if (dProducto.validarCodigoBarra(producto.CodigoBarra))
            {
                resultado.IsExitoso = false;
                resultado.Mensaje = "El código de barra ya existe";
                return resultado;
            }
   
            if (!dProducto.guardarProducto(producto))
            {
                resultado.IsExitoso = false;
                resultado.Mensaje = "Error al guardar el producto";
                return resultado;
            }

            resultado.IsExitoso = true;
            resultado.Mensaje = "Producto guardado con éxito";

            
            return resultado;
        }

        public Producto obtenerProducto()
        {
            return new Producto();
        }

        public DataSet listarCategorias()
        {
            DCategoria dCategoria = new DCategoria();
            return dCategoria.ListarCategorias();
        }

    }
}
